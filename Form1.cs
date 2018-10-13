using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RK = Terminal_Ballistics.RungeKutta;
using IC = Terminal_Ballistics.InitialConditions;


namespace Terminal_Ballistics
{
    public partial class FMain : Form
    {
        //Создаются экземпляры форм, вызываемых по кнопкам
        FrmBody fB = new FrmBody();
        FrmObstacle fO = new FrmObstacle();
        FrmInCond fInCond = new FrmInCond();
        FrmPlots fPlots = new FrmPlots();

        // Делегат-оповеститель происходящего в текстовый лог
        //public delegate void Informer(string msg);
        //Informer inf = new Informer(Message);

        //public static void Message(string msg)
        //{
            
        //}

        public FMain()
        {
            InitializeComponent();
        }

        private void TSMIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tПрограмма предназначена для численного решения задачи проникания " +
                "недеформируемых твёрдых тел (ударников) в сопротивляющиеся среды типа грунта, бетона и т.д.\n"+
                "       Результатом выполнения расчёта является трёхменая картина проникания тела в среду и возможность "+
                "построения графиков зависимостей физических величин от времени и друг от друга.", "О программе");
        }

        private void btnBody_Click(object sender, EventArgs e)
        {
            fB.ShowDialog();
        }

        private void btnObstruct_Click(object sender, EventArgs e) //obstruct, а не obstacle! 
        {
            fO.ShowDialog();
        }

        private void btnInCond_Click(object sender, EventArgs e)
        {
            fInCond.ShowDialog();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            rtbLog.AppendText("\nНачинаю расчёт.");
            rtbLog.AppendText("\nПреобразование входных данных, задание начальных условий...");

            //Перевод углов, скоростей, угл. скоростей
            //из поточной СК в связанную
            IC.Angles_WindToBody(ref Body.Theta, ref Body.Psi, ref Body.phi);
            IC.V_WindToBody(ref Body.Vcx, ref Body.Vcy, ref Body.Vcz);
            IC.Om_WindToBody(ref Body.Omx, ref Body.Omy, ref Body.Omz);
            Body.centeredPartID = Body.CenteredPartID();
            Body.lRear = Body.LRear();

            // Чиста листов перед расчётом
            RK.ListsClear();
            //Начальные приближения в массивах
            RK.InitApprox();

            // Временный код для каких-то тестов
            //lbBody.Text = RK.Vcx_List[0].ToString();
            //lbObstacle.Text = Body.Vcx.ToString();
            //lbIC.Text = IC.nu0_dot.ToString();
            //lbResults.Text = IC.phi0_dot.ToString();
            //lbTest5.Text = Obstacle.Layers[0].A.ToString();
            //lbTest6.Text = Body.Omz.ToString();

            //Расчёт и запись соответственно
            rtbLog.AppendText("\nВычисление...");
            RK.Computaion();
            rtbLog.AppendText("\nЗапись результатов в массивы...");
            RK.ListsToArrays();
            RK.Dimentionless();
            RK.DictionaryFill();
            rtbLog.AppendText("\nСохранение результатов в файл...");
            RK.Write();
            rtbLog.AppendText("\nГотово!");
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            fPlots.ShowDialog();
        }

        private void FMain_Activated(object sender, EventArgs e)
        {
            bool done1, done2, done3;
            string bodyEnding, layerEnding;

            if (Body.BodyParts.Count > 0 && Body.m > 0)
            {
                picBoxTickBody.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done1 = true;
            }
            else
            {
                picBoxTickBody.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done1 = false;
            }

            if (Obstacle.Layers.Count > 0)
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done2 = true;
            }
            else
            {
                picBoxTickObstacle.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done2 = false;
            }

            if (IC.V0 > 0)
            {
                picBoxTickIC.Image = Image.FromFile("../Pics/if_Tick_Mark.png");
                done3 = true;
            }
            else
            {
                picBoxTickIC.Image = Image.FromFile("../Pics/exclamation_point_mark.png");
                done3 = false;
            }

            if ((Body.BodyParts.Count - 1) % 10 == 0 && Body.BodyParts.Count != 11)
                bodyEnding = "а";
            else
                bodyEnding = "ов";

            lbBody.Text = "Тело состоит из " + Body.BodyParts.Count.ToString() + " элемент" + bodyEnding +
            ". Калибр, d = " + Body.d.ToString() + " м; Общая длина: " + Body.L.ToString() + " м.";

            if ((Obstacle.Layers.Count - 1) % 10 == 0 && Obstacle.Layers.Count != 11)
                layerEnding = "я";
            else
                layerEnding = "ёв";

            lbObstacle.Text = "Преграда состоит из " + Obstacle.Layers.Count.ToString() + " сло" + layerEnding +
                " общей толщиной H = " + Obstacle.H.ToString() + " м.";
            
            lbIC.Text = "Вектор значений начальных условий: " + IC.V0.ToString() + " " + IC.alpha_nu.ToString() + 
                " " + IC.delta0.ToString() + " " + IC.nu0.ToString() + " " + IC.phi0_dot.ToString() +
                " " + IC.delta0_dot.ToString() + " " + IC.nu0_dot.ToString();

            if (done1 && done2 && done3)
            {
                rtbLog.Text = "Расчёт готов к запуску";
                btnRun.Enabled = true;
            }
            else
                btnRun.Enabled = false;
        }
        /* int partNum;
* Цикл расчета (1851 - magic numger, см выше)
* Будет цикл с условием без него
* for (int i = 0; i < 1850; i++)
* {
*    // Обнуление всех эелементов массивов
*    //foreach (int num in Fx) Fx[num] = 0;
*    //foreach (int num in Fy) Fy[num] = 0;
*    //foreach (int num in Fz) Fz[num] = 0;
*    //foreach (int num in Mx) Mx[num] = 0;
*    //foreach (int num in My) My[num] = 0;
*    //foreach (int num in Mz) Mz[num] = 0;
*
*    // Расчет моментов и сил для тела
*    partNum = 0;
*    foreach (Body p in Body.BodyParts)
*    {
*        p.ForceMoment(ref Fx[partNum], ref Fy[partNum], ref Fz[partNum], ref Mx[partNum], ref My[partNum], ref Mz[partNum]);
*        Fx_Arr[i] += Fx[partNum];
*        Mx_Arr[i] += Fy[partNum];
*        Fy_Arr[i] += Fz[partNum];
*        My_Arr[i] += Mx[partNum];
*        Fz_Arr[i] += My[partNum];
*        Mz_Arr[i] += Mz[partNum];
*        partNum++;
*    }
*
*    //Поехал численный счёт
*    // Математические расчеты коэффициентов Рунге-Кутты (просто поверить)
*    k1_Vcx = f_Vcx(t_Arr[i], Vcy_Arr[i], Vcz_Arr[i], Omy_Arr[i], Omz_Arr[i], Fx_Arr[i], m);
*    k1_Vcy = f_Vcy(t_Arr[i], Vcx_Arr[i], Vcz_Arr[i], Omx_Arr[i], Omz_Arr[i], Fy_Arr[i], m);
*    k1_Vcz = f_Vcz(t_Arr[i], Vcx_Arr[i], Vcy_Arr[i], Omx_Arr[i], Omy_Arr[i], Fz_Arr[i], m);
*    k1_Omx = f_Omx(t_Arr[i], Jp, Mx_Arr[i]);
*    k1_Omy = f_Omy(t_Arr[i], Omx_Arr[i], Omz_Arr[i], Jp, Je, My_Arr[i]);
*    k1_Omz = f_Omz(t_Arr[i], Omx_Arr[i], Omy_Arr[i], Jp, Je, Mz_Arr[i]);
*    k1_X = f_X(t_Arr[i], RK.Vcx_Arr[i], RK.Vcy_Arr[i], RK.Vcz_Arr[i], RK.psi_Arr[i], RK.phi_Arr[i], RK.theta_Arr[i]);
*    k1_Y = f_Y(t_Arr[i], RK.Vcx_Arr[i], RK.Vcy_Arr[i], RK.Vcz_Arr[i], RK.psi_Arr[i], RK.phi_Arr[i], RK.theta_Arr[i]);
*    k1_Z = f_Z(t_Arr[i], RK.Vcx_Arr[i], RK.Vcy_Arr[i], RK.Vcz_Arr[i], RK.psi_Arr[i], RK.phi_Arr[i], RK.theta_Arr[i]);
*    k1_psi = f_psi(t_Arr[i], Omy_Arr[i], Omz_Arr[i], phi_Arr[i], theta_Arr[i]);
*    k1_phi = f_phi(t_Arr[i], Omx_Arr[i], Omy_Arr[i], Omz_Arr[i], phi_Arr[i], theta_Arr[i]);
*    k1_theta = f_theta(t_Arr[i], Omy_Arr[i], Omz_Arr[i], phi_Arr[i]);
*
*    k2_Vcx = RK.f_Vcx(RK.t_Arr[i] + dt / 2.0, RK.Vcy_Arr[i] + dt / 2.0 * k1_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k1_Vcz, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, RK.Fx_Arr[i], m);
*    k2_Vcy = RK.f_Vcy(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k1_Vcx, RK.Vcz_Arr[i] + dt / 2.0 * k1_Vcz, RK.Omx_Arr[i] + dt / 2.0 * k1_Omx, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, RK.Fy_Arr[i], m);
*    k2_Vcz = RK.f_Vcz(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k1_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k1_Vcy, RK.Omx_Arr[i] + dt / 2.0 * k1_Omx, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, RK.Fz_Arr[i], m);
*    k2_Omx = RK.f_Omx(RK.t_Arr[i] + dt / 2.0, Jp, RK.Mx_Arr[i]);
*    k2_Omy = RK.f_Omy(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k1_Omx, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, Jp, Je, RK.My_Arr[i]);
*    k2_Omz = RK.f_Omz(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k1_Omx, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, Jp, Je, RK.Mz_Arr[i]);
*    k2_X = RK.f_X(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k1_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k1_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k1_Vcz, RK.psi_Arr[i] + dt / 2 * k1_psi, RK.phi_Arr[i] + dt / 2 * k1_phi, RK.theta_Arr[i] + dt / 2 * k1_theta);
*    k2_Y = RK.f_Y(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k1_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k1_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k1_Vcz, RK.psi_Arr[i] + dt / 2 * k1_psi, RK.phi_Arr[i] + dt / 2 * k1_phi, RK.theta_Arr[i] + dt / 2 * k1_theta);
*    k2_Z = RK.f_Z(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k1_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k1_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k1_Vcz, RK.psi_Arr[i] + dt / 2 * k1_psi, RK.phi_Arr[i] + dt / 2 * k1_phi, RK.theta_Arr[i] + dt / 2 * k1_theta);
*    k2_psi = RK.f_psi(RK.t_Arr[i] + dt / 2.0, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, RK.phi_Arr[i] + dt / 2.0 * k1_phi, RK.theta_Arr[i] + dt / 2.0 * k1_theta);
*    k2_phi = RK.f_phi(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k1_Omx, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, RK.phi_Arr[i] + dt / 2.0 * k1_phi, RK.theta_Arr[i] + dt / 2.0 * k1_theta);
*    k2_theta = RK.f_theta(RK.t_Arr[i] + dt / 2.0, RK.Omy_Arr[i] + dt / 2.0 * k1_Omy, RK.Omz_Arr[i] + dt / 2.0 * k1_Omz, RK.phi_Arr[i] + dt / 2.0 * k1_phi);
*
*    k3_Vcx = RK.f_Vcx(RK.t_Arr[i] + dt / 2.0, RK.Vcy_Arr[i] + dt / 2.0 * k2_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k2_Vcz, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, RK.Fx_Arr[i], m);
*    k3_Vcy = RK.f_Vcy(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k2_Vcx, RK.Vcz_Arr[i] + dt / 2.0 * k2_Vcz, RK.Omx_Arr[i] + dt / 2.0 * k2_Omx, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, RK.Fy_Arr[i], m);
*    k3_Vcz = RK.f_Vcz(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k2_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k2_Vcy, RK.Omx_Arr[i] + dt / 2.0 * k2_Omx, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, RK.Fz_Arr[i], m);
*    k3_Omx = RK.f_Omx(RK.t_Arr[i] + dt / 2.0, Jp, RK.Mx_Arr[i]);
*    k3_Omy = RK.f_Omy(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k2_Omx, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, Jp, Je, RK.My_Arr[i]);
*    k3_Omz = RK.f_Omz(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k2_Omx, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, Jp, Je, RK.Mz_Arr[i]);
*    k3_X = RK.f_X(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k2_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k2_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k2_Vcz, RK.psi_Arr[i] + dt / 2 * k2_psi, RK.phi_Arr[i] + dt / 2 * k2_phi, RK.theta_Arr[i] + dt / 2 * k2_theta);
*    k3_Y = RK.f_Y(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k2_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k2_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k2_Vcz, RK.psi_Arr[i] + dt / 2 * k2_psi, RK.phi_Arr[i] + dt / 2 * k2_phi, RK.theta_Arr[i] + dt / 2 * k2_theta);
*    k3_Z = RK.f_Z(RK.t_Arr[i] + dt / 2.0, RK.Vcx_Arr[i] + dt / 2.0 * k2_Vcx, RK.Vcy_Arr[i] + dt / 2.0 * k2_Vcy, RK.Vcz_Arr[i] + dt / 2.0 * k2_Vcz, RK.psi_Arr[i] + dt / 2 * k2_psi, RK.phi_Arr[i] + dt / 2 * k2_phi, RK.theta_Arr[i] + dt / 2 * k2_theta);
*    k3_psi = RK.f_psi(RK.t_Arr[i] + dt / 2.0, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, RK.phi_Arr[i] + dt / 2.0 * k2_phi, RK.theta_Arr[i] + dt / 2.0 * k2_theta);
*    k3_phi = RK.f_phi(RK.t_Arr[i] + dt / 2.0, RK.Omx_Arr[i] + dt / 2.0 * k2_Omx, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, RK.phi_Arr[i] + dt / 2.0 * k2_phi, RK.theta_Arr[i] + dt / 2.0 * k2_theta);
*    k3_theta = RK.f_theta(RK.t_Arr[i] + dt / 2.0, RK.Omy_Arr[i] + dt / 2.0 * k2_Omy, RK.Omz_Arr[i] + dt / 2.0 * k2_Omz, RK.phi_Arr[i] + dt / 2.0 * k2_phi);
*
*    k4_Vcx = RK.f_Vcx(RK.t_Arr[i] + dt, RK.Vcy_Arr[i] + dt * k3_Vcy, RK.Vcz_Arr[i] + dt * k3_Vcz, RK.Omy_Arr[i] + dt * k3_Omy, RK.Omz_Arr[i] + dt * k3_Omz, RK.Fx_Arr[i], m);
*    k4_Vcy = RK.f_Vcy(RK.t_Arr[i] + dt, RK.Vcx_Arr[i] + dt * k3_Vcx, RK.Vcz_Arr[i] + dt * k3_Vcz, RK.Omx_Arr[i] + dt * k3_Omx, RK.Omz_Arr[i] + dt * k3_Omz, RK.Fy_Arr[i], m);
*    k4_Vcz = RK.f_Vcz(RK.t_Arr[i] + dt, RK.Vcx_Arr[i] + dt * k3_Vcx, RK.Vcy_Arr[i] + dt * k3_Vcy, RK.Omx_Arr[i] + dt * k3_Omx, RK.Omy_Arr[i] + dt * k3_Omy, RK.Fz_Arr[i], m);
*    k4_Omx = RK.f_Omx(RK.t_Arr[i] + dt, Jp, RK.Mx_Arr[i]);
*    k4_Omy = RK.f_Omy(RK.t_Arr[i] + dt, RK.Omx_Arr[i] + dt * k3_Omx, RK.Omz_Arr[i] + dt * k3_Omz, Jp, Je, RK.My_Arr[i]);
*    k4_Omz = RK.f_Omz(RK.t_Arr[i] + dt, RK.Omx_Arr[i] + dt * k3_Omx, RK.Omy_Arr[i] + dt * k3_Omy, Jp, Je, RK.Mz_Arr[i]);
*    k4_X = RK.f_X(RK.t_Arr[i] + dt, RK.Vcx_Arr[i] + dt * k3_Vcx, RK.Vcy_Arr[i] + dt * k3_Vcy, RK.Vcz_Arr[i] + dt * k3_Vcz, RK.psi_Arr[i] + dt * k3_psi, RK.phi_Arr[i] + dt * k3_phi, RK.theta_Arr[i] + dt * k3_theta);
*    k4_Y = RK.f_Y(RK.t_Arr[i] + dt, RK.Vcx_Arr[i] + dt * k3_Vcx, RK.Vcy_Arr[i] + dt * k3_Vcy, RK.Vcz_Arr[i] + dt * k3_Vcz, RK.psi_Arr[i] + dt * k3_psi, RK.phi_Arr[i] + dt * k3_phi, RK.theta_Arr[i] + dt * k3_theta);
*    k4_Z = RK.f_Z(RK.t_Arr[i] + dt, RK.Vcx_Arr[i] + dt * k3_Vcx, RK.Vcy_Arr[i] + dt * k3_Vcy, RK.Vcz_Arr[i] + dt * k3_Vcz, RK.psi_Arr[i] + dt * k3_psi, RK.phi_Arr[i] + dt * k3_phi, RK.theta_Arr[i] + dt * k3_theta);
*    k4_psi = RK.f_psi(RK.t_Arr[i] + dt, RK.Omy_Arr[i] + dt * k3_Omy, RK.Omz_Arr[i] + dt * k3_Omz, RK.phi_Arr[i] + dt * k3_phi, RK.theta_Arr[i] + dt * k3_theta);
*    k4_phi = RK.f_phi(RK.t_Arr[i] + dt, RK.Omx_Arr[i] + dt * k3_Omx, RK.Omy_Arr[i] + dt * k3_Omy, RK.Omz_Arr[i] + dt * k3_Omz, RK.phi_Arr[i] + dt * k3_phi, RK.theta_Arr[i] + dt * k3_theta);
*    k4_theta = RK.f_theta(RK.t_Arr[i] + dt, RK.Omy_Arr[i] + dt * k3_Omy, RK.Omz_Arr[i] + dt * k3_Omz, RK.phi_Arr[i] + dt * k3_phi);
*
*    // дифференциалы (метод Р-К)
*    d_Vcx = (dt / 6.0) * (k1_Vcx + 2.0 * k2_Vcx + 2.0 * k3_Vcx + k4_Vcx);
*    d_Vcy = (dt / 6.0) * (k1_Vcy + 2.0 * k2_Vcy + 2.0 * k3_Vcy + k4_Vcy);
*    d_Vcz = (dt / 6.0) * (k1_Vcz + 2.0 * k2_Vcz + 2.0 * k3_Vcz + k4_Vcz);
*    d_Omx = (dt / 6.0) * (k1_Omx + 2.0 * k2_Omx + 2.0 * k3_Omx + k4_Omx);
*    d_Omy = (dt / 6.0) * (k1_Omy + 2.0 * k2_Omy + 2.0 * k3_Omy + k4_Omy);
*    d_Omz = (dt / 6.0) * (k1_Omz + 2.0 * k2_Omz + 2.0 * k3_Omz + k4_Omz);
*    d_X = (dt / 6.0) * (k1_X + 2.0 * k2_X + 2.0 * k3_X + k4_X);
*    d_Y = (dt / 6.0) * (k1_Y + 2.0 * k2_Y + 2.0 * k3_Y + k4_Y);
*    d_Z = (dt / 6.0) * (k1_Z + 2.0 * k2_Z + 2.0 * k3_Z + k4_Z);
*    d_psi = (dt / 6.0) * (k1_psi + 2.0 * k2_psi + 2.0 * k3_psi + k4_psi);
*    d_phi = (dt / 6.0) * (k1_phi + 2.0 * k2_phi + 2.0 * k3_phi + k4_phi);
*    d_theta = (dt / 6.0) * (k1_theta + 2.0 * k2_theta + 2.0 * k3_theta + k4_theta);
*
*    // Переход к следующей яячейке массива
*    RK.Vcx_Arr[i + 1] = RK.Vcx_Arr[i] + d_Vcx;
*    RK.Vcy_Arr[i + 1] = RK.Vcy_Arr[i] + d_Vcy;
*    RK.Vcz_Arr[i + 1] = RK.Vcz_Arr[i] + d_Vcz;
*    RK.Omx_Arr[i + 1] = RK.Omx_Arr[i] + d_Omx;
*    RK.Omy_Arr[i + 1] = RK.Omy_Arr[i] + d_Omy;
*    RK.Omz_Arr[i + 1] = RK.Omz_Arr[i] + d_Omz;
*    RK.X_Arr[i + 1] = RK.X_Arr[i] + d_X;
*    RK.Y_Arr[i + 1] = RK.Y_Arr[i] + d_Y;
*    RK.Z_Arr[i + 1] = RK.Z_Arr[i] + d_Z;
*    RK.psi_Arr[i + 1] = RK.psi_Arr[i] + d_psi;
*    RK.phi_Arr[i + 1] = RK.phi_Arr[i] + d_phi;
*    RK.theta_Arr[i + 1] = RK.theta_Arr[i] + d_theta;
*
*    RK.t_Arr[i + 1] = RK.t_Arr[i] + dt;
*
*    RK.Vc_Arr[i + 1] = Math.Sqrt(RK.Vcx_Arr[i + 1] * RK.Vcx_Arr[i + 1] + RK.Vcy_Arr[i + 1] * RK.Vcy_Arr[i + 1] + RK.Vcz_Arr[i + 1] * RK.Vcz_Arr[i + 1]);
*
*    IC.Vcx = RK.Vcx_Arr[i + 1];
*    IC.Vcy = RK.Vcy_Arr[i + 1];
*    IC.Vcz = RK.Vcz_Arr[i + 1];
*    IC.Omx = RK.Omx_Arr[i + 1];
*    IC.Omy = RK.Omy_Arr[i + 1];
*    IC.Omz = RK.Omz_Arr[i + 1];
*    IC.XcFixed = RK.X_Arr[i + 1];
*    IC.Psi = RK.psi_Arr[i + 1];
*    IC.phi = RK.phi_Arr[i + 1];
*    IC.Theta = RK.theta_Arr[i + 1];
*/
    }
}
