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
    }
}
