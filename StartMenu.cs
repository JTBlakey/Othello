using System.Media;

namespace Othello
{
    public partial class StartMenu : Form
    {
        private SoundPlayer soundPlayer;
        public StartMenu()
        {
            InitializeComponent();

            soundPlayer = new SoundPlayer(Properties.Resources.ButtonClickSound);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            soundPlayer.Play();
            DifficultySet form2 = new DifficultySet();
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            soundPlayer.Play();
            Rules form3 = new Rules();
            form3.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.Hide();

            soundPlayer.Play();
            Settings form4 = new Settings();
            form4.Show();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}