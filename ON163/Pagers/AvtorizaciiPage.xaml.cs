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
using static ON163.ClassHelper.EFClass;
using ON163.DB;
using System.Windows.Shapes;
using ON163.Windows;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для AvtorizaciiPage.xaml
    /// </summary>
    public partial class AvtorizaciiPage : Page
    {
        public AvtorizaciiPage()
        {
            InitializeComponent();
            AvtorGrid.ItemsSource = ClassHelper.EFClass.context.Authorization.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddAthoWindow addAthoWindow = new AddAthoWindow();
            addAthoWindow.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = AvtorGrid.SelectedItems.Cast<Authorization>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Authorization.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                AvtorGrid.ItemsSource = context.Authorization.ToList();
            }
        }
    }
}
