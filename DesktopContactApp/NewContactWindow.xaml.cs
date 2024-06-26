﻿using DesktopContactApp.Classes;
using SQLite;
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

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
            
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save contact
            Contact contact = new()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneTextBox.Text
            };

            using (SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            Close();
        }
    }
}
