using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Rotar
    {
        private readonly int[] wiring;
        private int notch;
        private int position;


        public Rotar(int[] wiring,int notch,int position)
        {
            this.wiring = wiring;
            this.notch = notch;
            this.position = position;
        }
        public void Rotate()
        {
            position++;
            if (position == 26)
                position = 0;
        }
        public bool IsAtNotch()
        {
            return position == notch;
        }
        //Encrypts a letter using the rotar's wiring
        public char Encrypt(char letter, bool isInverse = false)
        {
            int inputIndex = letter - 'A';
            int adjustedIndex = (inputIndex - position + 26) % 26;

            int outputIndex = isInverse ? Array.IndexOf(wiring, adjustedIndex) : wiring[adjustedIndex];

            int encryptedLetter = ((outputIndex + position) % 26);

            return (char)(encryptedLetter+'A');
        }
        public void SetPosition(int position)
        {
            this.position = position;
        }
        public void SetNotch(int notch)
        {
            this.notch = notch;
        }
        public int GetPosition()
        {
            return position;
        }
        public int GetNotch()
        {
            return notch;
        }
    }
}
