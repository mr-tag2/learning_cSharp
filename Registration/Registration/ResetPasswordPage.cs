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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Registration
{
    public partial class ResetPasswordPage : Form
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var password = Registry.GetValue("HKEY_CURRENT_USER\\Reg-APP", "password", null);


            if (Convert.ToString(password) != Convert.ToString(text1.Text)|| Convert.ToString(text2.Text)=="")
                MessageBox.Show("Password is Wrong");
            else if (Convert.ToString(text2.Text) != Convert.ToString(text3.Text))
                MessageBox.Show("New Passwords is Not Equil");
            else 
              {

                Registry.SetValue("HKEY_CURRENT_USER\\Reg-APP", "password", text2.Text);
                MessageBox.Show("Password was Change"); 
            
            }

        }
    }
}
