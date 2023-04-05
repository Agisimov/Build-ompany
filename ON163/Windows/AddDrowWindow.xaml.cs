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
    /// Логика взаимодействия для AddDrowWindow.xaml
    /// </summary>
    public partial class AddDrowWindow : Window
    {
        public AddDrowWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
            }
            else
            {
                DB.Drawing drawing = new DB.Drawing();
                drawing.Title = tbTitle.Text;
                drawing.PhotoPath = tbPhoto.Text;
                context.Drawing.Add(drawing);
                context.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }
           
          

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
