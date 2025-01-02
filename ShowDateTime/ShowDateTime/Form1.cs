namespace ShowDateTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            label1.Text = (DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
    }
}
