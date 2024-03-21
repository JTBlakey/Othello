using System;
using System.Reflection;

namespace Othello
{

    public partial class MainGame : Form
    {
        private const int BoardSize = 8;
        private Button[,] cells;

        public Color bgColor = Color.FromArgb(255, 252, 103, 54);
        public DifficultySet.Difficulty difficulty;

        private void MainGame_Load(object sender, EventArgs e)
        {
           
            Random random = new Random();
            int randomNumber = random.Next(1, 3); // generates random number between 1 and 2
            if (randomNumber == 1)
            {
                AImove(this.difficulty);
            }
        }
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
            
            for (int row = 0; row < BoardSize; row++) // find coordinates of the clicked button
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (cells[row, col] == clickedButton && IsLegalMove(row,col, Piece.White) == true)
                    {
                        PlacePiece(row, col, Piece.White);
                        Score();
                        Application.DoEvents();
                        Thread.Sleep(600);

                        AImove(this.difficulty);
                    }
                    else if (cells[row, col] == clickedButton && IsLegalMove(row, col, Piece.White) == false)
                    {
                        MessageBox.Show("You cannot place a piece there");
                    }
                }
            }
        }
        public void AImove(DifficultySet.Difficulty difficulty)
        {
            
            if (difficulty == DifficultySet.Difficulty.Easy)
            {
                AImoveEasy();
            }
            if (difficulty == DifficultySet.Difficulty.Medium)
            {
                AImoveMedium();
            }
            if (difficulty == DifficultySet.Difficulty.Hard)
            {
                AImoveHard();
            }
        }

        public void AImoveEasy()
        {

            List<Point> legalMoves = GetLegalMoves(Piece.Black); // get all legal moves

            if (legalMoves.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, legalMoves.Count); // pick random move
                Point selectedMove = legalMoves[randomIndex];

                PlacePiece(selectedMove.X, selectedMove.Y, Piece.Black); // perform the move
                Score();
            }
            else
            {
                //if GetLegalMove(Piece.White) == 0 
                GameEnd();
            }
        }
        public void AImoveMedium()
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
                    Score();
                }
            }
            else
            {
                // the case where the computer cannot make any moves
                GameEnd();
            }
        }
        public void AImoveHard()
        {
            List<Point> legalMoves = GetLegalMoves(Piece.Black); // get all legal moves for the computer (black pieces)

            if (legalMoves.Count > 0)
            {
                int bestScore = int.MinValue;
                Point bestMove = new Point(-1, -1);

                foreach (Point move in legalMoves) // go through each legal move
                {
                    int score = EvaluateMove(move.X, move.Y, Piece.Black, 5); // evaluate the move using a depth of 


                    if (score > bestScore) // update the best move if the current move has a higher score
                    {
                        bestScore = score;
                        bestMove = move;
                    }
                }

                if (bestMove.X != -1 && bestMove.Y != -1) // perform the best move
                {
                    PlacePiece(bestMove.X, bestMove.Y, Piece.Black);
                    Score();
                }
            }
            else
            {
                // the case where the computer cannot make any moves
                GameEnd();
            }
        }

        private int EvaluateMove(int row, int col, Piece color, int depth)
        {
            int score = 0;

            // If the move is on a corner cell, assign a very high score
            if ((row == 0 || row == BoardSize - 1) && (col == 0 || col == BoardSize - 1))
            {
                score += 10000;
            }
            // If the move is on an edge cell, assign a high score
            else if (row == 0 || row == BoardSize - 1 || col == 0 || col == BoardSize - 1)
            {
                score += 1000;
            }

            // Evaluate the move recursively with a depth of 1
            if (depth > 1)
            {
                // Calculate the mobility (number of legal moves) for the opponent
                List<Point> opponentMoves = GetLegalMoves((color == Piece.Black) ? Piece.White : Piece.Black);
                int opponentMobility = opponentMoves.Count;

                // Calculate the stability (number of stable discs) for the opponent
                int opponentStability = CalculateStability((color == Piece.Black) ? Piece.White : Piece.Black);

                // Evaluate the potential moves for the opponent with a depth of 1
                foreach (Point move in opponentMoves)
                {
                    int opponentScore = EvaluateMove(move.X, move.Y, (color == Piece.Black) ? Piece.White : Piece.Black, depth - 1);
                    score -= opponentScore; // Subtract the opponent's score from the current score
                }

                // Apply mobility and stability factors to the score
                score += (opponentMobility - GetLegalMoves(color).Count) * 10;
                score += (GetStability(color) - opponentStability) * 100;
            }

            return score;
        }

        private int CalculateStability(Piece color)
        {
            int stability = 0;
            Piece opponentColor = (color == Piece.Black) ? Piece.White : Piece.Black;

            // Iterate through each cell of the board
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (cells[row, col].BackColor == ((color == Piece.Black) ? Color.White : Color.Black))
                    {
                        // Check if the disc is stable
                        if (IsStable(row, col, color))
                        {
                            stability++;
                        }
                    }
                }
            }

            return stability;
        }

        private bool IsStable(int row, int col, Piece color)
        {
            // Implement stability checking logic here
            // This could involve checking if the disc is surrounded by same-colored discs in all directions
            // Or if it's located in a corner or along an edge

            // Example: For simplicity, let's assume discs on the edges and corners are stable
            if (row == 0 || row == BoardSize - 1 || col == 0 || col == BoardSize - 1)
            {
                return true;
            }

            return false;
        }

        private int GetStability(Piece color)
        {
            // Just return the stability calculated previously
            return CalculateStability(color);
        }


        public MainGame(DifficultySet.Difficulty difficulty)
        {
            this.difficulty = difficulty;

            InitializeComponent();
            InitializeGameBoard();
        }

        private void Quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void PlacePiece(int row, int col, Piece color)
        {
            cells[row, col].BackColor = (color == Piece.Black) ? Color.Black : Color.White; 
                                                            // update the cell colour to the player's colour
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)            // flip opponent's pieces
                {
                    if (dr == 0 && dc == 0)
                        continue;                           // skip the current position

                    int r = row + dr;
                    int c = col + dc;
                    bool foundOpponentPiece = false;

                    while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize &&
                        cells[r, c].BackColor != bgColor)   // search in the current direction for opponent pieces
                    {
                        if (cells[r, c].BackColor == ((color == Piece.Black) ? Color.White : Color.Black))
                        {
                            foundOpponentPiece = true;
                        }
                        else if (foundOpponentPiece)
                        {
                            while (r != row || c != col)    // if an opponent piece and then the current piece is
                                                            // of the same color, flip the enclosed opponent pieces
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
        }

        private List<Point> GetLegalMoves(Piece color)
        {
            List<Point> legalMoves = new List<Point>(); // list of possible moves

            for (int row = 0; row < BoardSize; row++)
            { 
                for (int col = 0; col < BoardSize; col++)// cycle through each cell on the game board
                {

                    if (IsLegalMove(row, col, color) == true) // if move legal add to the list
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
            if (cells[row, col].BackColor != bgColor)
                return false;

            // Check in all eight directions for opponent pieces that can be flipped
            foreach ((int, int) d in new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
            {
                int dr = d.Item1, dc = d.Item2;
                int r = row + dr, c = col + dc;

                // Check if an opponent piece in the current direction
                bool foundOpponentPiece = false;
                while (InRange(r, 0, BoardSize) && InRange(c, 0, BoardSize) &&
                        cells[r, c].BackColor != bgColor &&
                        cells[r, c].BackColor != PieceToColor(color))
                {
                    foundOpponentPiece = true;
                    r += dr;
                    c += dc;
                }

                // If an opponent piece and our own piece in this direction, the move is legal
                if 
                (
                    InRange(r, 0, BoardSize) && InRange(c, 0, BoardSize) &&
                    cells[r, c].BackColor == PieceToColor(color) && foundOpponentPiece
                )
                    return true;
            }

            return false; // No opponent pieces can be flipped in any direction, so the move is illegal
        }

        public static bool InRange(int num, int min, int max)
        {
            return num >= min && num < max;
        }

        public Color PieceToColor(Piece piece)
        {
            switch (piece)
            {
                case Piece.Black:
                    return Color.Black;
                case Piece.White:
                    return Color.White;
                case Piece.Empty:
                default:
                    return bgColor;
            }
        }
        private void GameEnd()
        {
            int blackCount = 0;
            int whiteCount = 0;
            string winner = "";

            // count the number of black and white pieces on the board
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (cells[row, col].BackColor == PieceToColor(Piece.Black))
                    {
                        blackCount++;
                    }
                    else if (cells[row, col].BackColor == PieceToColor(Piece.White))
                    {
                        whiteCount++;
                    }
                }
            }
            if (blackCount > whiteCount)
            {
                winner = "oh dear the computer beat you better luck next time";
            }
            if (whiteCount > blackCount)
            {
                winner = "congratulations you won!!! can you beat the next difficulty?";
            }
            if (whiteCount == blackCount)
            {
                winner = "its a ties. well played";
            }
            // display the total count of black and white pieces
            MessageBox.Show($"{winner}\nBlack pieces: {blackCount}\nWhite pieces: {whiteCount}", "Game Over");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();

            DifficultySet form2 = new DifficultySet();
            form2.Show();
        }

        private void Score()
        {
            int blackCount = 0;
            int whiteCount = 0;

            // count the number of black and white pieces on the board
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (cells[row, col].BackColor == PieceToColor(Piece.Black))
                    {
                        blackCount++;
                    }
                    else if (cells[row, col].BackColor == PieceToColor(Piece.White))
                    {
                        whiteCount++;
                    }
                } // update the textbox
            }
            ScoreBoard.Text = $"White pieces: {whiteCount}         Black pieces: { blackCount}";
        }

        private void ScoreBoard_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
