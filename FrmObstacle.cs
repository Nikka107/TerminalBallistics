using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Terminal_Ballistics
{
    public partial class FrmObstacle : Form
    {
        public FrmObstacle()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Проверка правильности заполнения полей
            btnAccept_CheckValues();
            if (invalid)
                return;

            LayerPresenceCheck();
            Obstacle.Layers.Add(new Obstacle(int.Parse(tbID.Text), tbName.Text, double.Parse(tbObsA.Text), double.Parse(tbObsB.Text),
                double.Parse(tbObsC.Text), double.Parse(tbObsD.Text), double.Parse(tbObsMu.Text), double.Parse(tbObsh.Text)));
            ObstacleAssembling();
            ObstacleDraw();
            // Делаем фон всех текстбоксов белым
            foreach (Control c in gbStressEquasions.Controls)
            {
                if (c is TextBox)
                    c.BackColor = Color.White;
            }
            // Ставим галочку/крестик если преграда есть или её нет
            if (Obstacle.Layers.Count > 0)
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done1 = true;
            }
            else
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done1 = false;
            }
            // Разрешаем/не разрешаем кнопку "Готово"
            if (done1)
                btnDone.Enabled = true;
            else btnDone.Enabled = false;

            btnAccept.Enabled = false;
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bnNewLayer_Click(object sender, EventArgs e)
        {
            lbObstacle.SelectedIndex = -1;
            tbID.Text = (Obstacle.Layers[Obstacle.Layers.Count - 1].id + 1).ToString();
            tbName.Text = "Новый слой";
            tbObsA.Text = "0,0";
            tbObsB.Text = "0,0";
            tbObsC.Text = "0,0";
            tbObsD.Text = "0,0";
            tbObsMu.Text = "0,0";
            tbObsh.Text = "0,0";
        }

        private void lbObstacle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbObstacle.SelectedIndex == -1)
            {
                btnRemove.Enabled = false;
                return;
            }

            tbID.Text = Obstacle.Layers[lbObstacle.SelectedIndex].id.ToString();
            tbName.Text = Obstacle.Layers[lbObstacle.SelectedIndex].name;
            tbObsA.Text = Obstacle.Layers[lbObstacle.SelectedIndex].A.ToString();
            tbObsB.Text = Obstacle.Layers[lbObstacle.SelectedIndex].B.ToString();
            tbObsC.Text = Obstacle.Layers[lbObstacle.SelectedIndex].C.ToString();
            //tbObsD.Text = Obstacle.Layers[lbObstacle.SelectedIndex].D.ToString();
            tbObsMu.Text = Obstacle.Layers[lbObstacle.SelectedIndex].Mu.ToString();
            tbObsh.Text = Obstacle.Layers[lbObstacle.SelectedIndex].h.ToString();

            btnRemove.Enabled = true;
            btnAccept.Enabled = false;
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Obstacle.Layers.RemoveAt(lbObstacle.SelectedIndex);
            ObstacleAssembling();

            // Ставим галочку/крестик если преграда есть или её нет
            if (Obstacle.Layers.Count > 0)
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done1 = true;
            }
            else
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done1 = false;
            }

            // Разрешаем/не разрешаем кнопку "Готово"
            if (done1)
                btnDone.Enabled = true;
            else btnDone.Enabled = false;

            btnRemove.Enabled = false;
        }

        private void lbID_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("ID — номер создаваемого слоя преграды.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("A, кг/м3 — коэффициент инерционной составляющей в уравнении сопротивления преграды sigma = Av2 + Bv + C.");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("B, Па*с/м — коэффициент вязкостной составляющей в уравнении сопротивления преграды sigma = Av2 + Bv + C.");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("C, Па — коэффициент прочностной составляющей в уравнении сопротивления преграды sigma = Av2 + Bv + C.");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("D — коэффициент, учитывающий степень инерционного расширения преграды (D = 0 — полное отсутствие расширения, D = 1 — для воды).");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("μ — коэффициент трения материала преграды о корпус тела: tau = μ*sigma.");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("h, м — толщина слоя преграды.");
        }

        private void lbObsFullH_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("H, м — общая толщина преграды (вычисляется автоматически).");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("ρ, кг/м3 — плотность материала преграды.");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("G, МПа — модуль сдвига.");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("Y0, МПа — сцепление.");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("μв — коэффициент внутреннего трения.");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            StatusStrip.Items.Clear();
            StatusStrip.Items.Add("α — пористость.");            
        }

        private void btnRecount_Click(object sender, EventArgs e)
        {
            double A, B, C;
            double Ro = double.Parse(tbRo.Text),
                   G = double.Parse(tbG.Text),
                   Y0 = double.Parse(tbY0.Text),
                   Muv = double.Parse(tbMuv.Text),
                   alpha = double.Parse(tbAlpha.Text);
            double Gb = 10000, // МПа
                   Y0b = 100,  // МПа
                   Rob = 2600; // кг/м3

            foreach (Control c in gbPhysChars.Controls)
            {
                if (c is TextBox)
                    tb_TextCorrector(c as TextBox);
            }  

            A = (1.23 + 0.238 * alpha - 1.6 * alpha * alpha + (0.0846 + 0.00123 * Math.Log(G / Gb) -
                0.0586 * Muv - (0.267 - 0.00087 * Math.Log(G / Gb) - 0.19 * Muv) * alpha) * Muv *
                (23 + Math.Log(G / Gb))) * Ro;

            B = ((0.984 * Math.Log(G / Gb) + 5.87) * Muv + ((0.74 - 4.31 * Muv) * Math.Log(G / Gb) -
                26.45 * Muv + 17) * alpha) * Muv * (Math.Log(G / Gb) + 23) * 0.001 * Ro * Math.Sqrt(Gb / Rob);

            C = (0.0158 * Math.Log(G / Gb) + 0.192 - 0.0367 * Y0 / Y0b - 0.145 * alpha) *
                (Math.Log(G / Gb) + 23) * Y0;

            tbObsA.Text = A.ToString();
            tbObsA.BackColor = Color.LightSkyBlue;

            tbObsB.Text = B.ToString();
            tbObsB.BackColor = Color.LightSkyBlue;

            tbObsC.Text = C.ToString();
            tbObsC.BackColor = Color.LightSkyBlue;

            btnCoeffCount.Enabled = false;
            btnAccept.Enabled = true;
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

        private void tbObsA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void tbObsA_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsA);
        }

        private void tbObsB_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsB);
        }

        private void tbObsC_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsC);
        }

        private void tbObsD_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsD);
        }

        private void tbObsMu_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsMu);
        }

        private void tbObsh_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbObsh);
        }

        private void tbObsh_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbObsh.BackColor = Color.White;
            t.Hide(tbObsh);
        }

        private void tbObsh_Validating(object sender, CancelEventArgs e)
        {
            if ((tbObsh.Text != "") && (double.Parse(tbObsh.Text) == 0.0))
            {
                invalid = true;
                tbObsh.BackColor = Color.MistyRose;
                t.Show("Глубина слоя преграды не может быть нулевой", tbObsh, 0, tbObsh.Height + 1);
                e.Cancel = true;
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            invalid = false;
            tbName.BackColor = Color.White;
            t.Hide(tbName);
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Text == "")
            {
                invalid = true;
                tbName.BackColor = Color.MistyRose;
                t.Show("Слой преграды обязан иметь наименование", tbName, 0, tbName.Height + 1);
                e.Cancel = true;
            }

            foreach (Obstacle l in Obstacle.Layers)
            {
                if (tbName.Text == l.name.ToString())
                {
                    invalid = true;
                    tbName.BackColor = Color.MistyRose;
                    t.Show("Наименования слоёв преграды не должны повторяться", tbName, 0, tbName.Height + 1);
                    e.Cancel = true;
                }
            }
        }

        private void tbRo_TextChanged(object sender, EventArgs e)
        {
            btnCoeffCount.Enabled = true;
        }

        private void tbRo_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbRo);
        }

        private void tbG_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbG);
        }

        private void tbY0_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbY0);
        }

        private void tbMuv_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbMuv);
        }

        private void tbAlpha_Leave(object sender, EventArgs e)
        {
            tb_TextCorrector(tbAlpha);
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
            foreach (Control c in gbStressEquasions.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Enabled)
                    {
                        if (c == tbID)
                        {
                            while (tbID.Text.IndexOf('0') == 0)
                                tbID.Text = tbID.Text.Remove(0, 1);
                        }
                        else if (c == tbName)
                            continue;
                        else
                            tb_TextCorrector(c as TextBox);

                        if (c == tbID || c == tbObsh)
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

        private void ObstacleAssembling()
        {
            // Сортировка элементов в списке Layers по id
            List<Obstacle> SortedObstacleLayers = Obstacle.Layers.OrderBy(o => o.id).ToList();
            Obstacle.Layers = SortedObstacleLayers;

            // Вывод элементов из списка Layers в ListBox
            lbObstacle.Items.Clear();
            foreach (Obstacle o in Obstacle.Layers)
            {
                lbObstacle.Items.Add(o.id + " " + o.name);
            }

            // Вычисление общей глубины преграды H
            Obstacle.H = 0;
            foreach (Obstacle o in Obstacle.Layers)
            {
                Obstacle.H += o.h;
            }
            tbObsFullH.Text = Obstacle.H.ToString();
        }

        private void ObstacleDraw()
        {
            chartObstacle.Series.Clear();
            chartObstacle.ChartAreas[0].AxisX.Minimum = 0.0;
            chartObstacle.ChartAreas[0].AxisX.Maximum = 1.0;
            chartObstacle.ChartAreas[0].AxisY.Minimum = -1.1 * Obstacle.H;
            chartObstacle.ChartAreas[0].AxisY.Maximum = 0.1 * Obstacle.H;
            chartObstacle.ChartAreas[0].AxisY.Interval = Math.Round(Obstacle.H / 10.0, 2);
            //double currh = 0;
            foreach (Obstacle o in Obstacle.Layers)
            {
                //currh += o.h;
                Series ser = new Series(o.name);
                ser.ChartType = SeriesChartType.StackedArea;
                chartObstacle.Series.Add(ser);
                ser.Points.AddXY(0, -o.h);
                ser.Points.AddXY(1, -o.h);
            }
        }

        private void LayerPresenceCheck()
        {
            foreach (Obstacle o in Obstacle.Layers)
            {
                if (int.Parse(tbID.Text) == o.id)
                {
                    Obstacle.Layers.RemoveAt(o.id - 1);
                    break;
                }
            }
        }

        #endregion
    }
}
