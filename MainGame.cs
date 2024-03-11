

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
using static Othello.DifficultySet;
using static System.Windows.Forms.DataFormats;

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
                    cell.Click += UserMove; // adds an event handler to the press of a button
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
        public enum Piece
        {
            Empty,
            Black,
            White
        }

        private void UserMove(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Find the row and column indices of the clicked button
            int row = -1, col = -1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
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

            // Check if the clicked position represents a legal move
            if (row != -1 && col != -1 && IsLegalMove(row, col, Piece.White))
            {
                // Place the user's piece at the clicked position
                PlacePiece(row, col, Piece.White);

                // Update the UI or game board accordingly
                // Add any additional logic as needed
            }
            else
            {
                // Handle the case where the user clicked on an illegal move
                // For example, display a message indicating that the move is not allowed
            }
        }
        public void AImove(int difficulty)
        {
         
            if (difficulty == 1)
            {
                AImove1();
            }
            if (difficulty == 2)
            {
                AImove2();
            }
            if (difficulty == 3)
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

        }
        public void AImove3()
        {

        }
        public MainGame()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3); // Generates random number between 1 and 2 (inclusive)
            if (randomNumber == 1)
            {
                AImove(1);
            }   
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
            if (cells[row, col].BackColor != Color.FromArgb( 255, 252, 103, 54))
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
                    while (r >= 0 && r < 8 && c >= 0 && c < 8 && cells[r, c].BackColor != Color.FromArgb(255, 252, 103, 54) && cells[r, c].BackColor != ((color == Piece.Black) ? Color.Black : Color.White))
                    {
                        foundOpponentPiece = true;
                        r += dr;
                        c += dc;


                    }

                    // If an opponent piece and our own piece in this direction, the move is legal
                    if (r >= 0 && r < 8 && c >= 0 && c < 8 && foundOpponentPiece && cells[r, c].BackColor == ((color == Piece.Black) ? Color.Black : Color.White))
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
