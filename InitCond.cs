using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RK = Terminal_Ballistics.RungeKutta;

namespace Terminal_Ballistics
{
    static class InitialConditions
    {
        //*****Исходные данные*****

        // Исходные данные: начальная скорость, угол атаки, углы нутации и прецессии
        // скорости нутации и прецессии, угловая скорость вращения
        public static double V0 { get; set; }
        public static double alpha_nu { get; set; }
        public static double delta0 { get; set; }
        public static double nu0 { get; set; }
        public static double delta0_dot { get; set; }
        public static double nu0_dot { get; set; }
        public static double phi0_dot { get; set; }
        // Бесконечно малое значение угла тета (принимается, если вводится тета = 0.0)
        static readonly double DELTA = 0.0001;

        //*****Определение начальных углов и скоростей в различных системах координат*****

        //Определение начальных углов Theta0, Psi0, phi0 в ССК
        public static void Angles_WindToBody(ref double Theta0, ref double Psi0, ref double phi0) //Возможно, понадобится указать в принимаемых параметрах alpha_nu, delta0, nu0
        {
            double PsiCr1, PsiCr2;

            if (alpha_nu == 0)
            {
                if (delta0 == 0)
                {
                    Theta0 = DELTA;
                    Psi0 = 0.0;
                    phi0 = 0.0;
                }
                else
                {
                    Theta0 = delta0;
                    Psi0 = nu0;
                    phi0 = 0.0;
                }
            }
            else if (alpha_nu < delta0)
            {
                Theta0 = Math.PI / 2.0 - Math.Asin(Math.Cos(delta0) * Math.Cos(alpha_nu) - Math.Cos(nu0) * Math.Sin(delta0) * Math.Sin(alpha_nu));
                phi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
                PsiCr1 = Math.PI / 2.0 + Math.Asin(Math.Tan(alpha_nu) / Math.Tan(delta0));
                if (Math.Abs(nu0) <= PsiCr1)
                    Psi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(delta0) / Math.Sin(Theta0));
                else Psi0 = Math.PI - Math.Asin(Math.Sin(nu0) * Math.Sin(delta0) / Math.Sin(Theta0));
            }
            else if (alpha_nu == delta0)
            {
                if (nu0 == Math.PI)
                {
                    Theta0 = DELTA;
                    Psi0 = Math.PI / 2.0;
                    phi0 = Math.PI / 2.0;
                }
                else
                {
                    Theta0 = Math.PI / 2.0 - Math.Asin(Math.Cos(delta0) * Math.Cos(alpha_nu) - Math.Cos(nu0) * Math.Sin(delta0) * Math.Sin(alpha_nu));
                    Psi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(delta0) / Math.Sin(Theta0));
                    phi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
                }
            }
            else if (alpha_nu > Math.PI / 2.0 - delta0)
            {
                if (alpha_nu == Math.PI / 2.0)
                    PsiCr2 = Math.PI / 2.0;
                else PsiCr2 = Math.PI / 2.0 + Math.Asin(Math.Tan(delta0) / Math.Tan(alpha_nu));
                Theta0 = Math.PI / 2.0 - Math.Asin(Math.Cos(delta0) * Math.Cos(alpha_nu) - Math.Cos(nu0) * Math.Sin(delta0) * Math.Sin(alpha_nu));
                Psi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(delta0) / Math.Sin(Theta0));
                if (Math.Abs(nu0) <= PsiCr2)
                    phi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
                else phi0 = Math.PI - Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
            }
            else if (delta0 == 0)
            {
                Theta0 = alpha_nu;
                Psi0 = 0.0;
                phi0 = 0.0;
            }
            else
            {
                Theta0 = Math.PI / 2.0 - Math.Asin(Math.Cos(delta0) * Math.Cos(alpha_nu) - Math.Cos(nu0) * Math.Sin(delta0) * Math.Sin(alpha_nu));
                Psi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(delta0) / Math.Sin(Theta0));
                PsiCr2 = Math.PI / 2.0 + Math.Asin(Math.Tan(delta0) / Math.Tan(alpha_nu));
                if (Math.Abs(nu0) <= PsiCr2)
                    phi0 = Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
                else phi0 = Math.PI - Math.Asin(Math.Sin(nu0) * Math.Sin(alpha_nu) / Math.Sin(Theta0));
            }
        }

        //Перевод проекций вектора скорости из ПСК в ССК
        public static void V_WindToBody(ref double Vcx0, ref double Vcy0, ref double Vcz0)
        {
            Vcx0 = V0 * Math.Cos(delta0);
            Vcy0 = 0;
            Vcz0 = V0 * Math.Sin(delta0);
        }
       
        //Разложение угловой скорости на составляющие по x, y, z в ССК (Кинематические уравнения Эйлера)
        public static void Om_WindToBody(ref double Omx0, ref double Omy0, ref double Omz0)
        {
            Omx0 = nu0_dot * Math.Cos(delta0) + phi0_dot;
            Omy0 = nu0_dot * Math.Sin(delta0) * Math.Sin(Body.phi) + delta0_dot * Math.Cos(Body.phi);
            Omz0 = nu0_dot * Math.Sin(delta0) * Math.Cos(Body.phi) - delta0_dot * Math.Sin(Body.phi);
        }
       
        //Метод для нахождения Хцн прописан для частного случая (конкретная форма ударника)
        //Надо править для общего случая
        public static double XInitial(double _Theta)
        {
            Body.Xc = -(Body.L - Body.xc);
            RK.l1 = Body.L - Body.xc;
            RK.l2 = Body.L - Body.xc;
            double XMax = -10000000;
            foreach (Body p in Body.BodyParts)
            {
                // Проверяется, содержит ли парт тела ЦМ, в зависимости от этого определяются границы по длине для расчёта
                if (p.id < Body.centeredPartID)
                {
                    RK.l1 = RK.l2;
                    RK.l2 -= p.l;
                }
                else if (p.id == Body.centeredPartID)
                {
                    RK.l1 = RK.l2;
                    RK.l2 = -Body.xc + Body.lRear;
                }
                else
                {
                    RK.l1 = RK.l2;
                    RK.l2 -= p.l;
                }

                p.XForXInitComputation(ref XMax);
            }
            Body.Xc = -(Body.L - Body.xc + XMax);
            return Body.Xc;

            //if (_Theta >= 0 && _Theta <= DELTA)
            //    Xinit = -(Body.L - Body.xc);
            //else if (_Theta > DELTA && _Theta <= 0.5 * Math.PI - Body.BodyParts[0].lambda)
            //    Xinit = -((Body.L - Body.xc) * Math.Cos(_Theta) + 0.5 * Body.BodyParts[0].d1 * Math.Sin(_Theta));
            //else if (_Theta > 0.5 * Math.PI - Body.BodyParts[0].lambda && _Theta <= 0.5 * Math.PI)
            //    Xinit = -((Body.L - Body.xc - Body.BodyParts[1].l) * Math.Cos(_Theta) + 0.5 * Body.BodyParts[1].d1 * Math.Sin(_Theta));
            //else
            //    Xinit = -((0.5 * Body.BodyParts[2].d1) * Math.Sin(_Theta) - Body.xc * Math.Cos(_Theta));
            //return Xinit;
        }
    }
}