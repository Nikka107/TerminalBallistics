using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using IC = Terminal_Ballistics.InitialConditions;


//Метод Рунге-Кутты

namespace Terminal_Ballistics
{
    class RungeKutta
    {
        static double Vc;

        // Шаг по времени
        public static double dt { get; set; }
        // Число разбиейний по углу
        public static int n_alpha { get; set; }
        // Число разбиений по длине элемента тела
        //public static double dx { get; set; }
        // Коэффицент уменьшения шага на конусе/оживале/притуплении/дне
        public static int n_x { get; set; }
        // Относительная остаточная скорость
        public static double DeltaV { get; set; }
        // Пределы интегрирования по длине для каждого элемента тела
        public static double l1 { get; set; }
        public static double l2 { get; set; }

        // Массивы для записи значений при расссчете
        public static int ArrLength = 18002;
        // Для расчёта числа шагов по времени
        static int i;

        // Списки, чтоб считать
        public static List<double> t_List = new List<double>();

        public static List<double> Vcx_List = new List<double>();
        public static List<double> Vcy_List = new List<double>();
        public static List<double> Vcz_List = new List<double>();
        public static List<double> Vc_List = new List<double>();

        public static List<double> Omx_List = new List<double>();
        public static List<double> Omy_List = new List<double>();
        public static List<double> Omz_List = new List<double>();
        public static List<double> Om_List = new List<double>();

        public static List<double> X_List = new List<double>();
        public static List<double> Y_List = new List<double>();
        public static List<double> Z_List = new List<double>();

        public static List<double> psi_List = new List<double>();
        public static List<double> phi_List = new List<double>();
        public static List<double> theta_List = new List<double>();

        public static List<double> Fx_List = new List<double>();
        public static List<double> Fy_List = new List<double>();
        public static List<double> Fz_List = new List<double>();
        public static List<double> F_List = new List<double>();

        public static List<double> Mx_List = new List<double>();
        public static List<double> My_List = new List<double>();
        public static List<double> Mz_List = new List<double>();
        public static List<double> M_List = new List<double>();

        // Массивы, чтоб выводить
        public static double[] t_Arr;
                    
        public static double[] Vcx_Arr;
        public static double[] Vcy_Arr;
        public static double[] Vcz_Arr;
        public static double[] Vc_Arr;

        public static double[] Omx_Arr;
        public static double[] Omy_Arr;
        public static double[] Omz_Arr;
        public static double[] Om_Arr;

        public static double[] X_Arr;
        public static double[] Y_Arr;
        public static double[] Z_Arr;

        public static double[] psi_Arr;
        public static double[] phi_Arr;
        public static double[] theta_Arr;

        public static double[] Fx_Arr;
        public static double[] Fy_Arr;
        public static double[] Fz_Arr;
        public static double[] F_Arr;

        public static double[] Mx_Arr;
        public static double[] My_Arr;
        public static double[] Mz_Arr;

        public static double[] M_Arr;

        public static Dictionary<string, double[]> Axis = new Dictionary<string, double[]>();

        /* Ниже записаны 12 уравнений движения тв. тела с 6-ю степенями свободы.
         * Все они записаны в виде d(..)/dt = (...) и возвращают, соответственно, d(..)/dt
         * Обозначения переменных следующие:
         * Vc - скорости центра масс
         * Om - угловая скорость
         * F - сила
         * m - масса
         * M - момент силы
         * Jp - полярный медведь инерции
         * Je - экваториальный момент инерции
         * X Y Z - координаты в неподвижной СК
         * x y z - координаты в связанной СК
         * phi psi theta - углы */
        // Уравнения движения ЦМ в проекциях на ССК
        public static double f_Vcx(double _t, double _Vcy, double _Vcz, double _Omy, double _Omz, double Fx, double m)
        {
            return (Fx / m) + (_Omz * _Vcy) - (_Omy * _Vcz);
        }
        public static double f_Vcy(double _t, double _Vcx, double _Vcz, double _Omx, double _Omz, double Fy, double m)
        {
            return Fy / m + (_Omx * _Vcz) - (_Omz * _Vcx);
        }
        public static double f_Vcz(double _t, double _Vcx, double _Vcy, double _Omx, double _Omy, double Fz, double m)
        {
            return (Fz / m) + (_Omy * _Vcx) - (_Omx * _Vcy);
        }

