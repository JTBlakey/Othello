namespace Othello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Difficulty form2 = new Difficulty();
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Rules form3 = new Rules();
            form3.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.Hide();

            Settings form4 = new Settings();
            form4.Show();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}