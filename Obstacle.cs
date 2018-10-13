using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Ballistics
{
    class Obstacle
    {
        public static List<Obstacle> Layers = new List<Obstacle>();

        public int id { get; set; }
        public string name { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public double Mu { get; set; }
        public double h { get; set; }
        // Толщина всей преграды
        public static double H { get; set; }

        public Obstacle(int id, string name, double A, double B, double C, double D, double Mu, double h)
        {
            this.id = id;
            this.name = name;
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.Mu = Mu;
            this.h = h;
        }
    }
}
