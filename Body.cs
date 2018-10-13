using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RK = Terminal_Ballistics.RungeKutta;

namespace Terminal_Ballistics
{
    abstract class Body
    {
        // Список, в который пишутся составные части/элементы тела
        public static List<Body> BodyParts = new List<Body>();

        // Свойства, принимаемые каждым элементом тела
        // ID
        public int id { get; set; }
        // Название тела (конус, оживало, цилиндр)
        public string name { get; set; }
        // конструктивные характеристики тела (диаметры вершины и основания конуса, радиус и расположение оживала, длина)
        public double d1 { get; set; }
        public double d2 { get; set; }
        public double R { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double l { get; set; }
        // Угол при вершине конуса (вычисляется для всех, нужен для определения относительной скорости тела)
        public double lambda { get; set; }

        // Наибольший диаметр элемента тела (для расчёта dx и приведения к безразмерным координатам)
        public static double d { get; set; }

        // Статические свойства, имеющие отношение к телу в целом
        // ID элемента, содеражащего центр масс (ЦМ) тела
        public static int centeredPartID { get; set; }
        // Суммарная длина элементов тела, находящихся за элементом, содержащим ЦМ
        public static double lRear { get; set; }
        // Координата ЦМ
        public static double xc { get; set; }
        // Экваториальный момент инерции тела
        public static double Je { get; set; }
        // Полярный момент инерции тела
        public static double Jp { get; set; }
        // Полная масса тела
        public static double m { get; set; }
        // Полная длина тела
        public static double L { get; set; }

        // Составляющие векторов скорости ЦМ и угловой скорости тела
        public static double Vcx;
        public static double Vcy;
        public static double Vcz;
        public static double Omx;
        public static double Omy;
        public static double Omz;
        // Углы
        public static double Theta;
        public static double Psi;
        public static double phi;
        // Координата ЦМ в неподвижной СК
        public static double Xc { get; set; }
                                             
        protected double ro_x, ro_y, ro_z,   //радиус-вектор
            nx, ny, nz, tau_x, tau_y, tau_z, //единичные векторы нормали и касательной в проекциях
            Vx, Vy, Vz,                      //скорость на элементарной площадке поверхности тела (в проекциях)
            Vrelx, Vrely, Vrelz,             //относительная скорость на элем. площадке поверхности тела (в проекциях)
            sigma_n, tau_n,                  //нормальное и касательное напряжения
            dS, dx, r, dr,                   //площадь элем. площадки пов-ти тела, шаг по координате, радиус в данной точке пов-ти, шаг по радиусу
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;  //шаг по углу (дэ альфа)


        //*****Общие методы для всех классов*****

        // Возвращает id парта, в котором находится ЦМ
        public static int CenteredPartID()
        {
            double l = 0;
            foreach (Body p in BodyParts)
            {
                l += p.l;
                if (l >= L - xc)
                    return p.id;
            }
            return 0;
        }
        // Возвращает суммарную длину партов после парта, содержащего ЦМ
        public static double LRear()
        {
            double l = 0;
            for (int i = centeredPartID; i <= BodyParts.Count - 1; i++)
                l += BodyParts[i].l;
            return l;
        }
        // Расчёт координат элементарных площадок на притуплении для определения Xinit (начального положения Xc)
        protected void XForXInitOnTruncation(ref double Xmax)
        {
            double X;
            dr = d1 / 2.0 / (2.0 * RK.n_x);
            for (double r = 0.5 * dr; r <= d1 / 2.0; r += dr)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Вычисление радиусов-векторов тела
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, _x: RK.l1);
                    // Вычисление текущей координаты элементарной ячейки тела X
                    X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
                    if (Xmax < X) Xmax = X;
                }
            }
        }
        // Расчёт координат элементарных площадок на дне для определения Xinit
        protected void XForXInitOnBottom(ref double Xmax)
        {
            double X;
            dr = d1 / 2.0 / (2.0 * RK.n_x);
            //nx = -1.0; ny = 0; nz = 0;
            for (double r = 0.5 * dr; r <= d1 / 2.0; r += dr)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Вычисление радиусов-векторов тела
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, _x: RK.l2);
                    // Вычисление текущей координаты элементарной ячейки тела X
                    X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
                    if (Xmax < X) Xmax = X;
                }
            }
        }
        //Радиус-вектор
        protected void ro(out double ro_x, out double ro_y, out double ro_z, double r, double alpha, double _x)
        {
            ro_x = _x;
            ro_y = r * Math.Cos(alpha);
            ro_z = r * Math.Sin(alpha);
        }
        //Составляющие вектора скорости в ССК
        protected void V(out double Vx, out double Vy, out double Vz)
        {
            Vx = Vcx + (Omy * ro_z - Omz * ro_y);
            Vy = Vcy + (Omz * ro_x - Omx * ro_z);
            Vz = Vcz + (Omx * ro_y - Omy * ro_x);
        }
        //Составляющие вектора относительной скорости в ССК
        protected void Vrel(out double Vrelx, out double Vrely, out double Vrelz, double alpha, Body part, Obstacle layer)
        {
            Vrelx = Vx - layer.D * (Vcx * Math.Sin(part.lambda) * Math.Sin(part.lambda));
            Vrely = Vy - layer.D * (Vcy * Math.Sin(part.lambda) * Math.Cos(part.lambda) * Math.Cos(alpha));
            Vrelz = Vz - layer.D * (Vcz * Math.Sin(part.lambda) * Math.Cos(part.lambda) * Math.Sin(alpha));
        }
        //Составляющие вектора касательной
        protected void tau(out double tau_x, out double tau_y, out double tau_z, double _Vx, double _Vy, double _Vz)
        {
            double Vtau = Math.Sqrt((_Vx - _Vx * nx) * (_Vx - _Vx * nx) + (_Vy - _Vy * ny) * (_Vy - _Vy * ny) + (_Vz - _Vz * nz) * (_Vz - _Vz * nz));
            if (Vtau == 0)
            {
                tau_x = 0;
                tau_y = 0;
                tau_z = 0;
            }
            else
            {
                tau_x = (_Vx - (_Vx * nx)) / Vtau;
                tau_y = (_Vy - (_Vy * ny)) / Vtau;
                tau_z = (_Vz - (_Vz * nz)) / Vtau;
            }
        }
        //Условия контакта
        protected void ContactCondition(out double sigma_n, out double tau_n, double _Vx, double _Vy, double _Vz)
        {
            // Координата части тела Х и текущая толщина слоя преграды
            double X, curr_h = 0;
            // Численное значение Vn, как скалярное произведение векторов V и n
            double Vn = _Vx * nx + _Vy * ny + _Vz * nz;
            // Вычисление текущей координаты элементарной ячейки тела X
            X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
            // Проеряем, находится ли тело в преграде. Если не находится, напряжения = 0, считаем дальше.
            if (X < 0) { sigma_n = 0; tau_n = 0; }
            // Если находимся, то
            else
            {
                // Если X > curr_h, то не выполнится ни одно из условий и вернём мы то, что нужно, т. е. 0
                sigma_n = 0; tau_n = 0;
                // Выясняем, в каком именно слое находится тело
                foreach (Obstacle layer in Obstacle.Layers)
                {
                    // Добавляем к текущей толщине преграды curr_h толщину очередного слоя
                    curr_h += layer.h;
                    // Если находимся в текущем слое, то проверяем, положительна ли Vn и рассчитываем sigma_n и tau_n
                    if (X < curr_h)
                    {
                        if (Vn > 0)
                        {
                            sigma_n = layer.A * Vn * Vn + layer.B * Vn + layer.C;
                            tau_n = sigma_n * layer.Mu;
                        }
                        else { sigma_n = 0; tau_n = 0; }

                        break;
                    }
                }
            }
        }

        //Система уравнений для расчёта силовых характеристик
        protected void CubatorFormulas(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            double dFx, dFy, dFz, dMx, dMy, dMz;

            dFx = -(sigma_n * nx + tau_n * tau_x) * dS;
            dFy = -(sigma_n * ny + tau_n * tau_y) * dS;
            dFz = -(sigma_n * nz + tau_n * tau_z) * dS;
            dMx = -(ro_y * (sigma_n * nz + tau_n * tau_z) - ro_z * (sigma_n * ny + tau_n * tau_y)) * dS;
            dMy = -(ro_z * (sigma_n * nx + tau_n * tau_x) - ro_x * (sigma_n * nz + tau_n * tau_z)) * dS;
            dMz = -(ro_x * (sigma_n * ny + tau_n * tau_y) - ro_y * (sigma_n * nx + tau_n * tau_x)) * dS;

            Fx += dFx;
            Fy += dFy;
            Fz += dFz;
            Mx += dMx;
            My += dMy;
            Mz += dMz;
        }
        // Определение силовых характеристик на притуплении
        protected void ForceCharsOnTruncation(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            dr = d1 / 2.0 / (2.0 * RK.n_x);
            nx = 1.0; ny = 0.0; nz = 0.0;
            for (double r = 0.5 * dr; r <= d1 / 2.0; r += dr)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Составляющие радиус-вектора
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, _x: RK.l1);
                    // Составляющие вектора скорости  
                    V(out Vx, out Vy, out Vz);
                    // Единичные векторы касательной (возможно исключение "деление на ноль")
                    tau(out tau_x, out tau_y, out tau_z, Vx, Vy, Vz);
                    // Условия контакта
                    ContactCondition(out sigma_n, out tau_n, Vx, Vy, Vz);
                    // Площадь элементарной ячейки
                    dS = r * dr * d_alpha;
                    // Силовые характеристики                             
                    CubatorFormulas(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
                }
            }
        }        
        // Определение силовых характеристик на дне
        protected void ForceCharsOnBottom(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            dr = d1 / 2.0 / (2.0 * RK.n_x);
            nx = -1.0; ny = 0; nz = 0;
            for (double r = 0.5 * dr; r <= d1 / 2.0; r += dr)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, _x: RK.l2); //Составляющие радиус-вектора
                    V(out Vx, out Vy, out Vz); //Составляющие вектора V
                    Vrel(out Vrelx, out Vrely, out Vrelz, alpha, BodyParts[0], Obstacle.Layers[0]);
                    tau(out tau_x, out tau_y, out tau_z, Vrelx, Vrely, Vrelz); //Единичные векторы касательной (возможно исключение "деление на ноль")
                    ContactCondition(out sigma_n, out tau_n, Vrelx, Vrely, Vrelz); //Условия контакта
                    dS = r * dr * d_alpha;

                    CubatorFormulas(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz); //Силовые характеристики
                }
            }
        }

        // Абстрактная функция только для расчёта координат элементарных площадок на теле для определения начального положения Xc
        public abstract void XForXInitComputation(ref double Xmax);
        // Абстрактная функция, в которую вбивается набор методов,
        // соответствующий алгоритму расчёта той или иной части тела (того или иного класса)
        public abstract void ForceCharsComputation(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz);
    }

    class Cone : Body
    {
        public Cone(int id, string name, double d1, double d2, double l)
        {
            this.id = id;
            this.name = name;
            this.d1 = d1;
            this.d2 = d2;
            this.l = l;
            lambda = Math.Atan(0.5 * (d2 - d1) / l);
        }

        // К определению Xinit
        public override void XForXInitComputation(ref double Xmax)
        {
            double X,
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                XForXInitOnTruncation(ref Xmax);

            // Определение максимальной координаты элементарной ячейки тела по X -- Xmax
            dx = l / (2.0 * RK.n_x);
            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                // Проверка на прямой/обратный конус. В зависимости от этого -- разный расчёт r
                // Прямой конус
                if (d1 < d2)
                    r = (RK.l1 - x) * Math.Tan(lambda) + d1 / 2;
                // Обратный конус
                else
                    r = (RK.l2 - x) * Math.Tan(lambda) + d2 / 2;
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Вычисление радиусов-векторов тела
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Вычисление текущей координаты элементарной ячейки тела X
                    X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
                    // Сравнение с Xmax
                    if (Xmax < X) Xmax = X;
                }
            }
            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
                XForXInitOnBottom(ref Xmax);
        }

        //Расчёт силовых характеристик на конусе
        public override void ForceCharsComputation(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            Fx = 0.0; Fy = 0.0; Fz = 0.0; Mx = 0.0; My = 0.0; Mz = 0.0;
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                ForceCharsOnTruncation(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
                
            dx = l / (RK.n_x);
            nx = Math.Sin(lambda);

            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                if (d1 < d2)
                    r = (RK.l1 - x) * Math.Tan(lambda) + d1 / 2;
                else
                    r = (RK.l2 - x) * Math.Tan(lambda) + d2 / 2;
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Единичные векторы нормали (nx постоянный, поэтому определён выше)
                    ny = Math.Cos(alpha) * Math.Cos(lambda);
                    nz = Math.Sin(alpha) * Math.Cos(lambda);
                    // Составляющие радиус-вектора
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Составляющие вектора V
                    V(out Vx, out Vy, out Vz);
                    // Единичные векторы касательной (возможно исключение "деление на ноль")
                    tau(out tau_x, out tau_y, out tau_z, Vx, Vy, Vz);
                    // Условия контакта
                    ContactCondition(out sigma_n, out tau_n, Vx, Vy, Vz);
                    // Площадь элементарной ячейки
                    dS = r * dx * d_alpha / Math.Cos(lambda);
                    // Силовые характеристики
                    CubatorFormulas(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
                }
            }

            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
            {
                ForceCharsOnBottom(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
            }
        }
    }

    class Ogive : Body
    {
        // double lh, H, gamma;
        public Ogive(int id, string name, double d1, double d2, double R, double l)
        {
            double lh, H, gamma;

            this.id = id;
            this.name = name;
            this.d1 = d1;
            this.d2 = d2;
            this.R = R;
            this.l = l;

            lh = Math.Sqrt((0.5 * (d2 - d1)) * (0.5 * (d2 - d1)) + l * l);
            H = Math.Sqrt(R * R - (lh / 2 ) * (lh / 2));
            gamma = Math.Acos(l / lh);

            this.a = -(lh / 2) * Math.Cos(gamma) + H * Math.Sin(gamma);
            this.b = -(d2 + d1) / 4 + H * Math.Cos(gamma);
        }

        public override void XForXInitComputation(ref double Xmax)
        {
            double X,
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                XForXInitOnTruncation(ref Xmax);

            // Определение максимальной координаты элементарной ячейки тела по X -- Xmax
            dx = l / (2.0 * RK.n_x);
            // Проверка на прямой/обратный конус. В зависимости от этого -- разный расчёт r
            // Прямой конус
            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                if (d1 < d2)
                    r = Math.Sqrt(R * R - (x - RK.l2 + a) * (x - RK.l2 + a)) - b;
                else
                    r = Math.Sqrt(R * R - (RK.l1 - x + a) * (x - RK.l2 + a)) - b;
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Вычисление радиусов-векторов тела
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Вычисление текущей координаты элементарной ячейки тела X
                    X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
                    // Сравнение с Xmax
                    if (Xmax < X) Xmax = X;
                }
            }

            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
                XForXInitOnBottom(ref Xmax);

        }

        public override void ForceCharsComputation(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            Fx = 0.0; Fy = 0.0; Fz = 0.0; Mx = 0.0; My = 0.0; Mz = 0.0;
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                ForceCharsOnTruncation(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);

            dx = l / (2.0 * RK.n_x);

            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                if (d1 < d2)
                {
                    r = Math.Sqrt(R * R - (x - RK.l2 + a) * (x - RK.l2 + a)) - b;
                    nx = (x + a - RK.l2) / R;
                }
                else
                {
                    r = Math.Sqrt(R * R - (RK.l1 - x + a) * (x - RK.l2 + a)) - b;
                    nx = (RK.l1 - x + a) / R;
                }
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Единичные векторы нормали (nx постоянный, поэтому определён выше)
                    ny = (b + r) / R * Math.Cos(alpha);
                    nz = (b + r) / R * Math.Sin(alpha);
                    // Составляющие радиус-вектора
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Составляющие вектора V
                    V(out Vx, out Vy, out Vz);
                    // Единичные векторы касательной (возможно исключение "деление на ноль")
                    tau(out tau_x, out tau_y, out tau_z, Vx, Vy, Vz);
                    // Условия контакта
                    ContactCondition(out sigma_n, out tau_n, Vx, Vy, Vz);
                    // Площадь элементарной ячейки
                    dS = r * dx * d_alpha / Math.Cos(lambda);
                    // Силовые характеристики
                    CubatorFormulas(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
                }
            }

            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
            {
                ForceCharsOnBottom(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
            }
        }
    }

    class Cyl : Body
    {
        public Cyl(int id, string name, double d, double l)
        {
            this.id = id;
            this.name = name;
            d1 = d;
            d2 = d1;
            this.l = l;
            lambda = Math.PI / 2;
        }
        // К определению Xinit
        public override void XForXInitComputation(ref double Xmax)
        {
            double X;
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                XForXInitOnTruncation(ref Xmax);

            dx = l / RK.n_x;
            r = d1 / 2.0;
            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Вычисление радиусов-векторов тела
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Вычисление текущей координаты элементарной ячейки тела X
                    X = ro_x * Math.Cos(Theta) + ro_y * Math.Sin(phi) * Math.Sin(Theta) + ro_z * Math.Cos(phi) * Math.Sin(Theta) + Xc;
                    if (Xmax < X) Xmax = X;
                }
            }

            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
                XForXInitOnBottom(ref Xmax);
        }

        //Расчёт силовых характеристик на цилиндре 
        public override void ForceCharsComputation(ref double Fx, ref double Fy, ref double Fz, ref double Mx, ref double My, ref double Mz)
        {
            Fx = 0.0; Fy = 0.0; Fz = 0.0; Mx = 0.0; My = 0.0; Mz = 0.0;
            d_alpha = (360.0 / RK.n_alpha) * Math.PI / 180.0;

            // Проверка на наличие притупления
            if ((id == 1) && (d1 != 0))
                ForceCharsOnTruncation(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);

            dx = l / RK.n_x;
            r = d1 / 2.0;
            nx = 0;
            for (double x = RK.l1 - 0.5 * dx; x >= RK.l2; x -= dx)
            {
                for (double alpha = 0.5 * d_alpha; alpha <= 2.0 * Math.PI; alpha += d_alpha)
                {
                    // Единичные векторы нормали (nx постоянный, поэтому определён выше)
                    ny = Math.Cos(alpha);
                    nz = Math.Sin(alpha);
                    // Составляющие радиус-вектора
                    ro(out ro_x, out ro_y, out ro_z, r, alpha, x);
                    // Составляющие вектора V
                    V(out Vx, out Vy, out Vz);
                    Vrel(out Vrelx, out Vrely, out Vrelz, alpha, BodyParts[0], Obstacle.Layers[0]);
                    // Единичные векторы касательной
                    tau(out tau_x, out tau_y, out tau_z, Vrelx, Vrely, Vrelz);
                    // Условия контакта
                    ContactCondition(out sigma_n, out tau_n, Vrelx, Vrely, Vrelz);
                    // Площадь элементарной ячейки
                    dS = r * dx * d_alpha;
                    // Силовые характеристики
                    CubatorFormulas(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz); 
                }
            }

            // Проверка на наличие дна
            if ((id == BodyParts.Count) && (d2 != 0))
                ForceCharsOnBottom(ref Fx, ref Fy, ref Fz, ref Mx, ref My, ref Mz);
        }
    }
}
