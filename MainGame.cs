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
        public void userMove()
        {

        }
        public void AImove()
        {

        }
        public MainGame()
        {
            InitializeComponent();
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
