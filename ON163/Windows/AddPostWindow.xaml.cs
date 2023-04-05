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
    /// Логика взаимодействия для AddPostWindow.xaml
    /// </summary>
    public partial class AddPostWindow : Window
    {
        public AddPostWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(TBTDisk.Text))
            {
                MessageBox.Show("Описание не может быть пустым");
            }
            else
            {
                DB.Post post = new Post();
                post.Title = TBTitle.Text;
                post.Discription = TBTDisk.Text;
                context.Post.Add(post);
                context.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
               
            }



            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
        }
    }
}
