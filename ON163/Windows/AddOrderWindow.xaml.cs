using ON163.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            dpDate.SelectedDate = DateTime.Now;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DB.Order order = new Order();
            order.Date = dpDate.SelectedDate.Value;
            order.DateStart = dpDateStart.SelectedDate.Value;
            order.DateEnd = dpDateEnd.SelectedDate.Value;
            order.Cost = Convert.ToDecimal(tbCost.Text);
            context.Order.Add(order);
            context.SaveChanges();
        }
    }
}
