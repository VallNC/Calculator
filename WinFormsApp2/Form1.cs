namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Variations varEnum = Variations.Plus;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "+";
            varEnum = Variations.Plus;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "-";
            varEnum = Variations.Minus;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "/";
            varEnum = Variations.Divide;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "*";
            varEnum = Variations.Multiply;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "^";
            varEnum = Variations.Power;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (varEnum)
                {
                    case Variations.Plus:
                        label2.Text = $"Answer for {textBox1.Text} + {textBox2.Text} = " + Math.Round(double.Parse(textBox1.Text) + double.Parse(textBox2.Text), 2);
                        break;
                    case Variations.Minus:
                        label2.Text = $"Answer for {textBox1.Text} - {textBox2.Text} = " + Math.Round(double.Parse(textBox1.Text) - double.Parse(textBox2.Text), 2);
                        break;
                    case Variations.Multiply:
                        label2.Text = $"Answer for {textBox1.Text} * {textBox2.Text} = " + Math.Round(double.Parse(textBox1.Text) * double.Parse(textBox2.Text), 2);
                        break;
                    case Variations.Divide:
                        label2.Text = $"Answer for {textBox1.Text} / {textBox2.Text} = " + Math.Round(double.Parse(textBox1.Text) / double.Parse(textBox2.Text), 2);
                        break;
                    case Variations.Power:
                        label2.Text = $"Answer for {textBox1.Text} ^ {textBox2.Text} = " + Math.Round(Math.Pow(double.Parse(textBox1.Text), double.Parse(textBox2.Text)), 2);
                        break;
                }
            }
            catch (Exception ex) { label2.Text = "Incorrect input."; }
        }
    }
    public enum Variations
    {
        Plus, Minus, Multiply, Divide, Power
    }
}
