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
using System.Windows.Shapes;
using static ON163.ClassHelper.EFClass;
using ON163.DB;

namespace ON163.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddQuipWindow.xaml
    /// </summary>
    public partial class AddQuipWindow : Window
    {
        public AddQuipWindow()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DB.Equipment equipment = new DB.Equipment();
            equipment.Title = tbTitle.Text;
            equipment.Discription = tbDisc.Text;
            context.Equipment.Add(equipment);
            context.SaveChanges();
        }
    }
}
