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
//Import Library
using AutomotoraLibrary;

namespace Automotora
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu
    {
        private AutomotoraCollection _coleccion = new AutomotoraCollection();

        public Menu()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gestion = new MainWindow(this._coleccion);
            gestion.Show();
            gestion.Focus();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            ListadoAutomoviles listado = new ListadoAutomoviles(this._coleccion);
            listado.Show();
            listado.Focus();
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);   
        }
    }
}
