using BlazorEngimaWeb.EnigmaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEnigmaWeb.EnigmaModel
{
    public class EnigmaService : IEnigmaService
    {
        Enigma enigma = new();

        public char Encrypt(char letter)
        {
            return enigma.Encrypt(letter);
        }
    }
}
