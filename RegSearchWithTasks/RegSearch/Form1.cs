using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cts;
        private List<string> list = new List<string>();

        RegistryKey[] keys =
        {
            Registry.ClassesRoot,
            Registry.CurrentConfig,
            Registry.CurrentUser,
            Registry.LocalMachine
        };

        private async void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            list.Clear();

            try
            {
                var start = DateTime.Now;

                
                var tasks = new List<Task>();
                foreach (var key in keys)
                {
                    tasks.Add(Task.Run(() => Work(key, textBox1.Text, cts.Token), cts.Token));
                }

                await Task.WhenAll(tasks);

                
                string str = string.Join(Environment.NewLine, list);
                str += $"\nC: {list.Count}\nD: {DateTime.Now.Subtract(start).TotalSeconds} seconds";

                MessageBox.Show(str);
                richTextBox1.Text = str;
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Search was canceled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Serach(RegistryKey node, string searchValue, bool isSubkey, CancellationToken token)
        {
            try
            {
                var values = isSubkey ? node.GetSubKeyNames() : node.GetValueNames();

                foreach (var value in values)
                {
                    token.ThrowIfCancellationRequested();

                    if (isSubkey)
                    {
                        var key = node.OpenSubKey(value);
                        if (key != null)
                        {
                            Serach(key, searchValue, true, token);
                            Serach(key, searchValue, false, token);
                        }
                    }
                    else
                    {
                        var val = Convert.ToString(node.GetValue(value, ""));
                        if (val == searchValue)
                        {
                            lock (list)
                            {
                                list.Add(Convert.ToString(node) + "\\" + value);
                            }
                        }
                    }
                }
            }
            catch
            {
                
            }
        }

        private void Work(RegistryKey root, string searchValue, CancellationToken token)
        {
            Serach(root, searchValue, true, token);
            Serach(root, searchValue, false, token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
