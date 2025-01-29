using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FormUserInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (
            //       textBox1.Text == "" 
            //    || textBox2.Text == "" 
            //    || textBox3.Text == "" 
            //    || !textBox3.Text.Contains('@') 
            //    || !textBox3.Text.Contains('.')
            //    )
            //    MessageBox.Show("Data is wrong");
            //else
            //    MessageBox.Show("Data is Sent");
            if (
                   textBox1.Text != "" 
                && textBox2.Text != "" 
                && textBox3.Text != "" 
                && textBox3.Text.Contains('@') 
                && textBox3.Text.Contains('.')
                )
                MessageBox.Show("Data is Sent");
            else
                MessageBox.Show("Data is wrong");


        }
    }
}
