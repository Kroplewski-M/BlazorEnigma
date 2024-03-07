using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Rotar
    {
        private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string wiring;
        private int notch;
        private int position;


        public Rotar(string wiring, int notch, int position)
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
        public char Encrypt(char input, bool isInverse = false)
        {
            if (!isInverse)
            {
                int index = this.Alphabet.IndexOf(input);
                index = (index + this.position) % 26;
                var newLetter = this.wiring[index];
                var newIndex = this.Alphabet.IndexOf(newLetter);
                newIndex = (newIndex - this.position + 26) % 26;
                return this.Alphabet[newIndex];
            }
            else
            {
                var index = this.Alphabet.IndexOf(input);
                index = (index + this.position) % 26;
                var newIndex = this.wiring.IndexOf(this.Alphabet[index]);
                var newLetter = this.Alphabet[(newIndex - this.position + 26) % 26];
                return newLetter;
            }
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
