using System;

namespace Library_For_the_program_Calculator_
{
    public class Calculator
    {
        public void Calculation()
        {
            int t = 0;
            double massa;
            while (t <= 7200)
            {
                if (t < Data.t_CER)
                {
                    massa = Data.G_F * Data.Y_s * (1 - Math.Exp(-Data.Z)) * t;
                    Data.All_Periods.Add(t, massa);
                }

                else if (t >= Data.t_CER && t <= Data.t_FER)
                {
                    massa = Data.G_F * Data.Y_s * (t - Data.t_CER * Math.Exp(Data.Z * Data.Y_s / (Data.W * Data.X_O) * Math.Log((Data.X_O * Math.Exp(Data.W * Data.G_F * (t - Data.t_CER) / Data.m_s) - Data.x_k) / (Data.X_O - Data.x_k)) - Data.Z));
                    Data.All_Periods.Add(t, massa);
                }
                else
                {
                    massa = Data.m_s * (Data.X_O - Data.Y_s / Data.W * Math.Log(1 + (Math.Exp(Data.W * Data.X_O / Data.Y_s) - 1) * Math.Exp(Data.W * Data.G_F * (Data.t_CER - t) / Data.m_s) * Data.x_k / Data.X_O));
                    Data.All_Periods.Add(t, massa);
                }
                t += 60;
            }
        }
    }
}
