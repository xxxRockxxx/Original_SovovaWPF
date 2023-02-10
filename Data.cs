using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_For_the_program_Calculator_
{
    public static class Data
    {
        public static double t_CER;
        public static double t_FER;
        public static double p_B;
        public static double p_S;
        public static double p_F;
        public static double E;
        public static double X_O;
        public static double m_O;
        public static double G_F;
        public static double Y_s;
        public static double m_s;
        public static double x_k;
        public static double R;
        public static double k_fa;
        public static double k_sa;
        public static double Z;
        public static double W;
        public static double r;
        public static double X_r;

        public static Dictionary<int, double> All_Periods = new Dictionary<int, double>();

        public static void CountAnotherDatta()
        {
            E = 1 - p_B / p_S;
            Z = k_fa * m_s * p_F / (G_F * (1 - E) * p_S);
            W = m_s * k_sa / (G_F * (1 - E));
            r = 1 - x_k / X_O;
            X_r = X_O - x_k;
            t_CER = m_s * (X_O - x_k) / (Y_s * Z * G_F);
            t_FER = t_CER + m_s / (G_F * W) * Math.Log((x_k + X_r * Math.Exp(W * X_O / Y_s)) / X_O);
        }
    }
}
