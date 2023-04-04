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
using System.Windows.Shapes;
using static ON163.ClassHelper.EFClass;
using ON163.Pagers;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            

        }




        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.EmpPage());
          
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.PostPage());
        }

        private void btnOrd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.OrderPage());
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.DrawPage());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.ClientPage());
        }

        private void btnMat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.MatPage());
        }

        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.SupPage());
        }

        private void btnEquip_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.EquipPage());
        }

        private void btnSup_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pagers.AvtorizaciiPage());
        }
    }
}
