namespace Q1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            int x = Convert.ToInt16(t.Text);
            //MessageBox.Show(targetValue.ToString());
            if(Convert.ToInt16(label1.Text) < x)
            {
                label1.Text = x.ToString();

            }
            else
            {
                MessageBox.Show("wrong");
            }
        }
    }
}
