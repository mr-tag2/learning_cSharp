using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace RegSearch
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

            var start = DateTime.Now;

            Thread[] threads = new Thread[4];
            for (int i = 0; i < keys.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(Work));
                threads[i].IsBackground = true;
                threads[i].Start(keys[i]);

            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }


            //foreach (RegistryKey key in keys)
            //{
            //    Serach(key, textBox1.Text, true);
            //    Serach(key, textBox1.Text, false);
            //}


            string str = string.Empty;
            foreach (var item in list)
            {
                str += item + Environment.NewLine;
            }

            str += "C : " + list.Count + Environment.NewLine;
            str += "D : " + DateTime.Now.Subtract(start).TotalSeconds;

            MessageBox.Show(str);

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

        private void Work(object root)
        {
            try
            {
                RegistryKey convertedRoot = (RegistryKey)root;
                Serach(convertedRoot, textBox1.Text, true);
                Serach(convertedRoot, textBox1.Text, false);

            }
            finally
            {

            }
        }

    }
}