        // Уравнения вращательного движения тела в проекциях на ССК
        public static double f_Omx(double _t, double Jp, double Mx)
        {
            return Mx / Jp;
        }
        public static double f_Omy(double _t, double _Omx, double _Omz, double Jp, double Je, double My)
        {
            return My / Je + (Je - Jp) * _Omx * _Omz / Je;
        }
        public static double f_Omz(double _t, double _Omx, double _Omy, double Jp, double Je, double Mz)
        {
            return Mz / Je - (Je - Jp) * _Omx * _Omy / Je;
        }

        // Уравнения положения ЦМ тела в НСК
        public static double f_X(double _t, double _Vcx, double _Vcy, double _Vcz, double _phi, double _theta)
        {
            return _Vcx * Math.Cos(_theta) + _Vcy * Math.Sin(_phi) * Math.Sin(_theta) + _Vcz * Math.Cos(_phi) * Math.Sin(_theta);
        }
        public static double f_Y(double _t, double _Vcx, double _Vcy, double _Vcz, double _psi, double _phi, double _theta)
        {
            return _Vcx * Math.Sin(_psi) * Math.Sin(_theta) + _Vcy * (Math.Cos(_psi) * Math.Cos(_phi) - Math.Sin(_psi) * Math.Sin(_phi) * Math.Cos(_theta))
                + _Vcz * (-Math.Cos(_psi) * Math.Sin(_phi) - Math.Sin(_psi) * Math.Cos(_phi) * Math.Cos(_theta));
        }
        public static double f_Z(double _t, double _Vcx, double _Vcy, double _Vcz, double _psi, double _phi, double _theta)
        {
            return -_Vcx * Math.Cos(_psi) * Math.Sin(_theta) + _Vcy * (Math.Sin(_psi) * Math.Cos(_phi) + Math.Cos(_psi) * Math.Sin(_phi) * Math.Cos(_theta))
                + _Vcz * (-Math.Sin(_psi) * Math.Sin(_phi) + Math.Cos(_psi) * Math.Cos(_phi) * Math.Cos(_theta));
        }

        // Кинематиечкие уравнения Эйлера
        public static double f_psi(double _t, double _Omy, double _Omz, double _phi, double _theta)
        {
            return _Omy * Math.Sin(_phi) / Math.Sin(_theta) + _Omz * Math.Cos(_phi) / Math.Sin(_theta);
        }
        public static double f_phi(double _t, double _Omx, double _Omy, double _Omz, double _phi, double _theta)
        {
            return _Omx - _Omy * Math.Sin(_phi) / Math.Tan(_theta) - _Omz * Math.Cos(_phi) / Math.Tan(_theta);
        }
        public static double f_theta(double _t, double _Omy, double _Omz, double _phi)
        {
            return _Omy * Math.Cos(_phi) - _Omz * Math.Sin(_phi);
        }

        // Чистит списки перед следующим расчётом
        public static void ListsClear()
        {
            t_List.Clear();
            Vcx_List.Clear();
            Vcy_List.Clear();
            Vcz_List.Clear();
            Vc_List.Clear();
            Omx_List.Clear();
            Omy_List.Clear();
            Omz_List.Clear();
            Om_List.Clear();
            X_List.Clear();
            Y_List.Clear();
            Z_List.Clear();
            psi_List.Clear();
            phi_List.Clear();
            theta_List.Clear();
            Fx_List.Clear();
            Fy_List.Clear();
            Fz_List.Clear();
            F_List.Clear();
            Mx_List.Clear();
            My_List.Clear();
            Mz_List.Clear();
            M_List.Clear();
        }
        // Задает начальные приближения для нулевой итерации
        // Начальные приближения равны начальным условия
        public static void InitApprox()
        {
            t_List.Add(0.0);

            Vcx_List.Add(Body.Vcx);
            Vcy_List.Add(Body.Vcy);
            Vcz_List.Add(Body.Vcz);
            Vc_List.Add(Math.Sqrt(Body.Vcx * Body.Vcx + Body.Vcy * Body.Vcy + Body.Vcz * Body.Vcz)); // Абсолютная скорость

            Omx_List.Add(Body.Omx);
            Omy_List.Add(Body.Omy);
            Omz_List.Add(Body.Omz);
            Om_List.Add(Math.Sqrt(Body.Omx * Body.Omx + Body.Omy * Body.Omy + Body.Omz * Body.Omz)); // Абсолютная угловая скорость

            X_List.Add(IC.XInitial(Body.Theta));
            Y_List.Add(0.0);
            Z_List.Add(0.0);

            psi_List.Add(Body.Psi);
            phi_List.Add(Body.phi);
            theta_List.Add(Body.Theta);

            //Body.Xc = X_Arr[0]; // Координата ЦМ в неподвижной СК
        }

