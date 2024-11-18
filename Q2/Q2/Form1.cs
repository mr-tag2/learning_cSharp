namespace Q2
{
    public partial class Form1 : Form
    {
        public static string radioValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioValue = radioButton.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            Form2 form2 = new Form2();
            form2.ShowDialog(); 

        }
    }
}
