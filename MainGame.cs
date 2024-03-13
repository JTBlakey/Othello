namespace Othello
{

    public partial class MainGame : Form
    {
        private const int BoardSize = 8;
        private Button[,] cells;

        public DifficultySet.Difficulty difficulty;

        private void InitializeGameBoard()
        {

            board.RowCount = BoardSize; // set up board size
            board.ColumnCount = BoardSize;
            cells = new Button[BoardSize, BoardSize];

            for (int row = 0; row < BoardSize; row++) // create a button for each cell in board 
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Button cell = new Button(); //Creates new button
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0); // make sure button takes up whole space of cell
                    cell.FlatStyle = FlatStyle.Flat; //remove 3d effect of button
                    cell.FlatAppearance.BorderSize = 1; //adds a border to the button
                    cell.Click += UserMove; // adds an event handler to the press of a button
                    board.Controls.Add(cell, col, row); // adds button to the speciffied cell
                    cells[row, col] = cell; // stores a referance to the button in an array: cells
                }
            }
            int middleLocation = 4; //set up four starting pieces
            board.Controls[middleLocation - 1 + (middleLocation - 1) * BoardSize].BackColor = Color.White;
            board.Controls[middleLocation + (middleLocation - 1) * BoardSize].BackColor = Color.Black;
            board.Controls[middleLocation - 1 + middleLocation * BoardSize].BackColor = Color.Black;
            board.Controls[middleLocation + middleLocation * BoardSize].BackColor = Color.White;
        }
        public enum Piece
        {
            Empty,
            Black,
            White
        }

        private void UserMove(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = -1, col = -1; // find coordinates of the clicked button
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (cells[i, j] == clickedButton)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1 && col != -1)
                    break;
            }
            if (row != -1 && col != -1 && IsLegalMove(row, col, Piece.White)) // check if a legal move
            {
                PlacePiece(row, col, Piece.White); // place the user's piece at the clicked position
                AImove(this.difficulty);
            }
            else
            {
                // display a message saying the move not allowed
            }
        }
        public void AImove(DifficultySet.Difficulty difficulty)
        {

            if (difficulty == DifficultySet.Difficulty.Easy)
            {
                AImove1();
            }
            if (difficulty == DifficultySet.Difficulty.Medium)
            {
                AImove2();
            }
            if (difficulty == DifficultySet.Difficulty.Hard)
            {
                AImove3();
            }
        }

        public void AImove1()
        {

            List<Point> legalMoves = GetLegalMoves(Piece.Black); // get all legal moves

            if (legalMoves.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, legalMoves.Count); // pick random move
                Point selectedMove = legalMoves[randomIndex];

                PlacePiece(selectedMove.X, selectedMove.Y, Piece.Black); // perform the move
            }
            else
            {
                GameEnd();
            }
        }
        public void AImove2()
        {
            List<Point> legalMoves = GetLegalMoves(Piece.Black); // get all legal moves for the computer (black pieces)

            if (legalMoves.Count > 0)
            {
                int bestScore = int.MinValue;
                Point bestMove = new Point(-1, -1);

                foreach (Point move in legalMoves) // go through each legal move
                {
                    int score = EvaluateMove(move.X, move.Y, Piece.Black, 1); // evaluate the move using a depth of 1


                    if (score > bestScore) // update the best move if the current move has a higher score
                    {
                        bestScore = score;
                        bestMove = move;
                    }
                }

                if (bestMove.X != -1 && bestMove.Y != -1) // perform the best move
                {
                    PlacePiece(bestMove.X, bestMove.Y, Piece.Black);
                }
            }
            else
            {
                // the case where the computer cannot make any moves
            }
        }
        public void AImove3()
        {

        }

        private int EvaluateMove(int row, int col, Piece color, int depth)
        {
            int score = 0;

            if ((row == 0 || row == BoardSize - 1) && (col == 0 || col == BoardSize - 1)) // if the move is on a corner cell assign a high score
            {
                score += 1000;
            }

            for (int dr = -1; dr <= 1; dr++) // calculate the number of opponent pieces flipped by making the move
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0)
                        continue; // skip the current position

                    int r = row + dr;
                    int c = col + dc;
                    bool foundOpponentPiece = false;
                    int flippedPieces = 0;

                    while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && cells[r, c].BackColor != Color.Empty) // search in the current direction for opponent pieces
                    {
                        if (cells[r, c].BackColor == ((color == Piece.Black) ? Color.White : Color.Black))
                        {
                            foundOpponentPiece = true;
                            flippedPieces++;
                        }
                        else if (foundOpponentPiece)
                        {
                            score += flippedPieces; // increment score based on the number of flipped opponent pieces
                            break;
                        }
                        r += dr;
                        c += dc;
                    }
                }
            }

            return score;
        }

        public MainGame(DifficultySet.Difficulty difficulty)
        {
            this.difficulty = difficulty;

            InitializeComponent();
            InitializeGameBoard();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3); // generates random number between 1 and 2
            if (randomNumber == 1)
            {
                AImove(this.difficulty);
            }
        }

        private void Quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void PlacePiece(int row, int col, Piece color)
        {
            cells[row, col].BackColor = (color == Piece.Black) ? Color.Black : Color.White; // update the cell colour to the player's colour

            for (int dr = -1; dr <= 1; dr++) // flip opponent's pieces
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0)
                        continue; // skip the current position

                    int r = row + dr;
                    int c = col + dc;
                    bool foundOpponentPiece = false;

                    while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && cells[r, c].BackColor != Color.FromArgb(255, 252, 103, 54)) // search in the current direction for opponent pieces
                    {
                        if (cells[r, c].BackColor == ((color == Piece.Black) ? Color.White : Color.Black))
                        {
                            foundOpponentPiece = true;
                        }
                        else if (foundOpponentPiece)
                        {
                            // If we've found an opponent piece and then the current piece is of the same color, flip the enclosed opponent pieces
                            while (r != row || c != col)
                            {
                                cells[r, c].BackColor = (color == Piece.Black) ? Color.Black : Color.White;
                                r -= dr;
                                c -= dc;
                            }
                            break;
                        }
                        r += dr;
                        c += dc;
                    }
                }
            }
            Thread.Sleep(150);
        }

        private List<Point> GetLegalMoves(Piece color)
        {
            List<Point> legalMoves = new List<Point>();

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {

                    if (IsLegalMove(row, col, color) == true)
                    {
                        legalMoves.Add(new Point(row, col));
                    }
                }
            }
            return legalMoves;
        }

        private bool IsLegalMove(int row, int col, Piece color)
        {
            // Check if the specified position is empty
            if (cells[row, col].BackColor != Color.FromArgb(255, 252, 103, 54))
                return false;

            // Check in all eight directions for opponent pieces that can be flipped
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    // Skip the current position(0, 0) as it represents the current cell
                    if (dr == 0 && dc == 0)
                        continue;

                    // Check if an opponent piece in the current direction
                    int r = row + dr;
                    int c = col + dc;
                    bool foundOpponentPiece = false;
                    while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && cells[r, c].BackColor != Color.FromArgb(255, 252, 103, 54) && cells[r, c].BackColor != ((color == Piece.Black) ? Color.Black : Color.White))
                    {
                        foundOpponentPiece = true;
                        r += dr;
                        c += dc;


                    }

                    // If an opponent piece and our own piece in this direction, the move is legal
                    if (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && foundOpponentPiece && cells[r, c].BackColor == ((color == Piece.Black) ? Color.Black : Color.White))
                        return true;
                }
            }

            return false; // No opponent pieces can be flipped in any direction, so the move is illegal
        }
        private void GameEnd()
        {

        }
    }
}
