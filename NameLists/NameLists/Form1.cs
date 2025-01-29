namespace NameLists
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(textBox1.Text);
            textBox1.Text = "";
        }
    }
}

