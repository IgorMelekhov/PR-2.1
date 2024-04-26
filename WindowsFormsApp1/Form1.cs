using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1m.Validating += textBox1m_Validating;
            textBox2n.Validating += textBox2n_Validating;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1m.Clear();
            textBox2n.Clear();
            answer.Clear();
            textBoxInterval.Clear();    
        }

        private void button1Create_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                int a = 1, b = 1;
                int m = Convert.ToInt32(textBox1m.Text);
                int n = Convert.ToInt32(textBox2n.Text);
                int count = 0;
                List<int> fibonacci = new List<int>();
                if (m > n)
                {
                    MessageBox.Show("m не может быть больше n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1m.Clear();
                    textBox2n.Clear();
                    answer.Clear();
                    textBoxInterval.Clear();
                }
                else if (m == 0)
                {
                    MessageBox.Show("m не может быть 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1m.Clear();
                    textBox2n.Clear();
                    answer.Clear();
                    textBoxInterval.Clear();
                }
                else {
                    for (int i = 0; i <= n; i++)
                    {
                        fibonacci.Add(a);
                        int c = a + b;
                        a = b;
                        b = c;
                    }
                    string fibonacci2 = string.Join(",", fibonacci);
                    answer.Text = fibonacci2;
                    foreach (var num2 in fibonacci)
                    {
                        if (num2 >= m && num2 <= n && num2 % 3 == 0)
                        {
                            count++;
                        }
                    }
                    textBoxInterval.Text=count.ToString();
                }                          
            }catch 
            {
                MessageBox.Show("Введены неверные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1m.Clear();
                textBox2n.Clear();
                answer.Clear();
                textBoxInterval.Clear();
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }
        private void textBox1m_Validating(object sender, CancelEventArgs e)
        {
            double inputNumber;
            if (String.IsNullOrEmpty(textBox1m.Text))
            { errorProvider1.SetError(textBox1m, "Поле не может быть пустым !"); }
            else if (!double.TryParse(textBox1m.Text, out inputNumber))
            { errorProvider1.SetError(textBox1m, "В поле должно быть введено число!"); }
            else
            { errorProvider1.Clear(); }
        }
        private void textBox2n_Validating(object sender, CancelEventArgs e)
        {
            double inputNumber;
            if (String.IsNullOrEmpty(textBox2n.Text))
            { errorProvider1.SetError(textBox2n, "Поле не может быть пустым !"); }
            else if (!double.TryParse(textBox2n.Text, out inputNumber))
            { errorProvider1.SetError(textBox2n, "В поле должно быть введено число!"); }
            else
            { errorProvider1.Clear(); }
        }
    }
}
