//namespace WinFormsApp10
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            double dama = Convert.ToDouble(textBox1.Text);
//            if (comboBox1.Text == "f2c")
//            {
//                label1.Text = Convert.ToString(dama - 32 * 5 / 32);

//            }
//            else
//            {
//                label1.Text = Convert.ToString(dama * 9 / 5 + 32);

//            }
//            listBox2.Items.Add(textBox1.Text + " " + comboBox1.Text + "=" + label1.Text);
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            int age = Convert.ToInt32(textBox3.Text);
//            if (textBox2.Text != "" && age > 1 && age < 120)
//            {
//                listBox1.Items.Add(textBox2.Text + " " + textBox3.Text);
//                listBox2.Items.Add("add " + textBox2.Text + " " + textBox3.Text);
//                textBox2.Clear();
//                textBox3.Clear();
//            }
//            else
//            {
//                MessageBox.Show("error");
//            }

//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            string t = listBox1.SelectedItem.ToString();
//            listBox1.Items.Remove(t);

//            listBox2.Items.Add("remove " + t);
//        }

//        private void button4_Click(object sender, EventArgs e)
//        {
//            label2.Text = DateTime.Now.ToString("yyy:MM:dd HH:mm:ss");
//            listBox2.Items.Add("update time " + label2.Text);
//        }
//    }
//}



using System;
using System.Windows.Forms;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ========== تبدیل دما ==========
        private void button1_Click(object sender, EventArgs e)
        {
            // اعتبارسنجی ورودی دما
            if (!double.TryParse(textBox1.Text, out double dama))
            {
                MessageBox.Show("لطفاً عدد معتبر وارد کنید!", "خطا");
                return;
            }

            if (comboBox1.Text == "f2c")
            {
                // اصلاح فرمول فارنهایت به سلسیوس: (F - 32) * 5/9
                double result = (dama - 32) * 5 / 9;
                label1.Text = Math.Round(result, 2).ToString();
                listBox2.Items.Add($"{dama} F → {result:0.00} C");
            }
            else
            {
                // فرمول سلسیوس به فارنهایت: (C × 9/5) + 32
                double result = (dama * 9 / 5) + 32;
                label1.Text = Math.Round(result, 2).ToString();
                listBox2.Items.Add($"{dama} C → {result:0.00} F");
            }
        }

        // ========== افزودن کاربر ==========
        private void button2_Click(object sender, EventArgs e)
        {
            // اعتبارسنجی نام و سن
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("نام کاربر را وارد کنید!", "خطا");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("سن باید بین ۱ تا ۱۲۰ باشد!", "خطا");
                return;
            }

            listBox1.Items.Add($"{textBox2.Text} ({age} سال)");
            listBox2.Items.Add($"افزودن: {textBox2.Text} ({age} سال)");
            textBox2.Clear();
            textBox3.Clear();
        }

        // ========== حذف کاربر ==========
        private void button3_Click(object sender, EventArgs e)
        {
            // بررسی انتخاب آیتم
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("لطفاً یک کاربر انتخاب کنید!", "خطا");
                return;
            }

            string selectedUser = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(selectedUser);
            listBox2.Items.Add($"حذف: {selectedUser}");
        }

        // ========== نمایش تاریخ و زمان ==========
        private void button4_Click(object sender, EventArgs e)
        {
            // اصلاح فرمت تاریخ (yyyy به جای yyy)
            string currentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            label2.Text = currentTime;
            listBox2.Items.Add($"زمان: {currentTime}");
        }
    }
}
