using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Enigma
    {
        //create default rotars
        Rotar rotarI = new ([4, 10, 12, 5, 11, 6, 3, 16, 21, 25, 13, 19, 14, 22, 24, 7, 23, 20, 18, 15, 0, 8, 1, 17, 2, 9], 10, 5);
        Rotar rotarII = new ([0, 9, 3, 10, 18, 8, 17, 20, 23, 1, 11, 7, 22, 19, 12, 2, 16, 6, 25, 13, 15, 24, 5, 21, 14, 4], 0, 19);
        Rotar rotarIII = new ([1, 3, 5, 7, 9, 11, 2, 15, 17, 19, 23, 21, 25, 13, 24, 4, 8, 22, 6, 0, 10, 12, 20, 18, 16, 14], 5, 8);
        Rotar rotarIV = new ([4, 18, 14, 21, 15, 25, 9, 0, 24, 16, 20, 8, 17, 7, 23, 11, 13, 5, 19, 6, 10, 3, 2, 12, 22, 1], 17, 22);
        Rotar rotarV = new ([21, 25, 1, 17, 6, 8, 19, 24, 20, 15, 18, 3, 13, 7, 11, 23, 0, 22, 12, 9, 16, 14, 5, 4, 2, 10], 15, 20);

        Rotar[] rotars = new Rotar[5];
        int[] chosenRotars = new int[3];

        Reflector reflectorB = new([24, 17, 20, 7, 16, 18, 11, 3, 15, 23, 13, 6, 14, 10, 12, 8, 4, 1, 5, 25, 2, 22, 21, 9, 0, 19]);
        public Plugboard plugboard = new();
        public Enigma()
        {
            //set rotars
            rotars[0] = rotarI;
            rotars[1] = rotarII;
            rotars[2] = rotarIII;
            rotars[3] = rotarIV;
            rotars[4] = rotarV;

            chosenRotars[0] = 0;
            chosenRotars[1] = 1;
            chosenRotars[2] = 2;

        }
        //encrypt a letter
        public char Encrypt(char letter)
        {
           letter = plugboard.Process(letter);
            rotars[chosenRotars[0]].Rotate();
            letter = rotars[chosenRotars[0]].Encrypt(letter);
            if (rotars[chosenRotars[0]].IsAtNotch())
            {
                rotars[chosenRotars[1]].Rotate();
            }
            letter = rotars[chosenRotars[1]].Encrypt(letter);
            if (rotars[chosenRotars[1]].IsAtNotch())
            {
                rotars[chosenRotars[2]].Rotate();
            }
            letter = rotars[chosenRotars[2]].Encrypt(letter);
            letter = reflectorB.Reflect(letter);
            letter = rotars[chosenRotars[2]].Encrypt(letter, true);
            letter = rotars[chosenRotars[1]].Encrypt(letter, true);
            letter = rotars[chosenRotars[0]].Encrypt(letter, true);
            letter = plugboard.Process(letter);
            return letter;
        }
        public void SetPosition(int rotar, int position)
        {
            rotars[chosenRotars[rotar]].SetPosition(position);
        }
        public void SetNotch(int rotar, int notch)
        {
            rotars[chosenRotars[rotar]].SetNotch(notch);
        }
        public int GetPosition(int rotar)
        {
            return rotars[chosenRotars[rotar]].GetPosition();
        }
        public int GetNotch(int rotar)
        {
            return rotars[chosenRotars[rotar]].GetNotch();
        }
        public void SetRotar(int rotar, int rotarNumber)
        {
            chosenRotars[rotar] = rotarNumber;
        }
        public int GetSelectedRotar(int rotar)
        {
            return chosenRotars[rotar];
        }
        public void SetPlug(char end1, char end2)
        {
            plugboard.AddPlug(end1, end2);
        }
        public void RemovePlug(char end1, char end2)
        {
            plugboard.RemovePlug(end1, end2);
        }
        public bool IsPlugged(char letter)
        {
            return plugboard.IsPlugged(letter);
        }
        public Dictionary<char, char> GetPlugs()
        {
            return plugboard.GetPlugs();
        }
    }
}
