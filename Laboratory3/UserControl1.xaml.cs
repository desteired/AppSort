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

namespace Laboratory3
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public double start = 0;
        public double finish = 0;

        public int count = 0;
        
        public UserControl1(double s, double f, double w)
        {
            InitializeComponent();
            start = s;
            finish = f;
            startLabel.Content = s.ToString();
            finishLabel.Content = f.ToString();
            this.Width = w;
            
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
