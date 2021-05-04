using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetFileRouge
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logiciel développer par Michael Helinckx, Serge Buasa et Matthieu Rith ©2021", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