        public static void ListsToArrays()
        {
            t_Arr = t_List.ToArray();

            Vcx_Arr = Vcx_List.ToArray();
            Vcy_Arr = Vcy_List.ToArray();
            Vcz_Arr = Vcz_List.ToArray();
            Vc_Arr = Vc_List.ToArray();

            Omx_Arr = Omx_List.ToArray();
            Omy_Arr = Omy_List.ToArray();
            Omz_Arr = Omz_List.ToArray();
            Om_Arr = Om_List.ToArray();

            X_Arr = X_List.ToArray();
            Y_Arr = Y_List.ToArray();
            Z_Arr = Z_List.ToArray();

            psi_Arr = psi_List.ToArray();
            phi_Arr = phi_List.ToArray();
            theta_Arr = theta_List.ToArray();

            Fx_Arr = Fx_List.ToArray();
            Fy_Arr = Fy_List.ToArray();
            Fz_Arr = Fz_List.ToArray();
            F_Arr = F_List.ToArray();

            Mx_Arr = Mx_List.ToArray();
            My_Arr = My_List.ToArray();
            Mz_Arr = Mz_List.ToArray();
            M_Arr = M_List.ToArray();
        }

        public static void Dimentionless()
        {
            for (int i = 0; i < t_Arr.Length - 1; i++)
            {
                t_Arr[i] = t_Arr[i] * 500.0 / 0.03;

                Vcx_Arr[i] /= 500.0;
                Vcy_Arr[i] /= 500.0;
                Vcz_Arr[i] /= 500.0;
                Vc_Arr[i] /= 500.0;

                Omx_Arr[i] = Omx_Arr[i] * 0.03 / 500.0;
                Omy_Arr[i] = Omy_Arr[i] * 0.03 / 500.0;
                Omz_Arr[i] = Omz_Arr[i] * 0.03 / 500.0;
                //Om_Arr[i] = Om_Arr[i] * 0.03 / 500.0;

                X_Arr[i] /= 0.03;
                Y_Arr[i] /= 0.03;
                Z_Arr[i] /= 0.03;

                psi_Arr[i] = psi_Arr[i] * 180.0 / Math.PI;
                phi_Arr[i] = phi_Arr[i] * 180.0 / Math.PI;
                theta_Arr[i] = theta_Arr[i] * 180.0 / Math.PI;

                Fx_Arr[i] = Fx_Arr[i] / (Body.m * 9.81);
                Fy_Arr[i] = Fy_Arr[i] / (Body.m * 9.81);
                Fz_Arr[i] = Fz_Arr[i] / (Body.m * 9.81);
                //F_Arr[i] = F_Arr[i] / (Body.m * 9.81);

                Mx_Arr[i] = Mx_Arr[i] / (Body.m * 9.81 * 0.03);
                My_Arr[i] = My_Arr[i] / (Body.m * 9.81 * 0.03);
                Mz_Arr[i] = Mz_Arr[i] / (Body.m * 9.81 * 0.03);
            }
        }

        public static void DictionaryFill()
        {
            Axis.Add("t", t_Arr);
            Axis.Add("X", X_Arr);
            Axis.Add("Y", Y_Arr);
            Axis.Add("Z", Z_Arr);
            Axis.Add("Vx", Vcx_Arr);
            Axis.Add("Vy", Vcy_Arr);
            Axis.Add("Vz", Vcz_Arr);
            Axis.Add("V", Vc_Arr);
            Axis.Add("ωx", Omx_Arr);
            Axis.Add("ωy", Omy_Arr);
            Axis.Add("ωz", Omz_Arr);
            Axis.Add("ω", Om_Arr);
            Axis.Add("Fx", Fx_Arr);
            Axis.Add("Fy", Fy_Arr);
            Axis.Add("Fz", Fz_Arr);
            Axis.Add("F", F_Arr);
            Axis.Add("Mx", Mx_Arr);
            Axis.Add("My", My_Arr);
            Axis.Add("Mz", Mz_Arr);
            Axis.Add("M", M_Arr);
            Axis.Add("θ", theta_Arr);
            Axis.Add("Ψ", psi_Arr);
            Axis.Add("φ", phi_Arr);
            //XAxis.Add(rbx_, RK.x_Arr);
        }

