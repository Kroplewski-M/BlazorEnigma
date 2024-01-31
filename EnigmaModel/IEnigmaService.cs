using BlazorEngimaWeb.EnigmaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEnigmaWeb.EnigmaModel
{
    public interface IEnigmaService
    {
        char Encrypt(char letter);
        void SetPosition(int rotar, int position);
        void SetNotch(int rotar, int notch);
        int GetPosition(int rotar);
        int GetNotch(int notch);
        public int GetSelectedRotar(int rotar);
        public void SetRotar(int rotar, int rotarNumber);
        public void SetPlug(char end1, char end2);
        public void RemovePlug(char end1, char end2);
        public bool IsPlugged(char letter);
        public Dictionary<char, char> GetPlugs();
    }
}
