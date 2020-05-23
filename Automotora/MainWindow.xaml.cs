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
//Call to import all objects in AutomotoraLibrary ( eg: Enum )
using AutomotoraLibrary;

namespace Automotora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Method that initialize all dragged components on the main window ( texbox, buttons, comboBox, etc..)
            InitializeComponent();

            /*
             * add all logic after InitializeComponent()
             */

            //ItemsSource receives and then displays a list of elements coming from a Enum. ( Enum Marcas )
            cboMarca.ItemsSource = Enum.GetValues(typeof(Marcas));
            cboMarca.SelectedIndex = 0;
        }
    }
}
