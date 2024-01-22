using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Reflector
    {
        private int[] wiring;
        public Reflector(int[] wiring)
        {
            this.wiring = wiring;
        }
        public char Reflect(char letter)
        {
            int inputIndex = letter - 'A';
            int outputIndex = wiring[inputIndex];
            int reflectedLetter = (char)(outputIndex + 'A');
            return (char)reflectedLetter;
        }
    }
}
