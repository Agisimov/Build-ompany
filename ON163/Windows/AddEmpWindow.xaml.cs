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


        }
    }
}
