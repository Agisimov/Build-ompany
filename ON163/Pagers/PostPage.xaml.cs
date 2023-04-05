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
using ON163.DB;
using  ON163.Pagers;
using ON163.Windows;
using static ON163.ClassHelper.EFClass;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        public PostPage()
        {
            InitializeComponent();
            PostGrid.ItemsSource = ClassHelper.EFClass.context.Post.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddPostWindow addPostWindow = new AddPostWindow();
            addPostWindow.Show();
            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = PostGrid.SelectedItems.Cast<Post>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Post.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                PostGrid.ItemsSource = context.Post.ToList();
            }
        }

        private void ismena_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Сохранено");
        }

        private void obnova_Click(object sender, RoutedEventArgs e)
        {
            PostGrid.ItemsSource = ClassHelper.EFClass.context.Post.ToList();
        }
    }
}
