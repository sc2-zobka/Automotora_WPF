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
//Call to import all objects of AutomotoraLibrary ( eg: Enum )
using AutomotoraLibrary;

namespace Automotora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        private AutomotoraCollection _coleccion = new AutomotoraCollection();



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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Fase 1
            //Fetch all data from the fields in the form view (MainW Window)

            string patente = txtPatente.Text;

            //SelectedIndex returns an int (cbo element position).
            //marca var doesn't support an int so a parse action is needeed (Marcas).
            Marcas marca = (Marcas)cboMarca.SelectedIndex;

            string modelo = txtModelo.Text;

            //textAnio returns a string so a parse action is needed, eg: int.Parse()
            //However an user could type a letter which will crashed "int.Parse()"
            //Finally anio is set 0, in order to validate via IF statement
            int anio = 0;

            //int.TryParse (returns TRUE or FALSE) if parse action was accomplished
            //<out> convierte en "variable de salida" a <anio>
            if (int.TryParse(txtAnio.Text, out anio) == false)
            {
                MessageBox.Show("El año debe ser in número", "ERROR");
                //return to stop the execution
                return;

            }
            // .Value returns False or True based on what the user typed
            bool nuevo = chkNuevo.IsChecked.Value;

            //transmision var is set 
            Transmisiones transmision = Transmisiones.Automatica;

            if (rbtMecanica.IsChecked == true)
            {
                transmision = Transmisiones.Mecanica;
            }

            try
            {
                //Fase 2
                //Create an instance of automovil
                Automovil auto = new Automovil();
                auto.Patente = patente;
                auto.Marca = marca;
                auto.Modelo = modelo;
                auto.Anio = anio;
                auto.Nuevo = nuevo;
                auto.Transmision = transmision;

                //Fase 3
                ////Guardar los datos en la coleccion
                if (_coleccion.GuardarAutomovil(auto))
                {
                    MessageBox.Show("Guardado correctamente");
                }
                else
                {
                    MessageBox.Show("La patente ya existe");

                }

                //show car info in DataGrid
                CargarGrilla(); 
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }



            
        }
        private void CargarGrilla()
        {
            dgAutomoviles.ItemsSource = null;
            dgAutomoviles.ItemsSource = _coleccion.automoviles;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string patente = txtPatente.Text;

            //Check whether a TextBox is empty or not 
            //Trim(): remove blank spaces from left and right
            if (patente.Trim() == "")
            {
                MessageBox.Show("Se debe ingresar una patente");
                return;
            }

            //if not empty then: 
            Automovil auto = _coleccion.BuscarAutomovil(patente);
            
            //if car doesn't exist in the collection, then:
            if(auto == null)
            {
                MessageBox.Show("No se ha encontrado la patente");
                return;
            }

            //if car exists in the collection, then we pass car's attributes
            //to the form fields (MainWindows)

            cboMarca.SelectedIndex = (int)auto.Marca;
            txtModelo.Text = auto.Modelo;
            txtAnio.Text = auto.Anio.ToString();
            chkNuevo.IsChecked = auto.Nuevo;

            if(auto.Transmision == Transmisiones.Automatica)
            {
                rbtAutomatica.IsChecked = true;
            }
            else
            {
                rbtMecanica.IsChecked = true;
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string patente = txtPatente.Text;

            if(patente.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una patente");
                return;
            }

            if(_coleccion.EliminarAutomovil(patente))
            {
                MessageBox.Show("Automovil ha sido eliminado");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No se ha encontrado la patente");
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //Fase 1
            //Fetch all data from the fields in the form view (MainW Window)

            string patente = txtPatente.Text;

            //SelectedIndex returns an int (cbo element position).
            //marca var doesn't support an int so a parse action is needeed (Marcas).
            Marcas marca = (Marcas)cboMarca.SelectedIndex;

            string modelo = txtModelo.Text;

            //textAnio returns a string so a parse action is needed, eg: int.Parse()
            //However an user could type a letter which will crashed "int.Parse()"
            //Finally anio is set 0, in order to validate via IF statement
            int anio = 0;

            //int.TryParse (returns TRUE or FALSE) if parse action was accomplished
            //<out> convierte en "variable de salida" a <anio>
            if (int.TryParse(txtAnio.Text, out anio) == false)
            {
                MessageBox.Show("El año debe ser in número", "ERROR");
                //return to stop the execution
                return;

            }
            // .Value returns False or True based on what the user typed
            bool nuevo = chkNuevo.IsChecked.Value;

            //transmision var is set 
            Transmisiones transmision = Transmisiones.Automatica;

            if (rbtMecanica.IsChecked == true)
            {
                transmision = Transmisiones.Mecanica;
            }

            try
            {
                //Fase 2
                //Create an instance of automovil
                Automovil auto = _coleccion.BuscarAutomovil(patente);

                if(auto == null)
                {
                    MessageBox.Show("No se ha encontrado la patente");
                    return;
                }
                auto.Patente = patente;
                auto.Marca = marca;
                auto.Modelo = modelo;
                auto.Anio = anio;
                auto.Nuevo = nuevo;
                auto.Transmision = transmision;

                MessageBox.Show("Modificado correctamente");

                //show car info in DataGrid
                CargarGrilla();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {

            ListadoAutomoviles listado = new ListadoAutomoviles(this._coleccion);
            listado.Show();
            listado.Focus();
            /*
            ListadoAutomoviles.Instance.Show();
            ListadoAutomoviles.Instance.Coleccion = this._coleccion;
            ListadoAutomoviles.Instance.Focus();
            */
        }
    }
}
