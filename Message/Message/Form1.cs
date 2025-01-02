namespace Message
{
    public partial class Form1 : Form
    {
        static List<int> ints = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ints.Add(Convert.ToInt32(textBox1.Text));
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = ints.Count - 1; i >= 0; i--)
                str += " " + Convert.ToString(ints[i]);
            MessageBox.Show(str);




        }
    }
}
