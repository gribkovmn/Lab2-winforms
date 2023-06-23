using System;

using System.Globalization;
using org.mariuszgromada.math.mxparser;

namespace Lab2_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            License.iConfirmNonCommercialUse("1");  // Уважаем лицензии
        }

        public double stringToDouble(string s)
        {
            // Разбираемся с точками и запятыми в разных локалях.
            double result;
            if (!double.TryParse(
                s.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result
            ))
            {
                throw new Exception();
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "ЛР №2 Ст. гр 19-ИБ411 Грибков М.Н.";
            // Для удобства отладки и проверки.
            this.textBox1.Text = "14.26";
            this.textBox3.Text = "-1.22";
            this.textBox5.Text = "3.5";
            this.textBox2.Text = "0";
            this.textBox4.Text = "0";
            this.textBox6.Text = "-2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, y, z, rawX, rawY, rawZ;
            int XPow, YPow, ZPow;

            try
            {
                rawX = stringToDouble(textBox1.Text.ToString());
                rawY = stringToDouble(textBox3.Text.ToString());
                rawZ = stringToDouble(textBox5.Text.ToString());

                if (!int.TryParse(textBox2.Text.ToString(), out XPow)) throw new Exception();
                if (!int.TryParse(textBox4.Text.ToString(), out YPow)) throw new Exception();
                if (!int.TryParse(textBox6.Text.ToString(), out ZPow)) throw new Exception();

                x = rawX * Math.Pow(10, XPow);
                y = rawY * Math.Pow(10, YPow);
                z = rawZ * Math.Pow(10, ZPow);

                var formula = new Function("Ex(x,y,z) = 2 * cos(x - pi/6) / (0.5 + sin(y)^2) * (1 + z^2 / (3 - z^2/5))");
                var _x = new Argument($"x", x);
                var _y = new Argument($"y", y);
                var _z = new Argument($"z", z);
                var expression = new Expression("Ex(x,y,z)", formula, _x, _y, _z);
                double result = expression.calculate();

                textBox7.Text = ""; // Очистка
                textBox7.AppendText($"Лабораторная работа №2{Environment.NewLine}Выполнил студент группы 19-ИБ411 Грибков М.Н.{Environment.NewLine}");
                if (XPow > 0)
                {
                    textBox7.AppendText($"x = {x} * 10^{XPow}{Environment.NewLine}");
                } else
                {
                    textBox7.AppendText($"x = {x}{Environment.NewLine}");
                }

                if (YPow > 0)
                {
                    textBox7.AppendText($"y = {y} * 10^{YPow}{Environment.NewLine}");
                }
                else
                {
                    textBox7.AppendText($"y = {y}{Environment.NewLine}");
                }

                if (ZPow > 0)
                {
                    textBox7.AppendText($"z = {z} * 10^{ZPow}{Environment.NewLine}");
                }
                else
                {
                    textBox7.AppendText($"z = {z}{Environment.NewLine}");
                }

                textBox7.AppendText($"t = {result}");

            } catch (Exception)
            {
                MessageBox.Show("Проверьте правильность заполнения формы");
            }
        }
    }
}