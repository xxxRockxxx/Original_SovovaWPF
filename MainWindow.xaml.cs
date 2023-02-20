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

            CalculatorForSovova.Data.CountAnotherDatta();

            //Добавить класс Save
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            string text = "";
            foreach (var data in CalculatorForSovova.Data.All_Periods)
            {
                text += ($"time:{data.Key}  mass:{data.Value}\n");
            }

            foreach (var data in CalculatorForSovova.Data.Users_Data)
            {
                text += ($"time:{data.Key}  mass(Users):{data.Value}  mass(Count):{CalculatorForSovova.Data.All_Periods[data.Key]}\n");
            }

            text += ($"Ошибка:{CalculatorForSovova.Data.Fault}\n");

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, text);
            }

            //SaveFileDialog sfd = new SaveFileDialog();
            //string filename = sfd.FileName;
            //string text = "";
            //string path = @"C:\Users\MSI\Desktop\test2.txt";
            //foreach (var data in CalculatorForSovova.Data.All_Periods)
            //{
            //    text += ($"{data.Key};{data.Value}\n");
            //}
            //File.WriteAllText(path, text);

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var filePath = string.Empty;
            var fileContent = string.Empty;
            string[] lines=null;
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                filePath = open.FileName;

                var fileStream = open.OpenFile();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                    lines = File.ReadAllLines(filePath);
                    
                }

            }
            Distributor.Вata_distribution(lines);

        }
    }
}
