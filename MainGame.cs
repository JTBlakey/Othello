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
            
            board.RowCount = 8;
            board.ColumnCount = 8;
            cells = new Button[8, 8];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button cell = new Button();
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0);
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.FlatAppearance.BorderSize = 1;
                    cell.Click += Cell_Click;
                    board.Controls.Add(cell, col, row);
                    cells[row, col] = cell;
                }
            }
            int middleLocation = (8 / 2) - 1;
            board[middleLocation, middleLocation] = Piece.Black;

            GameBoard[middleLocation + 1, middleLocation + 1].Sign = (char)eCellStatus.Black;
            GameBoard[middleLocation + 1, middleLocation + 1].Name = i_Players.FirstPlayer;
            GameBoard[middleLocation + 1, middleLocation].Sign = (char)eCellStatus.White;
            GameBoard[middleLocation + 1, middleLocation].Name = i_Players.SecondPlayer;
            GameBoard[middleLocation, middleLocation + 1].Sign = (char)eCellStatus.White;
            GameBoard[middleLocation, middleLocation + 1].Name = i_Players.SecondPlayer;
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            // Handle cell click event (e.g., player move)
            Button clickedCell = sender as Button;
            // Your logic to handle player moves and update the game board goes here
        }
        public void userMove()
        {

        }
        public void AImove()
        {

        }
        public MainGame()
        {
            InitializeComponent();
            InitializeGameBoard();

        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            
            Random num = new Random();
            int randomNumber = num.Next(1, 3); // 1 is white so player goes first
            int player = randomNumber;         // 2 is black so player goes second
            if (player == 1)
            {
                userMove();
            }
            else
            {
                AImove();
            }

        }

        private void Quit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
