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

namespace WorkoutPlanner2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPull_Click(object sender, RoutedEventArgs e)
        {
            PullPage pullPage = new PullPage();
            pullPage.Show();
            this.Close();
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            PushPage pullPage = new PushPage();
            pullPage.Show();
            this.Close();
        }

        private void btnLegs_Click(object sender, RoutedEventArgs e)
        {
            LegsPage legsPage = new LegsPage();
            legsPage.Show();
            this.Close();
        }
    }
}
