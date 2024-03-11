using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class MainGame : Form
    {
        
        private Button[,] cells;
        
        private void InitializeGameBoard()
        {
            
            board.RowCount = 8; // set up board size
            board.ColumnCount = 8;
            cells = new Button[8, 8]; 

            for (int row = 0; row < 8; row++) // create a button for each cell in board 
            {
                for (int col = 0; col < 8; col++)
                {
                    Button cell = new Button(); //Creates new button
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0); // make sure button takes up whole space of cell
                    cell.FlatStyle = FlatStyle.Flat; //remove 3d effect of button
                    cell.FlatAppearance.BorderSize = 1; //adds a border to the button
                    cell.Click += Cell_Click; // adds an event handler to the press of a button
                    board.Controls.Add(cell, col, row); // adds button to the speciffied cell
                    cells[row, col] = cell; // stores a referance to the button in an array: cells
                }
            }
            int middleLocation = 4; //set up four starting pieces
            board.Controls[middleLocation - 1 + (middleLocation - 1) * 8].BackColor = Color.White;
            board.Controls[middleLocation + (middleLocation - 1) * 8].BackColor = Color.Black;
            board.Controls[middleLocation - 1 + middleLocation * 8].BackColor = Color.Black;
            board.Controls[middleLocation + middleLocation * 8].BackColor = Color.White;
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            // Handle cell click event (e.g., player move)
            Button clickedCell = sender as Button;
            // Your logic to handle player moves and update the game board goes here
        }
        public enum Piece
        {
            Empty,
            Black,
            white
        }

        public void UserMove()
        {

        }
        public void AImove()
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
        public MainGame()
        {
            InitializeComponent();
            InitializeGameBoard();

        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            
            AImove();
            

        }

        private void Quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void PlacePiece(int row, int col, Piece color)
        {
            // Update the cell colour to the player's colour
            cells[row, col].BackColor = (color == Piece.Black) ? Color.Black : Color.White;

            // Update the game board representation (if necessary)
            // You might have additional logic here depending on how you're representing the game board
        }
        private List<Point> GetLegalMoves(Piece color)
        {
            List<Point> legalMoves = new List<Point>();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {

                    if (IsLegalMove(row,col,color) == true)
                    {
                        legalMoves.Add(new Point(row, col));
                    }
                }
            }
            return legalMoves;
        }

        private bool IsLegalMove(int row, int col,Piece color)
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
                    while (r >= 0 && r < 8 && c >= 0 && c < 8 && cells[r, c].BackColor != Color.FromArgb(255, 252, 103, 54) && cells[r, c].BackColor != Color.Black && cells[r, c].BackColor != Color.White)
                    {
                        foundOpponentPiece = true;
                        r += dr;
                        c += dc;
                    }

                    // If an opponent piece and our own piece in this direction, the move is legal
                    if (r >= 0 && r < 8 && c >= 0 && c < 8 && foundOpponentPiece && cells[r, c].BackColor == (color == Piece.Black ? Color.White : Color.Black))
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
