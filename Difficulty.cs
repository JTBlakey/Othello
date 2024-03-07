using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Difficulty : Form
    {
        public int difficulty = 0;

        public Difficulty()
        {
            InitializeComponent();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Easy_Click(object sender, EventArgs e)
        {
            difficulty = 1;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            difficulty = 2;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            difficulty = 3;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }
    }
}
