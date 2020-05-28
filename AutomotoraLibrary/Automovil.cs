using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotoraLibrary
{
    public class Automovil
    {
        //use underscore for private var
        private string _patente;
        private Marcas _marca;
        private string _modelo;
        private int _anio;
        private bool _nuevo;
        private Transmisiones _transmision;

        public Automovil()
        {
            //parameterless constructor. Could be useful to initialize something in the future.
        }

        //To access a private attribute (_patente) a Property is needed.
        //A Property encapsulate Get & Set (unlike Java that use two methods Get and Set)
        //shortcut for Property <propfull>
        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
        }
        public Marcas Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public string Modelo
        {
            get { return _modelo; }
            
            set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Modelo debe tener al menos 3 caracteres");
                }
                _modelo = value; 
            }
        }
        public int Anio
        {
            get { return _anio; }
            //Agrega logica de negocio
            set {
                if(value < 1950)
                {
                    throw new ArgumentException("Año debe ser mínimo 1950");
                }
                _anio = value; 
            }
        }
        public bool Nuevo
        {
            get { return _nuevo; }
            set { _nuevo = value; }
        }
        public Transmisiones Transmision
        {
            get { return _transmision; }
            set { _transmision = value; }
        }



    }
}
