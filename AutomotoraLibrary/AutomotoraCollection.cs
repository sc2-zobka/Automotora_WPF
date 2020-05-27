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
        //List variable of "Automovil" type to store all car instanced.
        public List<Automovil> automoviles = new List<Automovil>();

        //GuardarAutomovil method to store cars in List<Automovil>
        //Metodo para guardar todos los autos en la coleccion ( List<Atomovil> )
        public bool GuardarAutomovil(Automovil automovil)
        {
            
            this.automoviles.Add(automovil);
            return true;

        }
    }
}
