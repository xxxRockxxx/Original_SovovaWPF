using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using CalculatorForSovova;
using System.IO;

namespace Original_Sovova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Convert conv = new Convert();
            CalculatorForSovova.Data.p_B = conv.ConvertStringToDouble(p_B.Text);
            CalculatorForSovova.Data.p_S = conv.ConvertStringToDouble(p_S.Text);
            CalculatorForSovova.Data.p_F = conv.ConvertStringToDouble(p_f.Text);
            CalculatorForSovova.Data.G_F = conv.ConvertStringToDouble(G_f.Text);
            CalculatorForSovova.Data.m_s = conv.ConvertStringToDouble(m_s.Text);
            CalculatorForSovova.Data.k_fa = conv.ConvertStringToDouble(k_fa.Text);
            CalculatorForSovova.Data.Y_s = conv.ConvertStringToDouble(Y_s.Text);
            CalculatorForSovova.Data.x_k = conv.ConvertStringToDouble(x_k.Text);
            CalculatorForSovova.Data.k_sa = conv.ConvertStringToDouble(k_sa.Text);
            CalculatorForSovova.Data.X_O = conv.ConvertStringToDouble(X_0.Text);

            SaveFileDialog sfd = new SaveFileDialog();
            string filename = sfd.FileName;
            string text = "";
            string path = @"C:\Users\MSI\Desktop\test2.txt";
            foreach (var data in CalculatorForSovova.Data.All_Periods)
            {
                text += ($"{data.Key};{data.Value}\n");
            }
            File.WriteAllText(path, text);

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\MSI\Desktop";
            //sfd.RestoreDirectory = true;
            //sfd.FileName = "База данных";
            //sfd.DefaultExt = "txt";
            //sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            //if (sfd.ShowDialog() == DialogResult.HasValue)
            //{
            //    return;
            //}
        }
    }
}
