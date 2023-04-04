using ON163.Windows;
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
using ON163.DB;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для SupPage.xaml
    /// </summary>
    public partial class SupPage : Page
    {
        public SupPage()
        {
            InitializeComponent();
            SupGrid.ItemsSource = ClassHelper.EFClass.context.Supplier.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddSuppWindow addSuppWindow = new AddSuppWindow();
            addSuppWindow.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = SupGrid.SelectedItems.Cast<Supplier>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Supplier.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                SupGrid.ItemsSource = context.Supplier.ToList();
            }
        }

        private void PoiskFamilii_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskFamilii.Text))
            {
                SupGrid.ItemsSource = context.Supplier.ToList();
                return;
            }
            SupGrid.ItemsSource = context.Supplier.ToList().Where(i => i.Title.Contains(PoiskFamilii.Text));
        }

        private void PoiskImy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskImy.Text))
            {
                SupGrid.ItemsSource = context.Supplier.ToList();
                return;
            }
            SupGrid.ItemsSource = context.Supplier.ToList().Where(i => i.Phone.Contains(PoiskImy.Text));
        }
    }
}
