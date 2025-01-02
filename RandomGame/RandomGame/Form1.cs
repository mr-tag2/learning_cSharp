namespace RandomGame
{
    public partial class Form1 : Form
    {
        static int tragetRandom;

        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            tragetRandom = random.Next(1, 1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value=Convert.ToInt32(textBox1.Text);
            if (value == tragetRandom)
                MessageBox.Show("Equls");
            else if (value < tragetRandom)
                MessageBox.Show("Higher");
            else if (value > tragetRandom)
                MessageBox.Show("Lower");
        }
    }
}
