using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal_Ballistics
{
    public partial class FrmInCond : Form
    {
        public FrmInCond()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            btnAccept_CheckValues();
            if (invalid)
                return;

            InitialConditions.V0 = double.Parse(tbVel.Text);
            InitialConditions.alpha_nu = double.Parse(tbAlpha.Text) * Math.PI / 180.0;
            InitialConditions.delta0 = double.Parse(tbDelta.Text) * Math.PI / 180.0;
            InitialConditions.nu0 = double.Parse(tbNu.Text) * Math.PI / 180.0;            
            InitialConditions.nu0_dot = double.Parse(tbnu0d.Text);
            InitialConditions.delta0_dot = double.Parse(tbdelta0d.Text);
            InitialConditions.phi0_dot = double.Parse(tbPhi.Text);

            RungeKutta.n_alpha = int.Parse(tb_nalpha.Text);
            RungeKutta.n_x = int.Parse(tb_nx.Text);
            RungeKutta.DeltaV = double.Parse(tbDV.Text);

            picBoxTickIC.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
            done1 = true;

            if (done1)
                btnDone.Enabled = true;

            btnAccept.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbVel_TextChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("V0, м/с — Скорость тела в момент встречи с преградой (начальная скорость)");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("αν, град — угол атаки");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("δ0, град — угол нутации");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("ν0, град — угол прецессии");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("ν0. , 1/c — угловая скорость прецессии");            
        }

        private void label18_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("δ0., 1/с — угловая скорость нутации");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("φ., 1 /с — угловая скорость собсттвенного вращения тела");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("Число разбиений по угловой координате (8...36)");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("Коэффициент увеличения шага по х на нецилиндрических частях тела (конус, оживало, притупления)");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            statusStrip.Items.Clear();
            statusStrip.Items.Add("Относительная остаточная скорость тела, по достижении которой расчёт останавливается");
        }

        private void tbVel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void tb_nalpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tb_nalpha_Leave(object sender, EventArgs e)
        {
            tb_IntegerFieldTextCorrector(tb_nalpha);
        }

        private void tb_nx_Leave(object sender, EventArgs e)
        {
            tb_IntegerFieldTextCorrector(tb_nx);
        }

        private void tbVel_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbVel);
        }

        private void tbAlpha_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbAlpha);
        }

        private void tbDelta_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbDelta);
        }

        private void tbNu_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbNu);
        }

        private void tbnu0d_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbnu0d);
        }

        private void tbdelta0d_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbdelta0d);
        }

        private void tbPhi_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbPhi);
        }

        private void tbDV_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbDV);
        }

        private void tbVel_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbVel.BackColor = Color.White;
            t.Hide(tbVel);
        }

        private void tbVel_Validating(object sender, CancelEventArgs e)
        {
            if ((tbVel.Text != "") && (double.Parse(tbVel.Text) == 0.0))
            {
                invalid = true;
                tbVel.BackColor = Color.MistyRose;
                t.Show("Начальная скорость тела не может быть нулевой", tbVel, 0, tbVel.Height + 1);
                e.Cancel = true;
            }
        }

        private void tb_nalpha_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tb_nalpha.BackColor = Color.White;
            t.Hide(tb_nalpha);
        }

        private void tb_nalpha_Validating(object sender, CancelEventArgs e)
        {
            if ((tb_nalpha.Text == "") || (double.Parse(tb_nalpha.Text) == 0))
            {
                invalid = true;
                tb_nalpha.BackColor = Color.MistyRose;
                t.Show("Значение не может быть пустым или нулевым", tb_nalpha, 0, tb_nalpha.Height + 1);
                e.Cancel = true;
            }
        }

        private void tb_nx_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tb_nx.BackColor = Color.White;
            t.Hide(tb_nx);
        }

        private void tb_nx_Validating(object sender, CancelEventArgs e)
        {
            if ((tb_nx.Text == "") || (double.Parse(tb_nx.Text) == 0))
            {
                invalid = true;
                tb_nx.BackColor = Color.MistyRose;
                t.Show("Значение не может быть пустым или нулевым", tb_nx, 0, tb_nx.Height + 1);
                e.Cancel = true;
            }
        }

        private void tbDV_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbDV.BackColor = Color.White;
            t.Hide(tbDV);
        }

        private void tbDV_Validating(object sender, CancelEventArgs e)
        {
            if ((tbDV.Text == "") || (double.Parse(tbDV.Text) == 0.0))
            {
                invalid = true;
                tbDV.BackColor = Color.MistyRose;
                t.Show("Значение не может быть пустым или нулевым", tbDV, 0, tbDV.Height + 1);
                e.Cancel = true;
            }
        }


        /// <summary>
        /// *****Всякие дополнительные методы для простоты и функциональности работы формы*****
        /// </summary>
        #region
        // Переменные и объекты
        bool invalid, done1;
        ToolTip t = new ToolTip();

        // Проверка значений в текстбоксах, в т.ч. корректировка текста и валидация
        private void btnAccept_CheckValues()
        {
            foreach (Control c in gbIC.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Enabled)
                    {
                        tb_TextCorrector(c as TextBox);
                        if (c == tbVel)
                            tb_Validanig(c as TextBox);
                    }
                }
            }

            foreach (Control c in gbControls.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Enabled)
                    {
                        if (c != tbDV)
                            tb_IntegerFieldTextCorrector(c as TextBox);
                        else
                            tb_TextCorrector(c as TextBox);
                        tb_Validanig(c as TextBox);
                        if (invalid)
                            break;
                    }
                }
            }
        }
        // Метод для проверки и коррекции заполнения текстбоксов со значениями
        private void tb_TextCorrector(TextBox tb)
        {
            // Заполнить пустой текст нулевым значением
            if (tb.Text == "")
            {
                tb.Text += "0,0";
                return;
            }

            // Заменить точку(и) на зяпятую(ые)
            tb.Text = tb.Text.Replace(".", ",");

            // Удалить все символы, начиная со второй запятой
            int commaInd = 0;
            foreach (char c in tb.Text)
            {
                if ((c == ',') && (commaInd != tb.Text.IndexOf(',')))
                {
                    tb.Text = tb.Text.Remove(commaInd);
                    break;
                }
                commaInd++;
            }

            // Поставить ",0" в конце, если символ "," не встречается
            if (tb.Text.IndexOf(',') == -1)
                tb.Text += ",0";

            // Поставить "0", если в конце стоит одна только запятая
            if (tb.Text.Length - 1 == tb.Text.LastIndexOf(','))
                tb.Text += "0";

            // Удалить незначащие нули в начале числа
            while (tb.Text.IndexOf('0') == 0)
            {
                if (tb.Text.IndexOf(',') != 1)
                    tb.Text = tb.Text.Remove(0, 1);
                else
                    break;
            }

            // Поставить 0 перед запятой, если больше перед ней чисел нет
            if (tb.Text.IndexOf(',') == 0)
                tb.Text = "0" + tb.Text;
        }

        private void tb_IntegerFieldTextCorrector(TextBox tb)
        {
            // Заполнить пустой текст нулевым значением
            if (tb.Text == "")
            {
                tb.Text += "0";
                return;
            }

            // Удалить незначащие нули в начале числа
            while (tb.Text.IndexOf('0') == 0)
            {
                tb.Text = tb.Text.Remove(0, 1);
            }
        }

        // Метод для проверки заполнения текстбоксов нулями или пустыми значениями
        private void tb_Validanig(TextBox tb)
        {
            if ((tb.Text == "") || (double.Parse(tb.Text) == 0.0))
            {
                tb.BackColor = Color.MistyRose;
                t.Show("Значение не может быть пустым или нулевым", tb, 0, tb.Height + 1);
                invalid = true;
            }
            else
                invalid = false;
        }


        #endregion


    }
}
