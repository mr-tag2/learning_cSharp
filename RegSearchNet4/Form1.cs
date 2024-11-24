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

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        List<string> result = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void SearchRegistery(RegistryKey node, string searchKey)
        {
            if (node != null)
            {
                var values = node.GetValueNames();
                foreach (var item in values)
                {
                    var currentNodeVal = node.GetValue(item);

                    if(currentNodeVal != null && searchKey == currentNodeVal.ToString())
                    {
                        result.Add(node.ToString() + "/" + currentNodeVal.ToString());
                    }
                }

                var subNodes = node.GetSubKeyNames();
                foreach (var item in subNodes)
                {
                    try
                    {
                        var currentNode = node.OpenSubKey(item);
                        SearchRegistery(currentNode, searchKey);
                    }
                    catch { }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey[] roots = new RegistryKey[]
                {
                    Registry.CurrentUser,
                    Registry.LocalMachine,
                    Registry.ClassesRoot,
                    Registry.CurrentConfig,
                };
            var start = DateTime.Now;

            foreach (var item in roots)
            {
                SearchRegistery(item, textBox1.Text);
            }

            string res = string.Empty;
            foreach (var item in result)
            {
                res += item + Environment.NewLine;
            }
            res += "Count:" + result.Count + "\n";
            res += "Duration:" + DateTime.Now.Subtract(start).TotalSeconds;

            MessageBox.Show(res);
        }
    }
}
