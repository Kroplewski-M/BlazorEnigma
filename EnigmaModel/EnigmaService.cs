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

        public void SetNotch(int rotar, int notch)
        {
            enigma.SetNotch(rotar, notch); 
        }

        public void SetPosition(int rotar, int position)
        {
            enigma.SetPosition(rotar, position);
        }
        public int GetPosition(int rotar)
        {
            return enigma.GetPosition(rotar);
        }
        public int GetNotch(int notch)
        {
            return enigma.GetNotch(notch);
        }
        public int GetSelectedRotar(int rotar)
        {
            return enigma.GetSelectedRotar(rotar);
        }
    }
}
