using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form2 : Form
    {
        List<string> result = new List<string>();
        Thread[] workers = new Thread[4];

        public Form2()
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

                    if (currentNodeVal != null && searchKey == currentNodeVal.ToString())
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

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Thread(new ParameterizedThreadStart(Work));
                workers[i].IsBackground = true;
                workers[i].Start(roots[i]);
            }

            Thread coordinator = new Thread(WaitUntilFinish);
            coordinator.IsBackground = true;
            coordinator.Start();
        }

        private void Work(object root)
        {
            try
            {
                RegistryKey convertedRoot = (RegistryKey)root;
                SearchRegistery(convertedRoot, textBox1.Text);
            }
            catch { }
        }

        private void WaitUntilFinish()
        {
            DateTime start = DateTime.Now;

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].Join();
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].IsAlive)
                    workers[i].Abort();
            }
        }
    }
}
