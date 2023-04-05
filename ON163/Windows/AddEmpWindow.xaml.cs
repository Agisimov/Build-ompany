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
using ON163.Pagers;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmpWindow.xaml
    /// </summary>
    public partial class AddEmpWindow : Window
    {
        public AddEmpWindow()
        {
            InitializeComponent();
            cmbPost.ItemsSource = context.Post.ToList();
            cmbPost.SelectedIndex = 0;
            cmbPost.DisplayMemberPath = "Title";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFName.Text))
            {
                MessageBox.Show("Имя не можеь быть устым");
            }
            else if(string.IsNullOrWhiteSpace(tbFName.Text))
            {
                MessageBox.Show("Фамилия не можеь быть пустой");
            }
            else if (string.IsNullOrWhiteSpace(tbPatr.Text))
            {
                MessageBox.Show("Отчество не можеь быть пустой");
            }
            else if (string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {
                MessageBox.Show("Дата не можеь быть пустой");
            }
            else if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Почта не можеь быть пустой");
            }
            else if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не можеь быть пустым");
            }
            else
            {
                DB.Employee employee = new Employee();
                employee.FirstName = tbFName.Text;
                employee.LastName = tbFName.Text;
                employee.Patronymic = tbPatr.Text;
                employee.BirthDay = dpBirthDay.SelectedDate.Value;
                employee.Email = tbFName.Text;
                employee.Phone = tbFName.Text;
                employee.IdPost = (cmbPost.SelectedItem as Post).Id;
                context.Employee.Add(employee);
                context.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }





         

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
        }
    }
}
