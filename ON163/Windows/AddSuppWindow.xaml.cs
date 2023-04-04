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
using ON163.DB;
using static ON163.ClassHelper.EFClass;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSuppWindow.xaml
    /// </summary>
    public partial class AddSuppWindow : Window
    {
        public AddSuppWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название  не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("адресс не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(tbINN.Text))
            {
                MessageBox.Show("ИНН не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
            }
            else
            {
                DB.Supplier supplier = new DB.Supplier();
                supplier.Title = tbTitle.Text;
                supplier.Address = tbAddress.Text;
                supplier.INN = tbINN.Text;
                supplier.Phone = tbPhone.Text;
                context.Supplier.Add(supplier);
                context.SaveChanges();
                this.Close();
            }




         
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
