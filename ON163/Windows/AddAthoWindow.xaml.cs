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
using ON163.DB;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAthoWindow.xaml
    /// </summary>
    public partial class AddAthoWindow : Window
    {
        public AddAthoWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DB.Authorization authorization = new DB.Authorization();
            authorization.Password = tbPass.Text;
            authorization.Login = tbLogin.Text;
            context.Authorization.Add(authorization);
            context.SaveChanges();
        }
    }
}
