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





            if (string.IsNullOrWhiteSpace(tbFName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(tbLName.Text))
            {
                MessageBox.Show("Фамилия не может быть пустой");
            }
            else if(string.IsNullOrWhiteSpace(tbPatr.Text))
            {
                MessageBox.Show("Отчество не может быть устым");
            }
            else if(string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {
                MessageBox.Show("Дата не может быть пустой");
            }
            else if(string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Почта не может быть пустой");
            }
            else if(string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
            }
            else
            {
                DB.Client client = new DB.Client();
                client.FirstName = tbFName.Text;
                client.LastName = tbLName.Text;
                client.Patronymic = tbPatr.Text;
                client.BirthDay = dpBirthDay.SelectedDate.Value;
                client.Email = tbEmail.Text;
                client.Phone = tbPhone.Text;
                context.Client.Add(client);
                context.SaveChanges();
                MessageBox.Show("ок");
                this.Close();
            }
             
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

   
}
