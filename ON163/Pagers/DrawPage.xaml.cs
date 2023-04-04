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
    /// Логика взаимодействия для DrawPage.xaml
    /// </summary>
    public partial class DrawPage : Page
    {
        public DrawPage()
        {
            InitializeComponent();
            DrawGrid.ItemsSource = ClassHelper.EFClass.context.Drawing.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDrowWindow addDrowWindow = new AddDrowWindow();
            addDrowWindow.Show();

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = DrawGrid.SelectedItems.Cast<ON163.DB.Drawing>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Drawing.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                DrawGrid.ItemsSource = context.Drawing.ToList();
            }
        }
    }
}
