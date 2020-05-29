using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotoraLibrary
{

    //Collection Class which will store cars
    public class AutomotoraCollection
    {
        //List var of "Automovil" type to store all car instanced.
        public List<Automovil> automoviles = new List<Automovil>();

        //GuardarAutomovil method to store cars in List<Automovil>
        //Metodo para guardar todos los autos en la coleccion ( List<Atomovil> )
        public bool GuardarAutomovil(Automovil automovil)
        {
            //Validar si automovil ya se encuentra en la coleccion
            foreach (Automovil i in automoviles)
            {
                if(i.Patente == automovil.Patente)
                {
                    return false;  
                }

            }

            this.automoviles.Add(automovil);
            return true;

        }

        public Automovil BuscarAutomovil(string patente)
        {
            foreach (Automovil i in automoviles)
            {
                if(i.Patente == patente)
                {
                    return i;
                }
            }

            return null;
        }

        public bool EliminarAutomovil(string patente)
        {
            Automovil auto = this.BuscarAutomovil(patente);
            
            if(auto == null)
            {
                return false;
            }

            this.automoviles.Remove(auto);
            return true;
        }
        //Metodo que retorna un List<Automovil> que dentro trae un automovil 
        public List<Automovil> BuscarPorPatente(string patente)
        {
            //Consult LINQ
            //ToList() makes the LINQ Query to return a List<>
            List<Automovil> automoviles = (from a in this.automoviles
                                           where a.Patente.ToLower().Contains(patente)
                                           select a).ToList();
            return automoviles;
        }
    }
}
