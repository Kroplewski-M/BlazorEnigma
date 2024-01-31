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
            this.wiring = wiring ?? new Dictionary<char, char>();
        }
        public void AddPlug(char end1, char end2)
        {
            wiring.Add(end1, end2);
            wiring.Add(end2, end1);
        }
        public void RemovePlug(char end1,char end2)
        {
            wiring.Remove(end1);
            wiring.Remove(end2);
        }
        public bool IsPlugged(char letter)
        {
            return wiring.ContainsKey(letter);
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
        public Dictionary<char, char> GetPlugs()
        {
            Dictionary<char, char> plugs = [];

            foreach(var plug in wiring)
            {
                if (!plugs.ContainsKey(plug.Key) && !plugs.ContainsKey(plug.Value))
                    plugs.Add(plug.Key, plug.Value);
            }
            return plugs;
        }
    }
}
