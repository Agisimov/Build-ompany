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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            ClientGrid.ItemsSource = ClassHelper.EFClass.context.Client.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = ClientGrid.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Client.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ClientGrid.ItemsSource = context.Client.ToList();
            }
        }

        private void PoiskFamilii_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskFamilii.Text))
            {
                ClientGrid.ItemsSource = context.Client.ToList();
                return;
            }
            ClientGrid.ItemsSource = context.Client.ToList().Where(i => i.LastName.Contains(PoiskFamilii.Text));
        }

        private void PoiskImy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PoiskImy.Text))
            {
                ClientGrid.ItemsSource = context.Client.ToList();
                return;
            }
            ClientGrid.ItemsSource = context.Client.ToList().Where(i => i.FirstName.Contains(PoiskImy.Text));
        }

        private void ismena_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Сохранено");
        }

        private void obnova_Click(object sender, RoutedEventArgs e)
        {
            ClientGrid.ItemsSource = ClassHelper.EFClass.context.Client.ToList();
        }
    }
}
