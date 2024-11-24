using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace RegSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread[] threads = new Thread[4];
        private List<string> list = new List<string>();
        private CancellationTokenSource cts;

        RegistryKey[] keys =
        {
            Registry.ClassesRoot,
            Registry.CurrentConfig,
            Registry.CurrentUser,
            Registry.LocalMachine
        };

        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            list.Clear();

            var start = DateTime.Now;

            for (int i = 0; i < keys.Length; i++)
            {
                int index = i;
                threads[i] = new Thread(() => Work(keys[index], textBox1.Text, cts.Token))
                {
                    IsBackground = true
                };
                threads[i].Start();
            }

            Thread finishThread = new Thread(() =>
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i]?.Join();
                }

                string result = string.Join(Environment.NewLine, list);
                result += $"\nC: {list.Count}";
                result += $"\nD: {DateTime.Now.Subtract(start).TotalSeconds} seconds";

                Invoke(new Action(() =>
                {
                    richTextBox1.Text = result;
                }));
            })
            {
                IsBackground = true
            };
            finishThread.Start();
        }

        private void Search(RegistryKey node, string searchValue, bool isSubKey, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;

            try
            {
                var values = isSubKey ? node.GetSubKeyNames() : node.GetValueNames();

                foreach (var value in values)
                {
                    if (token.IsCancellationRequested) return;

                    if (isSubKey)
                    {
                        var key = node.OpenSubKey(value);
                        if (key != null)
                        {
                            Search(key, searchValue, true, token);
                            Search(key, searchValue, false, token);
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
            catch { }
        }

        private void Work(RegistryKey root, string searchValue, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;

            try
            {
                Search(root, searchValue, true, token);
                Search(root, searchValue, false, token);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i] != null && threads[i].IsAlive)
                {
                    threads[i].Join();
                }
            }
        }
    }
}
