using ON163.Windows;
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
using static ON163.ClassHelper.EFClass;

namespace ON163
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datet.SelectedDate= DateTime.Now;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            DB.Order order= new DB.Order();
            order.Date = DateTime.Now;
            order.DateStart = Convert.ToDateTime(start.Text);
            order.DateEnd = Convert.ToDateTime(end.Text);
            order.Cost = Convert.ToDecimal(cost.Text);
;           context.Order.Add(order);
            context.SaveChanges();

            if (MessageBox.Show("оформить заказ?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
               AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();
            }
            //if (string.IsNullOrEmpty(cost.Text))
            //{
            //    MessageBox.Show("Цена не может быть пустой");
            //}
            //if (string.IsNullOrEmpty(start.Text))
            //{
            //    MessageBox.Show("Начало не может быть пустым");
            //}
            //if (string.IsNullOrEmpty(end.Text))
            //{
            //    MessageBox.Show("Конец не может быть пустым");
            //}





        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
