using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initUser();
        }

        private void initUser()
        {
            var username = Registry.GetValue("HKEY_CURRENT_USER\\Reg-APP", "username", null);
            var password = Registry.GetValue("HKEY_CURRENT_USER\\Reg-APP", "password", null);
            if (username == null)
            {
                var subkey = Registry.CurrentUser.CreateSubKey("Reg-APP");
                username = "admin";
                password = "123qwe!";
                subkey.SetValue("username", username);
                subkey.SetValue("password", password);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            var username = Registry.GetValue("HKEY_CURRENT_USER\\Reg-APP", "username", null);
            var password = Registry.GetValue("HKEY_CURRENT_USER\\Reg-APP", "password", null);

            if (Convert.ToString(textBox1.Text) == Convert.ToString(username) && Convert.ToString(textBox2.Text) == Convert.ToString(password))
            {
                Main main = new Main();
                main.ShowDialog();

            }
            else MessageBox.Show("Password is Wrong");

        }

    }
}
