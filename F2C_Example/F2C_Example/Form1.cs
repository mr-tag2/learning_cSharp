namespace F2C_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox2.Text);
            string c = (comboBox1.Text);
            if (c == "F2C")
                textBox3.Text = Convert.ToString(((x - 32) * 5 / 9));
            else
                textBox3.Text = Convert.ToString((x * 9 / 5) + 32);


            //double x = Convert.ToDouble(textBox2.Text);

            //if (comboBox1.Text == "F2C")
            //    textBox3.Text = ((x - 32) * 5 / 9).ToString();
            //else
            //    textBox3.Text = ((x * 9 / 5) + 32).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
