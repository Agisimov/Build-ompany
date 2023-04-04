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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFirstName.Text))
            {
                MessageBox.Show("имя не может быть пустым");
            }
            if (string.IsNullOrWhiteSpace(TextLastName.Text))
            {
                MessageBox.Show("фамилия не может быть пустой");
            }
            if (string.IsNullOrWhiteSpace(TextPatromymic.Text))
            {
                MessageBox.Show("отчество не может быть пустым");
            }
            if (string.IsNullOrWhiteSpace(TextPhone.Text))
            {
                MessageBox.Show("телефон не может быть пустым");
            }
            if (string.IsNullOrWhiteSpace(TextLogin.Text))
            {
                MessageBox.Show("логин не может быть пустым");

            }
            if (string.IsNullOrWhiteSpace(PBPasswoed.Password))
            {
                MessageBox.Show("пароль не может быть пустой");

            }
            if (string.IsNullOrWhiteSpace(TextBirthday.Text))
            {
                MessageBox.Show("дата не может быть пустой");
            }
            if (string.IsNullOrWhiteSpace(TextEmail.Text))
            {
                MessageBox.Show("Email не может быть пустой");
            }

            var authUser = context.Authorization.ToList()
                .Where(i=> i.Login== TextLogin.Text&& i.Password == PBPasswoed.Password).FirstOrDefault();
             if (authUser != null)
             {
                MessageBox.Show("логин занят");
             }

             DB.Authorization auth = new DB.Authorization();
            auth.Login = TextLogin.Text;
            auth.Password = PBPasswoed.Password;
            DB.Client client = new DB.Client();
           client.FirstName = TextFirstName.Text;
            client.LastName = TextLastName.Text;
            client.Email = TextEmail.Text;  
            client.Patronymic= TextPatromymic.Text;
            client.BirthDay = TextBirthday.SelectedDate.Value;
            client.Phone= TextPhone.Text;
            context.Authorization.Add(auth);
            context.Client.Add(client);
            context.SaveChanges();
            MessageBox.Show("ОККК");

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();

        }

      
    }
}
