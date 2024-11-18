using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RegWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey[] keys =
            {
                Registry.ClassesRoot,
                Registry.CurrentConfig,
                Registry.CurrentUser,
                Registry.LocalMachine
            };

            foreach (RegistryKey key in keys)
            {
                Serach(key, textBox1.Text, true);
                Serach(key, textBox1.Text, false);
            }

            listBox1.Items.AddRange((list).ToArray());
        }

        private void Serach(RegistryKey node, string searchValue, bool isSubkey)
        {

            try
            {
                var values = isSubkey ? node.GetSubKeyNames() : node.GetValueNames();

                foreach (var value in values)
                {
                    if (isSubkey)
                    {
                        var key = node.OpenSubKey(value);
                        if (key != null)
                        {
                            Serach(key, textBox1.Text, true);
                            Serach(key, textBox1.Text, false);
                        }
                    }
                    else
                    {
                        var val = Convert.ToString(node.GetValue(value, ""));
                        if (val == searchValue)
                        {
                            list.Add(Convert.ToString(node) + "\\" + value);

                        }
                    }
                }
            }
            catch { }
        }

    }
}
