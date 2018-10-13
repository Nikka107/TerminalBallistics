using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Terminal_Ballistics
{
    public partial class FrmBody : Form
    {
        public FrmBody()
        {
            InitializeComponent();

            //SaveFileDialog sfd = new SaveFileDialog();
            //OpenFileDialog ofd = new OpenFileDialog();
            //sfd.Filter = "Text File|*.txt|Body Design File|*.bds";
            //sfd.Title = "Save body design file";
            //ofd.Filter = "Text File|*.txt|Body design file|*.bds";
            //ofd.Title = "Open body design file";
        }

        /// <summary>
        /// *****События и всё остальное, что среда генерерует сама*****
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void lbd1_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("d1, м — диаметр цилиндра или \"левый\" диаметр конуса.");
        }

        private void lbd2_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("d2, м — \"правый\" диаметр конуса.");
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("l, м — длина эелемента.");
        }

        private void lbR_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("R, м — радиус оживала.");
        }

        private void lbID_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("ID — номер создаваемого элемента тела.");
        }

        private void lbPart_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("Элемент — выбор элемента тела из выпадающего списка (конус, оживало, цилиндр).");
        }

        private void lbFullLength_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("L, м — полная длина тела (вычисляется автоматически).");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("m, кг — полная масса тела.");
        }

        private void label19_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("Xc, м — координата центра масс тела. Положительное число, отсчитывается от донного среза тела.");
        }

        private void label17_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("Jp, кг/м2 — полярный момент инерции тела.");
        }

        private void label18_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("Je, кг/м2 — экваториальный момент инерции тела.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("d, м — калибр тела. Необходим для перевода величин в безразмерный вид (по умолчанию -- наибольший диаметр тела).");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("n * dα. Число разбиений по угловой координате (8...36).");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("n*dx. Коэффициент уменьшения шага по координате x на конусных и оживальных элементах тела.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnNewPart_Click(object sender, EventArgs e)
        {
            lbParts.SelectedIndex = -1;
            tbID.Text = (Body.BodyParts.Count + 1).ToString();
            if (Body.BodyParts.Count > 0)
                tbd1.Text = Body.BodyParts[Body.BodyParts.Count - 1].d2.ToString();
            else
                tbd1.Text = "0,0";
            tbl.Text = "0,0";
            tbR.Text = "0,0";
        }

        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbPart.SelectedItem.ToString())
            {
                case "Конус":
                    {
                        AllEnabled();
                        tbR.Enabled = false;
                        lbR.Enabled = false;
                        btnAccept.Enabled = true;
                        break;
                    }
                case "Цилиндр":
                    {
                        AllEnabled();
                        tbd2.Enabled = false;
                        lbd2.Enabled = false;
                        tbR.Enabled = false;
                        lbR.Enabled = false;
                        btnAccept.Enabled = true;
                        break;
                    }
                case "Оживало":
                    {
                        AllEnabled();
                        btnAccept.Enabled = true;
                        break;
                    }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Проверка правильности заполнения полей
            btnAccept_CheckValues();
            if (invalid)
                return;

            // Проверка, какую часть тела добавлять
            switch (cbPart.SelectedItem.ToString())
            {
                case "Конус":
                    {
                        // Проверка наличия парта с текущим введённым id
                        PartPresenceCheck();
                        // Добавление нового парта
                        Body.BodyParts.Add(new Cone(int.Parse(tbID.Text), "Cone", double.Parse(tbd1.Text), double.Parse(tbd2.Text),
                                                    double.Parse(tbl.Text)));
                        break;
                    }
                case "Цилиндр":
                    {
                        PartPresenceCheck();
                        Body.BodyParts.Add(new Cyl(int.Parse(tbID.Text), "Cylinder", double.Parse(tbd1.Text), double.Parse(tbl.Text)));
                        break;
                    }
                case "Оживало":
                    {
                        PartPresenceCheck();
                        Body.BodyParts.Add(new Ogive(int.Parse(tbID.Text), "Ogive", double.Parse(tbd1.Text),
                                                     double.Parse(tbd2.Text), double.Parse(tbR.Text), double.Parse(tbl.Text)));
                        break;
                    }
            }

            // Сборка, отрисовка, отключение кнопки
            BodyAssembling();
            BodyDraw();
            btnAccept.Enabled = false;

            // Изменение иконок с галочками
            if (Body.BodyParts.Count > 0)
            {
                picBoxTickBody.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done1 = true;
            }
            else
            {
                picBoxTickBody.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done1 = false;
            }

            if (done1 && done2)
                btnDone.Enabled = true;
            else
                btnDone.Enabled = false;

        }

        private void btnStructSpecif_Click(object sender, EventArgs e)
        {
            btnStructSpecif_CheckValues();
            if (invalid)
                return;

            Body.m = double.Parse(tbm.Text);
            Body.xc = double.Parse(tbxc.Text);
            Body.Jp = double.Parse(tbJp.Text);
            Body.Je = double.Parse(tbJe.Text);
            btnStructSpecif.Enabled = false;

            // Изменение иконки с галочками
            picBoxTickStruct.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
            done2 = true;
            if (done1 && done2)
                btnDone.Enabled = true;
            else
                btnDone.Enabled = false;
        }

        //private void tbCreateMesh_Click(object sender, EventArgs e)
        //{
        //    btnCreateMesh_CheckValues();
        //    if (invalid)
        //        return;
        //    RungeKutta.n_alpha = int.Parse(tbdalpha.Text);
        //    RungeKutta.n_x = int.Parse(tbndx.Text);

        //    btnCreateMesh.Enabled = false;
        //    picBoxTickMesh.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
        //    done3 = true;

        //    if (done1 && done2 && done3)
        //        btnDone.Enabled = true;
        //    else
        //        btnDone.Enabled = false;
        //}

        private void lbParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbParts.SelectedIndex == -1)
            {
                btnRemove.Enabled = false;
                return;
            }

            tbID.Text = Body.BodyParts[lbParts.SelectedIndex].id.ToString();
            tbd1.Text = Body.BodyParts[lbParts.SelectedIndex].d1.ToString();
            tbd2.Text = Body.BodyParts[lbParts.SelectedIndex].d2.ToString();
            tbl.Text = Body.BodyParts[lbParts.SelectedIndex].l.ToString();

            if (Body.BodyParts[lbParts.SelectedIndex] is Cone) cbPart.SelectedIndex = 0;
            if (Body.BodyParts[lbParts.SelectedIndex] is Ogive)
            {
                tbR.Text = Body.BodyParts[lbParts.SelectedIndex].R.ToString();
                cbPart.SelectedIndex = 1;
            }
            if (Body.BodyParts[lbParts.SelectedIndex] is Cyl) cbPart.SelectedIndex = 2;

            btnRemove.Enabled = true;
            btnAccept.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Body.BodyParts.RemoveAt(lbParts.SelectedIndex);
            BodyAssembling();
            BodyDraw();
            btnRemove.Enabled = false;
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = true;
        }

        private void tbm_TextChanged(object sender, EventArgs e)
        {
            btnStructSpecif.Enabled = true;
        }

        private void tbd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbID_Leave(object sender, EventArgs e)
        {
            while (tbID.Text.IndexOf('0') == 0)
                tbID.Text = tbID.Text.Remove(0, 1);
        }

        private void tbID_Validating(object sender, CancelEventArgs e)
        {
            if (tbID.Text == "")
            {
                invalid = true;
                tbID.BackColor = Color.MistyRose;
                t.Show("Недопустимый ID элемента тела.\nТребуется положительное целое число, отличное от нуля.", tbID, 0, tbID.Height + 1);
                e.Cancel = true;
            }
        }

        private void tbID_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbID.BackColor = Color.White;
            t.Hide(tbID);
        }

        private void tbd1_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbd1);
        }

        private void tbl_Validating(object sender, CancelEventArgs e)
        {
            if ((tbl.Text != "") && (double.Parse(tbl.Text) == 0.0))
            {
                invalid = true;
                tbl.BackColor = Color.MistyRose;
                t.Show("Длина элемента не может быть нулевой", tbl, 0, tbl.Height + 1);
                e.Cancel = true;
            }
        }

        private void tbd2_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbd2);
        }

        private void tbl_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbl);
        }

        private void tbR_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbR);
        }

        private void tbm_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbm);
        }

        private void tbxc_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbxc);
        }

        private void tbJp_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbJp);
        }

        private void tbJe_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbJe);
        }

        private void tbm_Validating(object sender, CancelEventArgs e)
        {
            tb_Validanig(tbm);
            if (invalid)
                e.Cancel = true;
        }

        private void tbxc_Validating(object sender, CancelEventArgs e)
        {
            tb_Validanig(tbxc);
            if (invalid)
                e.Cancel = true;
        }

        private void tbJp_Validating(object sender, CancelEventArgs e)
        {
            tb_Validanig(tbJp);
            if (invalid)
                e.Cancel = true;
        }

        private void tbJe_Validating(object sender, CancelEventArgs e)
        {
            tb_Validanig(tbJe);
            if (invalid)
                e.Cancel = true;
        }

        private void tbl_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbl.BackColor = Color.White;
            t.Hide(tbl);
        }

        private void tbm_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbm.BackColor = Color.White;
            t.Hide(tbm);
        }

        private void tbxc_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbxc.BackColor = Color.White;
            t.Hide(tbxc);
        }

        private void tbJp_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbJp.BackColor = Color.White;
            t.Hide(tbJp);
        }

        private void tbJe_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbJe.BackColor = Color.White;
            t.Hide(tbJe);
        }

        private void tbd_Validating(object sender, CancelEventArgs e)
        {
            tb_Validanig(tbm);
            if (invalid)
                e.Cancel = true;
        }

        private void tbd_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbJe.BackColor = Color.White;
            t.Hide(tbJe);
        }

        private void tbd_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbd);
            if (double.Parse(tbd.Text) != Body.d)
            {
                tbd.Font = new Font(this.Font, FontStyle.Bold);
                caliberTextLineAutoFill = false;
            }
            else
            {
                tbd.Font = new Font(this.Font, FontStyle.Regular);
                caliberTextLineAutoFill = true;
            }
        }



        /// <summary>
        /// *****Всякие дополнительные методы для простоты и функциональности работы формы*****
        /// </summary>
        #region
        // Переменные и объекты
        public bool caliberTextLineAutoFill = true;
        bool invalid, done1, done2;
        ToolTip t = new ToolTip();

        // Проверка значений в текстбоксах, в т.ч. корректировка текста и валидация
        private void btnAccept_CheckValues()
        {
            foreach (Control c in gbElement.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Enabled && c.Name != "tbd" && c.Name != "tbFullLength")
                    {
                        if (c == tbID)
                        {
                            while (tbID.Text.IndexOf('0') == 0)
                                tbID.Text = tbID.Text.Remove(0, 1);
                            continue;
                        }
                        tb_TextCorrector(c as TextBox);
                        tb_Validanig(c as TextBox);
                        if (invalid)
                            break;
                    }
                }
            }
        }
        // Проверка значений в текстбоксах, в т.ч. корректировка текста и валидация
        private void btnStructSpecif_CheckValues()
        {
            foreach (Control tb in gbMass.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Enabled)
                    {
                        tb_TextCorrector(tb as TextBox);
                        tb_Validanig(tb as TextBox);
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
        // Включение всех полей ввода размеров элементов
        private void AllEnabled()
        {
            tbd2.Enabled = true;
            lbd1.Enabled = true;
            tbd1.Enabled = true;
            lbd2.Enabled = true;
            tbl.Enabled = true;
            lbl.Enabled = true;
            tbR.Enabled = true;
            lbR.Enabled = true;
        }
        // "Сборка" тела
        private void BodyAssembling()
        {
            // Сортировка элементов в списке BodyParts по id
            List<Body> SortedBodyParts = Body.BodyParts.OrderBy(p => p.id).ToList();
            Body.BodyParts = SortedBodyParts;

            // Вычисление общей длины тела и определение максимального диаметра элемента тела
            Body.L = 0;
            foreach (Body p in Body.BodyParts)
            {
                Body.d = 0;
                if (p.d1 > Body.d || p.d2 > Body.d)
                    Body.d = Math.Max(p.d1, p.d2);
                Body.L += p.l;
            }
            // Вывод общей длины в текстовую строку
            tbFullLength.Text = Body.L.ToString();

            // Вывод максимального диаметра/калибра тела в текстовую строку
            if (caliberTextLineAutoFill)
            {
                tbd.Font = new Font(this.Font, FontStyle.Regular);
                tbd.Text = Body.d.ToString();
            }
            // Обновление текстбокса с диаметром
            tbd.Refresh();

            // Очистка ListBox
            lbParts.Items.Clear();
            // Запись элементов в ListBox
            foreach (Body p in Body.BodyParts)
            {
                lbParts.Items.Add(p.id + " " + p.name);
            }
        }
        // Отрисовка тела
        private void BodyDraw()
        {
            double yMax = 0.0, currl = 0.0, t0, t1;

            // Очистка Series от точек
            chartBodyDwg.Series[0].Points.Clear();
            // Диапазон по оси Х
            chartBodyDwg.ChartAreas[0].AxisX.Minimum = 0.0;
            chartBodyDwg.ChartAreas[0].AxisX.Maximum = Body.L;
            chartBodyDwg.ChartAreas[0].AxisX.Interval = Math.Round(Body.L / 10.0, 2);
            // Поехали писать и рисовать каждый элемент
            foreach (Body p in Body.BodyParts)
            {
                switch (p.name)
                {
                    case "Cone":
                        {
                            if (yMax < p.d2)
                                yMax = p.d2;
                            chartBodyDwg.ChartAreas[0].AxisY.Maximum = yMax;
                            chartBodyDwg.ChartAreas[0].AxisY.Minimum = -yMax / 2.0;
                            chartBodyDwg.ChartAreas[0].AxisY.Interval = yMax / 2.0;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d1);
                            currl += p.l;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d2);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            break;
                        }
                    case "Cylinder":
                        {
                            if (yMax < p.d2)
                                yMax = p.d2;
                            chartBodyDwg.ChartAreas[0].AxisY.Maximum = yMax;
                            chartBodyDwg.ChartAreas[0].AxisY.Minimum = -yMax / 2.0;
                            chartBodyDwg.ChartAreas[0].AxisY.Interval = yMax / 2.0;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d1);
                            currl += p.l;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d2);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            break;
                        }
                    case "Ogive":
                        {
                            if (yMax < p.d2)
                                yMax = p.d2;
                            chartBodyDwg.ChartAreas[0].AxisY.Maximum = yMax;
                            chartBodyDwg.ChartAreas[0].AxisY.Minimum = -yMax / 2.0;
                            chartBodyDwg.ChartAreas[0].AxisY.Interval = yMax / 2.0;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d1);
                            if (p.d1 <= p.d2)
                            {
                                t0 = Math.Acos((p.l + p.a) / p.R);
                                t1 = Math.Acos((p.a) / p.R);
                                for (double t = t0 + 0.01; t <= t1; t += 0.01)
                                    chartBodyDwg.Series[0].Points.AddXY(currl + p.l + p.a - p.R * Math.Cos(t), p.R * Math.Sin(t) - p.b);
                            }
                            else
                            {
                                t0 = Math.Acos((p.a) / p.R);
                                t1 = Math.Acos((p.l + p.a) / p.R);
                                for (double t = t0 - 0.01; t <= t1; t -= 0.01)
                                    chartBodyDwg.Series[0].Points.AddXY(currl - p.a + p.R * Math.Cos(t), p.R * Math.Sin(t) - p.b);
                            }
                            currl += p.l;
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0.5 * p.d2);
                            chartBodyDwg.Series[0].Points.AddXY(currl, 0);
                            break;
                        }
                }
            }
        }
        // Проерка наличия в теле парта с данным ID
        private void PartPresenceCheck()
        {
            int currPart = 0;
            foreach (Body p in Body.BodyParts)
            {
                if (int.Parse(tbID.Text) == p.id)
                {
                    Body.BodyParts.RemoveAt(currPart);
                    break;
                }
                currPart++;
            }
        }
        #endregion
    }
}
