namespace ChangeColorTreadTest
{
    public partial class Form1 : Form
    {
        Button[] btns;
        Color color = Color.Red;

        public Form1()
        {
            InitializeComponent();

            radioButton1.Tag = Color.Red;
            radioButton2.Tag = Color.Magenta;
            radioButton3.Tag = Color.Cyan;
            radioButton4.Tag = Color.Green;
            radioButton5.Tag = Color.Yellow;
            radioButton6.Tag = Color.Blue;



            Thread w = new Thread(ChangeColor);
            w.Start();

            btns = new Button[]{
                button1,
                button2,
                button3,
                button5,
                button7,
                button8,
                button9,
                button10,
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChangeColor()
        {
            int index = 0;

            while (!IsDisposed)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            btns[i].BackColor = Color.White;
                        }
                        btns[index].BackColor = color;
                    });

                    index = (index + 1) % 8;
                    Thread.Sleep(100);
                }
                catch { }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            var r = (RadioButton)sender;
            if (r.Checked && (Color?)r.Tag != null)
                color = (Color)r.Tag;
        }
    }
}