        // Расссчет по методу Рунге-Кутты
        // Инициализируются статические переменные: дифференциалы искомых величин и
        // коэффициенты k1, k2, k3, k4 для каждой искомой величины
        static double d_Vcx, d_Vcy, d_Vcz, d_Omx, d_Omy, d_Omz, d_X, d_Y, d_Z, d_psi, d_phi, d_theta;
        static double k1_Vcx, k1_Vcy, k1_Vcz, k1_Omx, k1_Omy, k1_Omz, k1_X, k1_Y, k1_Z, k1_psi, k1_phi, k1_theta,
            k2_Vcx, k2_Vcy, k2_Vcz, k2_Omx, k2_Omy, k2_Omz, k2_X, k2_Y, k2_Z, k2_psi, k2_phi, k2_theta,
            k3_Vcx, k3_Vcy, k3_Vcz, k3_Omx, k3_Omy, k3_Omz, k3_X, k3_Y, k3_Z, k3_psi, k3_phi, k3_theta,
            k4_Vcx, k4_Vcy, k4_Vcz, k4_Omx, k4_Omy, k4_Omz, k4_X, k4_Y, k4_Z, k4_psi, k4_phi, k4_theta;

        public static void Computaion()
        {
            // Инициализация массивов под силовые характеристики
            // Размер массива соответствует количеству элементов тела
            double[] Fx = new double[Body.BodyParts.Count];
            double[] Fy = new double[Body.BodyParts.Count];
            double[] Fz = new double[Body.BodyParts.Count];
            double[] Mx = new double[Body.BodyParts.Count];
            double[] My = new double[Body.BodyParts.Count];
            double[] Mz = new double[Body.BodyParts.Count];
            // Первый шаг по t            
            i = 0;
            Vc = Vc_List[i];
            // Цикл для расчёта. Заменить на цикл while пока не будут выполняться условия.
            // ДОБАВТЬ ЕЩЁ УСЛОВИЯ К ОСТАНОВКЕ РАСЧЁТА (по вылету из преграды)
            // Сделать автоизменяемый шаг по времени
            while (Vc > IC.V0 * DeltaV)  // IC.V0 / (2 * IC.V0)
            {
                // Вычисление шага по времени
                dt = 0.001 / Body.Vcx;
                if (dt > 0.0001) dt = 0.0001;

                // Вычисление пределов интегрирования по длине элемента тела
                // Начальные приближения (возврат к началу тела после каждой итерации по времени)
                l1 = Body.L - Body.xc;
                l2 = Body.L - Body.xc;

                // Задание следующего элемента = 0 в списках, чтобы можно было делать операции вида += значение
                Fx_List.Add(0.0);
                Fy_List.Add(0.0);
                Fz_List.Add(0.0);
                Mx_List.Add(0.0);
                My_List.Add(0.0);
                Mz_List.Add(0.0);

                // Вычисление пределов интегрирования в зависимости от положения элемента относительно ЦМ
                foreach (Body p in Body.BodyParts)
                {
                    // Если элемент расположен перед или за элементом с ЦМ
                    if (p.id != Body.centeredPartID)
                    {
                        l1 = l2;
                        l2 -= p.l;
                    }
                    // Если элемент содержит ЦМ
                    else if (p.id == Body.centeredPartID)
                    {
                        l1 = l2;
                        l2 = -Body.xc + Body.lRear;
                    }

                    // Вызывается метод для расчёта силовых характеристик на текущем элементе
                    p.ForceCharsComputation(ref Fx[p.id - 1], ref Fy[p.id - 1], ref Fz[p.id - 1], ref Mx[p.id - 1], ref My[p.id - 1], ref Mz[p.id - 1]);
                    
                    // Силовые характеристики элемента прибавляются к общим силовым характеристикам тела в массивы
                    Fx_List[i] += Fx[p.id - 1];
                    Fy_List[i] += Fy[p.id - 1];
                    Fz_List[i] += Fz[p.id - 1];
                    Mx_List[i] += Mx[p.id - 1];
                    My_List[i] += My[p.id - 1];
                    Mz_List[i] += Mz[p.id - 1];
                }

                // Поехал численный счёт
                // Математические расчеты коэффициентов Рунге-Кутты
                k1_Vcx = f_Vcx(t_List[i], Vcy_List[i], Vcz_List[i], Omy_List[i], Omz_List[i], Fx_List[i], Body.m);
                k1_Vcy = f_Vcy(t_List[i], Vcx_List[i], Vcz_List[i], Omx_List[i], Omz_List[i], Fy_List[i], Body.m);
                k1_Vcz = f_Vcz(t_List[i], Vcx_List[i], Vcy_List[i], Omx_List[i], Omy_List[i], Fz_List[i], Body.m);
                k1_Omx = f_Omx(t_List[i], Body.Jp, Mx_List[i]);
                k1_Omy = f_Omy(t_List[i], Omx_List[i], Omz_List[i], Body.Jp, Body.Je, My_List[i]);
                k1_Omz = f_Omz(t_List[i], Omx_List[i], Omy_List[i], Body.Jp, Body.Je, Mz_List[i]);
                k1_X = f_X(t_List[i], Vcx_List[i], Vcy_List[i], Vcz_List[i],             phi_List[i], theta_List[i]);
                k1_Y = f_Y(t_List[i], Vcx_List[i], Vcy_List[i], Vcz_List[i], psi_List[i], phi_List[i], theta_List[i]);
                k1_Z = f_Z(t_List[i], Vcx_List[i], Vcy_List[i], Vcz_List[i], psi_List[i], phi_List[i], theta_List[i]);
                k1_psi = f_psi(t_List[i], Omy_List[i], Omz_List[i], phi_List[i], theta_List[i]);
                k1_phi = f_phi(t_List[i], Omx_List[i], Omy_List[i], Omz_List[i], phi_List[i], theta_List[i]);
                k1_theta = f_theta(t_List[i], Omy_List[i], Omz_List[i], phi_List[i]);

                k2_Vcx = f_Vcx(t_List[i] + dt / 2.0, Vcy_List[i] + dt / 2.0 * k1_Vcy, Vcz_List[i] + dt / 2.0 * k1_Vcz, Omy_List[i] + dt / 2.0 * k1_Omy, Omz_List[i] + dt / 2.0 * k1_Omz, Fx_List[i], Body.m);
                k2_Vcy = f_Vcy(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k1_Vcx, Vcz_List[i] + dt / 2.0 * k1_Vcz, Omx_List[i] + dt / 2.0 * k1_Omx, Omz_List[i] + dt / 2.0 * k1_Omz, Fy_List[i], Body.m);
                k2_Vcz = f_Vcz(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k1_Vcx, Vcy_List[i] + dt / 2.0 * k1_Vcy, Omx_List[i] + dt / 2.0 * k1_Omx, Omy_List[i] + dt / 2.0 * k1_Omy, Fz_List[i], Body.m);
                k2_Omx = f_Omx(t_List[i] + dt / 2.0, Body.Jp, Mx_List[i]);
                k2_Omy = f_Omy(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k1_Omx,     Omz_List[i] + dt / 2.0 * k1_Omz, Body.Jp, Body.Je, My_List[i]);
                k2_Omz = f_Omz(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k1_Omx,     Omy_List[i] + dt / 2.0 * k1_Omy, Body.Jp, Body.Je, Mz_List[i]);
                k2_X =   f_X(  t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k1_Vcx,     Vcy_List[i] + dt / 2.0 * k1_Vcy, Vcz_List[i] + dt / 2.0 * k1_Vcz,                                 phi_List[i] + dt / 2.0 * k1_phi, theta_List[i] + dt / 2.0 * k1_theta);
                k2_Y =   f_Y(  t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k1_Vcx,     Vcy_List[i] + dt / 2.0 * k1_Vcy, Vcz_List[i] + dt / 2.0 * k1_Vcz, psi_List[i] + dt / 2.0 * k1_psi, phi_List[i] + dt / 2.0 * k1_phi, theta_List[i] + dt / 2.0 * k1_theta);
                k2_Z =   f_Z(  t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k1_Vcx,     Vcy_List[i] + dt / 2.0 * k1_Vcy, Vcz_List[i] + dt / 2.0 * k1_Vcz, psi_List[i] + dt / 2.0 * k1_psi, phi_List[i] + dt / 2.0 * k1_phi, theta_List[i] + dt / 2.0 * k1_theta);
                k2_psi = f_psi(t_List[i] + dt / 2.0, Omy_List[i] + dt / 2.0 * k1_Omy,     Omz_List[i] + dt / 2.0 * k1_Omz, phi_List[i] + dt / 2.0 * k1_phi, theta_List[i] + dt / 2.0 * k1_theta);
                k2_phi = f_phi(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k1_Omx,     Omy_List[i] + dt / 2.0 * k1_Omy, Omz_List[i] + dt / 2.0 * k1_Omz, phi_List[i] + dt / 2.0 * k1_phi, theta_List[i] + dt / 2.0 * k1_theta);
                k2_theta = f_theta(t_List[i] + dt / 2.0, Omy_List[i] + dt / 2.0 * k1_Omy, Omz_List[i] + dt / 2.0 * k1_Omz, phi_List[i] + dt / 2.0 * k1_phi);

                k3_Vcx = f_Vcx(t_List[i] + dt / 2.0, Vcy_List[i] + dt / 2.0 * k2_Vcy, Vcz_List[i] + dt / 2.0 * k2_Vcz, Omy_List[i] + dt / 2.0 * k2_Omy, Omz_List[i] + dt / 2.0 * k2_Omz, Fx_List[i], Body.m);
                k3_Vcy = f_Vcy(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k2_Vcx, Vcz_List[i] + dt / 2.0 * k2_Vcz, Omx_List[i] + dt / 2.0 * k2_Omx, Omz_List[i] + dt / 2.0 * k2_Omz, Fy_List[i], Body.m);
                k3_Vcz = f_Vcz(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k2_Vcx, Vcy_List[i] + dt / 2.0 * k2_Vcy, Omx_List[i] + dt / 2.0 * k2_Omx, Omy_List[i] + dt / 2.0 * k2_Omy, Fz_List[i], Body.m);
                k3_Omx = f_Omx(t_List[i] + dt / 2.0, Body.Jp, Mx_List[i]);
                k3_Omy = f_Omy(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k2_Omx, Omz_List[i] + dt / 2.0 * k2_Omz, Body.Jp, Body.Je, My_List[i]);
                k3_Omz = f_Omz(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k2_Omx, Omy_List[i] + dt / 2.0 * k2_Omy, Body.Jp, Body.Je, Mz_List[i]);
                k3_X = f_X(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k2_Vcx, Vcy_List[i] + dt / 2.0 * k2_Vcy, Vcz_List[i] + dt / 2.0 * k2_Vcz,                                 phi_List[i] + dt / 2.0 * k2_phi, theta_List[i] + dt / 2.0 * k2_theta);
                k3_Y = f_Y(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k2_Vcx, Vcy_List[i] + dt / 2.0 * k2_Vcy, Vcz_List[i] + dt / 2.0 * k2_Vcz, psi_List[i] + dt / 2.0 * k2_psi, phi_List[i] + dt / 2.0 * k2_phi, theta_List[i] + dt / 2.0 * k2_theta);
                k3_Z = f_Z(t_List[i] + dt / 2.0, Vcx_List[i] + dt / 2.0 * k2_Vcx, Vcy_List[i] + dt / 2.0 * k2_Vcy, Vcz_List[i] + dt / 2.0 * k2_Vcz, psi_List[i] + dt / 2.0 * k2_psi, phi_List[i] + dt / 2.0 * k2_phi, theta_List[i] + dt / 2.0 * k2_theta);
                k3_psi = f_psi(t_List[i] + dt / 2.0, Omy_List[i] + dt / 2.0 * k2_Omy, Omz_List[i] + dt / 2.0 * k2_Omz, phi_List[i] + dt / 2.0 * k2_phi, theta_List[i] + dt / 2.0 * k2_theta);
                k3_phi = f_phi(t_List[i] + dt / 2.0, Omx_List[i] + dt / 2.0 * k2_Omx, Omy_List[i] + dt / 2.0 * k2_Omy, Omz_List[i] + dt / 2.0 * k2_Omz, phi_List[i] + dt / 2.0 * k2_phi, theta_List[i] + dt / 2.0 * k2_theta);
                k3_theta = f_theta(t_List[i] + dt / 2.0, Omy_List[i] + dt / 2.0 * k2_Omy, Omz_List[i] + dt / 2.0 * k2_Omz, phi_List[i] + dt / 2.0 * k2_phi);

                k4_Vcx = f_Vcx(t_List[i] + dt, Vcy_List[i] + dt * k3_Vcy, Vcz_List[i] + dt * k3_Vcz, Omy_List[i] + dt * k3_Omy, Omz_List[i] + dt * k3_Omz, Fx_List[i], Body.m);
                k4_Vcy = f_Vcy(t_List[i] + dt, Vcx_List[i] + dt * k3_Vcx, Vcz_List[i] + dt * k3_Vcz, Omx_List[i] + dt * k3_Omx, Omz_List[i] + dt * k3_Omz, Fy_List[i], Body.m);
                k4_Vcz = f_Vcz(t_List[i] + dt, Vcx_List[i] + dt * k3_Vcx, Vcy_List[i] + dt * k3_Vcy, Omx_List[i] + dt * k3_Omx, Omy_List[i] + dt * k3_Omy, Fz_List[i], Body.m);
                k4_Omx = f_Omx(t_List[i] + dt, Body.Jp, Mx_List[i]);
                k4_Omy = f_Omy(t_List[i] + dt, Omx_List[i] + dt * k3_Omx, Omz_List[i] + dt * k3_Omz, Body.Jp, Body.Je, My_List[i]);
                k4_Omz = f_Omz(t_List[i] + dt, Omx_List[i] + dt * k3_Omx, Omy_List[i] + dt * k3_Omy, Body.Jp, Body.Je, Mz_List[i]);
                k4_X = f_X(t_List[i] + dt, Vcx_List[i] + dt * k3_Vcx, Vcy_List[i] + dt * k3_Vcy, Vcz_List[i] + dt * k3_Vcz,                           phi_List[i] + dt * k3_phi, theta_List[i] + dt * k3_theta);
                k4_Y = f_Y(t_List[i] + dt, Vcx_List[i] + dt * k3_Vcx, Vcy_List[i] + dt * k3_Vcy, Vcz_List[i] + dt * k3_Vcz, psi_List[i] + dt * k3_psi, phi_List[i] + dt * k3_phi, theta_List[i] + dt * k3_theta);
                k4_Z = f_Z(t_List[i] + dt, Vcx_List[i] + dt * k3_Vcx, Vcy_List[i] + dt * k3_Vcy, Vcz_List[i] + dt * k3_Vcz, psi_List[i] + dt * k3_psi, phi_List[i] + dt * k3_phi, theta_List[i] + dt * k3_theta);
                k4_psi = f_psi(t_List[i] + dt, Omy_List[i] + dt * k3_Omy, Omz_List[i] + dt * k3_Omz, phi_List[i] + dt * k3_phi, theta_List[i] + dt * k3_theta);
                k4_phi = f_phi(t_List[i] + dt, Omx_List[i] + dt * k3_Omx, Omy_List[i] + dt * k3_Omy, Omz_List[i] + dt * k3_Omz, phi_List[i] + dt * k3_phi, theta_List[i] + dt * k3_theta);
                k4_theta = f_theta(t_List[i] + dt, Omy_List[i] + dt * k3_Omy, Omz_List[i] + dt * k3_Omz, phi_List[i] + dt * k3_phi);

                // Вычисление дифференциалов
                d_Vcx = (dt / 6.0) * (k1_Vcx + 2.0 * k2_Vcx + 2.0 * k3_Vcx + k4_Vcx);
                d_Vcy = (dt / 6.0) * (k1_Vcy + 2.0 * k2_Vcy + 2.0 * k3_Vcy + k4_Vcy);
                d_Vcz = (dt / 6.0) * (k1_Vcz + 2.0 * k2_Vcz + 2.0 * k3_Vcz + k4_Vcz);
                d_Omx = (dt / 6.0) * (k1_Omx + 2.0 * k2_Omx + 2.0 * k3_Omx + k4_Omx);
                d_Omy = (dt / 6.0) * (k1_Omy + 2.0 * k2_Omy + 2.0 * k3_Omy + k4_Omy);
                d_Omz = (dt / 6.0) * (k1_Omz + 2.0 * k2_Omz + 2.0 * k3_Omz + k4_Omz);
                d_X = (dt / 6.0) * (k1_X + 2.0 * k2_X + 2.0 * k3_X + k4_X);
                d_Y = (dt / 6.0) * (k1_Y + 2.0 * k2_Y + 2.0 * k3_Y + k4_Y);
                d_Z = (dt / 6.0) * (k1_Z + 2.0 * k2_Z + 2.0 * k3_Z + k4_Z);
                d_psi = (dt / 6.0) * (k1_psi + 2.0 * k2_psi + 2.0 * k3_psi + k4_psi);
                d_phi = (dt / 6.0) * (k1_phi + 2.0 * k2_phi + 2.0 * k3_phi + k4_phi);
                d_theta = (dt / 6.0) * (k1_theta + 2.0 * k2_theta + 2.0 * k3_theta + k4_theta);

                // Переход к следующей ячейке массива
                Vcx_List.Add(Vcx_List[i] + d_Vcx);
                Vcy_List.Add(Vcy_List[i] + d_Vcy);
                Vcz_List.Add(Vcz_List[i] + d_Vcz);
                Omx_List.Add(Omx_List[i] + d_Omx);
                Omy_List.Add(Omy_List[i] + d_Omy);
                Omz_List.Add(Omz_List[i] + d_Omz);
                X_List.Add(X_List[i] + d_X);
                Y_List.Add(Y_List[i] + d_Y);
                Z_List.Add(Z_List[i] + d_Z);
                psi_List.Add(psi_List[i] + d_psi);
                phi_List.Add(phi_List[i] + d_phi);
                theta_List.Add(theta_List[i] + d_theta);

                t_List.Add(t_List[i] + dt);

                Vc_List.Add(Math.Sqrt(Vcx_List[i + 1] * Vcx_List[i + 1] + Vcy_List[i + 1] * Vcy_List[i + 1] + Vcz_List[i + 1] * Vcz_List[i + 1]));
                Vc = Vc_List[i + 1];

                Body.Vcx = Vcx_List[i + 1];
                Body.Vcy = Vcy_List[i + 1];
                Body.Vcz = Vcz_List[i + 1];
                Body.Omx = Omx_List[i + 1];
                Body.Omy = Omy_List[i + 1];
                Body.Omz = Omz_List[i + 1];
                Body.Xc = X_List[i + 1];
                Body.Psi = psi_List[i + 1];
                Body.phi = phi_List[i + 1];
                Body.Theta = theta_List[i + 1];

                i++;
            }
        }
        public static void Write()
        {
            try
            {
                // StreamWriter пишет в файлы. На вход - путь строкой.
                // sw - ВСЁ
                // Vel - скорости
                // Fx - сила на ось икс связанной СК
                // X - координата в неподвижной СК

                StreamWriter sw = new StreamWriter("C:\\Terminal_Ballistics\\Results\\Runge.txt");
                StreamWriter Velx = new StreamWriter("C:\\Terminal_Ballistics\\Results\\Vcx.txt");
                StreamWriter Fx = new StreamWriter("C:\\Terminal_Ballistics\\Results\\Fx.txt");
                StreamWriter Mx = new StreamWriter("C:\\Terminal_Ballistics\\Results\\Mx.txt");
                StreamWriter X = new StreamWriter("C:\\Terminal_Ballistics\\Results\\X.txt");
                StreamWriter Z = new StreamWriter("C:\\Terminal_Ballistics\\Results\\Z.txt");
                StreamWriter Theta = new StreamWriter("C:\\Terminal_Ballistics\\Results\\theta.txt");
                //StreamWriter Phi = new StreamWriter("\\Terminal_Ballistics\\Results\\phi.txt");
                //StreamWriter Omx = new StreamWriter("\\Terminal_Ballistics\\Results\\omx.txt");

                // Цикл записи в файлы
                for (int i = 0; i < Fx_List.Count - 1; i++)
                {
                    //Радианы в градусы
                    //psi_Arr[i] = psi_List[i] * 180.0 / Math.PI;
                    //phi_Arr[i] = phi_List[i] * 180.0 / Math.PI;
                    //theta_Arr[i] = theta_List[i] * 180.0 / Math.PI;

                    // Собственно вывод
                    sw.WriteLine(Vcx_Arr[i].ToString() + "    " + Vcy_Arr[i].ToString() + "   " + Vcz_Arr[i].ToString() + "   "
                        + Omx_Arr[i].ToString() + " " + Omy_Arr[i].ToString() + "   " + Omz_Arr[i].ToString() + "   "
                        + X_Arr[i].ToString() + "    " + Y_Arr[i].ToString() + "  " + Z_Arr[i].ToString() + "  "
                        + psi_Arr[i].ToString() + " " + phi_Arr[i].ToString() + "   " + theta_Arr[i].ToString() + "   "
                        + Fx_Arr[i].ToString() + "    " + Fy_Arr[i].ToString() + "  " + Fz_Arr[i].ToString() + "  "
                        + Mx_Arr[i].ToString() + "    " + My_Arr[i].ToString() + "  " + Mz_Arr[i].ToString() + "  "
                        + Vc_Arr[i].ToString());
                    Velx.WriteLine(t_Arr[i].ToString() + "    " + Vcx_Arr[i].ToString());
                    Fx.WriteLine(t_Arr[i].ToString() + "    " + Fx_Arr[i].ToString());
                    Mx.WriteLine(t_Arr[i].ToString() + "    " + Mx_Arr[i].ToString());
                    X.WriteLine(t_Arr[i].ToString() + "    " + X_Arr[i].ToString());
                    Z.WriteLine(t_Arr[i].ToString() + "    " + Z_Arr[i].ToString());
                    Theta.WriteLine(t_Arr[i].ToString() + "    " + theta_Arr[i].ToString());
                    //Phi.WriteLine(t_Arr[i].ToString() + "    " + phi_Arr[i].ToString());
                    //Omx.WriteLine(t_Arr[i].ToString() + "    " + Omx_Arr[i].ToString());
                }

                // Закрываются файлы
                sw.Close();
                Velx.Close();
                Fx.Close();
                Mx.Close();
                X.Close();
                Z.Close();
                Theta.Close();
                //Phi.Close();
                //Omx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка. Запись в файлы не произведена.");
            }
            finally
            {
                //FMain.rtbLog.Text = "Расчет успешно завершен!";
            }
        }
    }
}