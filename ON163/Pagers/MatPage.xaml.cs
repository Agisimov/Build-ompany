using ON163.DB;
using ON163.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ON163.ClassHelper.EFClass;
using ON163.DB;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для MatPage.xaml
    /// </summary>
    public partial class MatPage : Page
    {
        public MatPage()
        {
            InitializeComponent();
            MatGrid.ItemsSource = ClassHelper.EFClass.context.Material.ToList(); 

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddMatWindow addMatWindow = new AddMatWindow();
            addMatWindow.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = MatGrid.SelectedItems.Cast<Material>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Material.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                MatGrid.ItemsSource = context.Material.ToList();
            }
        }
    }
}
