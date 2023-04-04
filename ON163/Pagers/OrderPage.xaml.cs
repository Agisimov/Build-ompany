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
using ON163.DB;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            OrderGrid.ItemsSource = ClassHelper.EFClass.context.Order.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = OrderGrid.SelectedItems.Cast<Order>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Order.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                OrderGrid.ItemsSource = context.Order.ToList();
            }
        }
    }
}
