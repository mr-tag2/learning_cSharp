using System.Threading.Tasks;

namespace TimeShow
{
    public partial class Form1 : Form
    {
        private DateTime lastUpdate;

        public Form1()
        {
            InitializeComponent();
            //lastUpdate = DateTime.Now;
            //Application.Idle += OnApplicationIdle;

            //label1.Text = DateTime.Now.ToString("HH:mm:ss");
            Thread w = new Thread(UpdateDateTime);
            w.IsBackground = true;
            w.Start();


        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    label1.Text = DateTime.Now.ToString("HH:mm:ss");


        //}


        //private async void Form1_Load(object sender, EventArgs e)
        //{
        //    while (true)
        //    {
        //        await Task.Delay(1000);
        //        label1.Text = DateTime.Now.ToString();
        //    }
        //}

        //private void OnApplicationIdle(object sender, EventArgs e)
        //{
        //    if ((DateTime.Now - lastUpdate).TotalSeconds >= 1)
        //    {
        //        label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        //        lastUpdate = DateTime.Now;
        //    }
        //}

        private void UpdateDateTime()
        {
            while (true)
            //while (!IsDisposed) if IsBackground is False
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                try
                {
                    Invoke((MethodInvoker)delegate { label1.Text = time; });

                }
                catch { }

            }

        }
    }
}
