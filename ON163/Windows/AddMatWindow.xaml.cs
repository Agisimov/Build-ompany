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
using ON163.DB;
using static ON163.ClassHelper.EFClass;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddMatWindow.xaml
    /// </summary>
    public partial class AddMatWindow : Window
    {
        public AddMatWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Назване не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(tbDisc.Text))
            {
                MessageBox.Show("Описние не может быть пустым");
            }
            else
            {
                DB.Material material = new DB.Material();
                material.Title = tbTitle.Text;
                material.Discription = tbDisc.Text;
                context.Material.Add(material);
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
