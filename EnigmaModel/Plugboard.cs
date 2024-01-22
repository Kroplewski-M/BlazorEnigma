using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Plugboard
    {
        private Dictionary<char, char> wiring;
        public Plugboard(Dictionary<char, char> wiring = null)
        {
            this.wiring = wiring;
        }
        public void AddPlug(char end1, char end2)
        {
            wiring.Add(end1, end2);
            wiring.Add(end2, end1);
        }
        public char Process(char letter)
        {
            if(wiring == null)
                return letter;
            else
            {
                if (wiring.ContainsKey(letter))
                    return wiring[letter];
                else
                    return letter;
            }
        }
    }
}
