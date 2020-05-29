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
using AutomotoraLibrary;

namespace Automotora
{
    /// <summary>
    /// Lógica de interacción para ListadoAutomoviles.xaml
    /// </summary>
    public partial class ListadoAutomoviles : Window
    {
        private AutomotoraCollection _coleccion;

        public AutomotoraCollection Coleccion
        {
            get { return _coleccion; }
            set { _coleccion = value; }
        }

        //Parameterless constructor
        public ListadoAutomoviles()
        {
            InitializeComponent();
        }

        //Parameterized constructor
        public ListadoAutomoviles(AutomotoraCollection coleccion)
        {
            this.Coleccion = coleccion;
            InitializeComponent();
            dgAutomoviles.ItemsSource = this.Coleccion.automoviles;
        }

        private void txtPatente_KeyUp(object sender, KeyEventArgs e)
        {
            //Fetch a plate into patente (from xaml layer)
            string patente = txtPatente.Text;

            //Fetch a car into automoviles. Car is already filtered by LINQ Query inside BuscarPorPatente()
            List<Automovil> automoviles = this.Coleccion.BuscarPorPatente(patente);

            //Refresh datagrid
            dgAutomoviles.ItemsSource = null;
            
            //Fetch collection in order to show it on datagrid.
            dgAutomoviles.ItemsSource = automoviles;
        }
    }
}
