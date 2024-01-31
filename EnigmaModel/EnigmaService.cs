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

        public void SetRotar(int rotar, int rotarNumber)
        {
            enigma.SetRotar(rotar, rotarNumber);
        }

        public void SetPlug(char end1, char end2)
        {
            enigma.SetPlug(end1, end2);
        }

        public void RemovePlug(char end1, char end2)
        {
            enigma.RemovePlug(end1, end2);
        }

        public bool IsPlugged(char letter)
        {
            return enigma.IsPlugged(letter);
        }
        public Dictionary<char, char> GetPlugs()
        {
            return enigma.GetPlugs();
        }
    }
}
