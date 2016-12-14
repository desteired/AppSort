using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Laboratory3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxLength ;
        List<UserControl1> users = new List<UserControl1>();
        public MainWindow()
        {
            InitializeComponent();

        }
        

        List<double> arr = new List<double>();

        // рандом
        void randomMedhod()
        {
            arr.Clear();
            Random r = new Random();
            for (int i = 0; i <= maxLength; i++ )
            {
                double b1 = Convert.ToDouble(r.Next(1000))/1000;
                arr.Add(b1);

            }
            label1.Content = getAvgDes();
        }
        // фон нейман
        void fonNehman()
        {
            arr.Clear();
            Random r = new Random();
            double b1 = Convert.ToDouble(r.Next(10000)) / 10000;
            string s = "";
            try
            {

                for (int i = 0; i < maxLength; i++)
                {
                    b1 = Math.Pow(b1, 2);
                    s = b1.ToString();
                    s = s.Substring(4, 4);

                    b1 = Convert.ToDouble("0," + s);
                    if (b1.ToString().Length < 5)
                    {
                        b1 = b1 + 0.1234;
                    }
                    if (new Regex("0").Matches(b1.ToString()).Count > 0)
                    {
                        b1 = b1 + 0.1234;
                    }
                    arr.Add(b1);

                }
            }
            catch
            {

            }
            label2.Content = getAvgDes();
            ///////////////////////////
        }

        //третий метод
        void otherMethod()
        {
            arr.Clear();
            Random r = new Random();
            //double b1 = Convert.ToDouble(r.Next(10000)) / 10000;
            double b1 = 9;
            int m = 100;
            int a = 5;
            int inc = 51;

            for (int i = 0; i < maxLength; i++)
            {
                b1 = ((b1 * a) + inc) % m;
                b1 = b1 / 100;
                arr.Add(b1);
                b1 = b1 * 100;
                
            }
            label3.Content = getAvgDes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            maxLength = Convert.ToInt32(tbox.Text);
            wrap1.Children.Clear();
            float heig;

            chekOfStep();

            // цикл для установки высоты канваса

            randomMedhod();
            for (int i = 0; i < maxLength; i++)
            {
                foreach(UserControl1 u in users){
                    if (arr[i] >= u.start && arr[i] < u.finish)
                    {
                        //u.canvas1.Height = u.canvas1.Height + heig;
                        u.count++;
                    }
                }
            }
            
            
            // цикл для отрисовки контролов на форме
            int min = 40000000;
            int max = 0;
            UserControl1 uMin = null;
            UserControl1 uMax = null;

            foreach (UserControl1 u in users)
            {
                if (u.count > max)
                {
                    max = u.count;
                    uMax = u;
                }
                if (u.count <= min)
                {
                    min = u.count;
                    uMin = u;
                }
                
            }
            float proc = 177; 
            heig =  proc / uMax.count;
            
            foreach (UserControl1 u in users)
            {
                

                if (u == uMax)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.BlueViolet);
                }
                
                if (u == uMin)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.Green);
                }

                u.canvas1.Height = (u.count * heig) * 0.7;
                double hh = u.canvas1.Height;
                u.labc.Content = u.count.ToString();
                wrap1.Children.Add(u);

            }
            
        }
        
        // второй врап
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            maxLength = Convert.ToInt32(tbox.Text);
            float heig;
            chekOfStep();
            fonNehman();
            wrap2.Children.Clear();

            // цикл для заполнения массива случайными числами
            Random r = new Random();
            for (int i = 0; i <= maxLength; i++)
            {
                double b1 = Convert.ToDouble(r.Next(100)) / 100;
                arr.Add(b1);

            }

            // цикл для установки высоты канваса
            for (int i = 0; i <= maxLength; i++)
            {
                foreach (UserControl1 u in users)
                {
                    if (arr[i] >= u.start && arr[i] < u.finish)
                    {
                        //u.canvas1.Height = u.canvas1.Height + heig;
                        u.count++;
                    }
                }
            }


            // цикл для отрисовки контролов на форме
            int min = 40000000;
            int max = 0;
            UserControl1 uMin = null;
            UserControl1 uMax = null;

            foreach (UserControl1 u in users)
            {
                if (u.count > max)
                {
                    max = u.count;
                    uMax = u;
                }
                if (u.count <= min)
                {
                    min = u.count;
                    uMin = u;
                }

            }
            float proc = 177;
            heig = proc / uMax.count;

            foreach (UserControl1 u in users)
            {


                if (u == uMax)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.BlueViolet);
                }

                if (u == uMin)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.Green);
                }

                u.canvas1.Height = (u.count * heig) * 0.7;
                double hh = u.canvas1.Height;
                u.labc.Content = u.count.ToString();
                wrap2.Children.Add(u);

            }

        }

        //проверка на шаг
        void chekOfStep()
        {
            users.Clear();
            int end = 0;

            double s1 = 0.0;
            double s2 = 0.0;
            double step = 0.0;
            double w = 0;
            
            if(r5.IsChecked == true){
                end = 19;
                s1 = 0.0;
                s2 = 0.05;
                step = 0.05;
                w = 44;
            }
            else if (r1.IsChecked == true)
            {
                end = 9;
                s1 = 0.0;
                s2 = 0.1;
                step = 0.1;
                w = 89;
            }
            else if (r2.IsChecked == true)
            {
                end = 4;
                s1 = 0.0;
                s2 = 0.2;
                step = 0.2;
                w = 178;
            }
            for (int i = 0; i <= end; i++)
            {
                users.Add(new UserControl1(s1, s2, w));
                s1 = s2;
                s2 = s2 + step;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            maxLength = Convert.ToInt32(tbox.Text);
            wrap3.Children.Clear();
            float heig;

            chekOfStep();

            // цикл для установки высоты канваса

            otherMethod();

            for (int i = 0; i < maxLength; i++)
            {
                foreach (UserControl1 u in users)
                {
                    if (arr[i] >= u.start && arr[i] < u.finish)
                    {
                        //u.canvas1.Height = u.canvas1.Height + heig;
                        u.count++;
                    }
                }
            }


            // цикл для отрисовки контролов на форме
            int min = 40000000;
            int max = 0;
            UserControl1 uMin = null;
            UserControl1 uMax = null;

            foreach (UserControl1 u in users)
            {
                if (u.count > max)
                {
                    max = u.count;
                    uMax = u;
                }
                if (u.count <= min)
                {
                    min = u.count;
                    uMin = u;
                }

            }
            float proc = 177;
            heig = proc / uMax.count;

            foreach (UserControl1 u in users)
            {


                if (u == uMax)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.BlueViolet);
                }

                if (u == uMin)
                {
                    u.canvas1.Background = new SolidColorBrush(Colors.Green);
                }

                u.canvas1.Height = (u.count * heig) * 0.7;
                double hh = u.canvas1.Height;
                u.labc.Content = u.count.ToString();
                wrap3.Children.Add(u);

            }
        }
        string getAvgDes(){
            double avg = 0;
            double des = 0;
            try
            {
                for (int i = 0; i < maxLength; i++)
                {
                    avg = avg + arr[i];
                }
                avg = avg / maxLength;

                for (int i = 0; i < maxLength; i++)
                {
                    des += (arr[i] - avg) * (arr[i] - avg);
                }
            }
            catch { }
            
            return "AVG = " + avg.ToString() + "DES = " + des.ToString().Substring(0,4);
        }
    }
}
