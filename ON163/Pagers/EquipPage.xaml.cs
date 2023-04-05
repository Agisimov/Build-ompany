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
    /// Логика взаимодействия для EquipPage.xaml
    /// </summary>
    public partial class EquipPage : Page
    {
        public EquipPage()
        {
            InitializeComponent();
            EquipGrid.ItemsSource = ClassHelper.EFClass.context.Equipment.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddQuipWindow addQuipWindow = new AddQuipWindow();
            addQuipWindow.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = EquipGrid.SelectedItems.Cast<Equipment>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Equipment.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                EquipGrid.ItemsSource = context.Equipment.ToList();
            }
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Poisk.Text))
            {
                EquipGrid.ItemsSource = context.Equipment.ToList();
                return;
            }
            EquipGrid.ItemsSource = context.Equipment.ToList().Where(i => i.Title.Contains(Poisk.Text));
        }

        private void ismena_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Сохранено");
        }

        private void obnova_Click(object sender, RoutedEventArgs e)
        {
            EquipGrid.ItemsSource = ClassHelper.EFClass.context.Equipment.ToList();
        }
    }
}
