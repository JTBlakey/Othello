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
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public partial class DifficultySet : Form
    {
        public static Difficulty CurrentDifficulty { get; set; }

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
        public DifficultySet()
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
            CurrentDifficulty = Difficulty.Easy;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            CurrentDifficulty = Difficulty.Medium;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            CurrentDifficulty = Difficulty.Hard;
            this.Hide();

            MainGame form3 = new MainGame();
            form3.Show();
        }
    }
}
