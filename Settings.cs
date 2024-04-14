using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Settings : Form
    {
        private SoundPlayer soundPlayer;
        public Settings()
        {
            InitializeComponent();

            soundPlayer = new SoundPlayer(Properties.Resources.ButtonClickSound);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();

            soundPlayer.Play();
            StartMenu form1 = new StartMenu();
            form1.Show();
        }
    }
}
