using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Reflector
    {
        private string Wiring;
        public Reflector(string wiring)
        {
            this.Wiring = wiring;
        }
        public char Reflect(char input)
        {
            return Wiring[input - 'A'];
        }
    }
}
