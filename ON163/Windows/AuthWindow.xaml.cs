using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Data.SqlClient;
using System.Net;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
        }
        public void GenerateCaptcha()
        {
            Random rnd = new Random();
            string text = "";
            string alf = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
            {
                text += alf[rnd.Next(alf.Length)];
            }
            tblCaptcha.Text = text;
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            var authUser = context.Authorization.ToList()
            .Where(i => i.Login == TextLogin.Text && i.Password == PBPasswoed.Password)
            .FirstOrDefault();
            if (tbCaptcha.Text== tblCaptcha.Text)
            {
                if (authUser != null)
                {

                    string connectionString = @"Data Source=224-10\SQLEXPRESS;Initial Catalog=sa;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sqlExpression = "SELECT Id FROM Client WHERE IdAuthorization = (SELECT Id FROM [Authorization] WHERE Login='" + TextLogin.Text + "')";
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        if (command.ExecuteScalar() != null)
                        {
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();
                        }

                        string sqlExpression2 = "SELECT Id FROM Employee WHERE IdAuthorization = (SELECT Id FROM [Authorization] WHERE Login='" + TextLogin.Text + "')";
                        SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                        if (command2.ExecuteScalar() != null)
                        {
                            AdminWindow admin = new AdminWindow();
                            admin.Show();

                            this.Close();
                        }
                     
                    }
                }
                else
                {
                    MessageBox.Show("неверный логин или пароль");
                }

            }
            else
            {
                MessageBox.Show("неправильно введена капча");
            }

         
        }

      

   

        private void btnCap_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }

        private void TBRegistr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegWindow reg = new RegWindow();
            reg.Show();
            this.Close();
        }
    }

}
