﻿using System;
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
using ON163.Pagers;
using ON163.DB;
using ON163.Windows;

namespace ON163.Pagers
{
    /// <summary>
    /// Логика взаимодействия для EmpPage.xaml
    /// </summary>
    public partial class EmpPage : Page
    {
        public EmpPage()
        {
            InitializeComponent();
          EmpGrid.ItemsSource = ClassHelper.EFClass.context.Employee.ToList();
          
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var remove = EmpGrid.SelectedItems.Cast<Employee>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                context.Employee.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
               EmpGrid.ItemsSource = context.Employee.ToList();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        { 
            AddEmpWindow addEmpWindow = new AddEmpWindow();
            addEmpWindow.Show();
            
           
        }
    }
}
