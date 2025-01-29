namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double dama = Convert.ToDouble(textBox1.Text);
            if (comboBox1.Text == "f2c")
            {
                label1.Text = Convert.ToString(dama - 32 * 5 / 32);
               
            }
            else
            {
                label1.Text = Convert.ToString(dama * 9 / 5 + 32);
              
            }
            listBox2.Items.Add(textBox1.Text + " " + comboBox1.Text + "=" + label1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(textBox3.Text);
            if (textBox2.Text != "" && age > 1 && age < 120)
            {
                listBox1.Items.Add(textBox2.Text + " " + textBox3.Text);
                listBox2.Items.Add("add " + textBox2.Text + " " + textBox3.Text);
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("error");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(t);

            listBox2.Items.Add("remove " + t);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyy:MM:dd HH:mm:ss");
            listBox2.Items.Add("update time " + label2.Text);
        }
    }
}
