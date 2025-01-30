using System.Text.RegularExpressions;

namespace PrimeNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bool isNumber = int.TryParse(textBox1.Text, out int x);
            //if (isNumber)
            //{
            //    if (x == 2)
            //    {
            //        MessageBox.Show("number is prime");
            //    }
            //    else if (x % 2 == 0 || x == 1)
            //    {
            //        MessageBox.Show("number is not prime");
            //    }
            //    else
            //    {
            //        for (int i = 2; i < x; i++)
            //        {
            //            if (x % i == 0)
            //            {
            //                MessageBox.Show("number is not prime");
            //                return;
            //            }
            //        }
            //        MessageBox.Show("number is prime");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("input is Not number");
            //}

            try
            {
                int x = Convert.ToInt32(textBox1.Text);
                if (x == 2)
                {
                    MessageBox.Show("number is prime");
                }
                else if (x % 2 == 0||x==1)
                {
                    MessageBox.Show("number is not prime");
                }
                else
                {
                    for (int i = 2; i < x; i++)
                    {
                        if (x % i == 0)
                        {
                            MessageBox.Show("number is not prime");
                            return;
                        }
                    }
                    MessageBox.Show("number is prime");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("input is Not Valid");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string pattern = @"\D+";

            //textBox1.Text = Regex.Replace(textBox1.Text, pattern, "");
        }
    }
}
