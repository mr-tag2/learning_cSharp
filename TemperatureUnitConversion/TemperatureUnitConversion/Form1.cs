namespace TemperatureUnitConversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        int value = Convert.ToInt32(textBox1.Text);
        //        string type = comboBox1.Text;

        //        if (type == "f2c")

        //            label1.Text = (value * 2).ToString();

        //        else if (type == "c2f")

        //            label1.Text = (value / 2).ToString();


        //        else label1.Text = "invalid";
        //    }
        //    catch 
        //    {
        //     label1.Text = "invalid";
        //    }


        //}


        private void button1_Click(object sender, EventArgs e)
        {

            double x = Convert.ToDouble(textBox1.Text);

            if (comboBox1.Text == "f2c")
                label1.Text = ((x - 32) * 5 / 9).ToString();
            else
                label1.Text = ((x * 9 / 5) + 32).ToString();

        }
        
    }
}
