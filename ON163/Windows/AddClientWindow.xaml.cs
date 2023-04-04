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

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DB.Client client = new DB.Client();
            client.FirstName = tbFName.Text;
            client.LastName= tbLName.Text;
            client.Patronymic = tbPatr.Text;
            client.BirthDay = dpBirthDay.SelectedDate.Value;
            client.Email = tbEmail.Text;
            client.Phone= tbPhone.Text;
            context.Client.Add(client);
            context.SaveChanges();
        }
    }
}
