namespace Lab_2_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double CalculateSum(int a)
        {
            double result = 0;
            for (int i = 1; i <= 3; i++)
            {
                result += a / (i * (i + 1));
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(textBox1.Text);
            double sum = CalculateSum(a);
            textBox2.Text = sum.ToString();
        }
    }
}
