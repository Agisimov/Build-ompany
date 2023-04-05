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
using ON163.Pagers;
using ON163.DB;
using ON163.Windows;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для EmpPage.xaml
    /// </summary>
    public partial class EmpPage : Page
    {
        public EmpPage()
        {
            InitializeComponent();
          EmpGrid.ItemsSource = ClassHelper.EFClass.context.Employee.ToList();
          
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = EmpGrid.SelectedItems.Cast<Employee>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Employee.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
               EmpGrid.ItemsSource = context.Employee.ToList();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        { 
            AddEmpWindow addEmpWindow = new AddEmpWindow();
            addEmpWindow.Show();
            
           
        }

        private void PoiskFamilii_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskFamilii.Text))
            {
                EmpGrid.ItemsSource = context.Employee.ToList();
                return;
            }
            EmpGrid.ItemsSource = context.Employee.ToList().Where(i => i.LastName.Contains(PoiskFamilii.Text));
        }

        private void PoiskImy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskImy.Text))
            {
                EmpGrid.ItemsSource = context.Employee.ToList();
                return;
            }
            EmpGrid.ItemsSource = context.Employee.ToList().Where(i=> i.FirstName.Contains(PoiskImy.Text));
        }

        private void ismena_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            EmpGrid.ItemsSource = ClassHelper.EFClass.context.Employee.ToList();
            MessageBox.Show("Сохранено");
        }

        private void obnova_Click(object sender, RoutedEventArgs e)
        {
            EmpGrid.ItemsSource = ClassHelper.EFClass.context.Employee.ToList();
        }
    }
}
