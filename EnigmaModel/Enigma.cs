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
        readonly Rotar rotarI = new ("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 0, 0);
        readonly Rotar rotarII = new ("AJDKSIRUXBLHWTMCQGZNPYFVOE", 0, 0);
        readonly Rotar rotarIII = new ("BDFHJLCPRTXVZNYEIWGAKMUSQO", 0, 0);
        readonly Rotar rotarIV = new ("ESOVPZJAYQUIRHXLNFTGKDCMWB", 0,0);
        readonly Rotar rotarV = new ("VZBRGITYUPSDNHLXAWMJQOFECK", 0, 0);

        readonly Rotar[] rotars = new Rotar[5];
        int[] chosenRotars = new int[3];

        readonly Reflector reflectorA = new("EJMZALYXVBWFCRQUONTSPIKHGD");
        readonly Reflector reflectorB = new("YRUHQSLDPXNGOKMIEBFZCWVJAT");
        readonly Reflector reflectorC = new("FVPJIAOYEDRZXWGCTKUQSBNMHL");

        Reflector[] reflectors = new Reflector[3];
        int selectedReflector = 1;
        public Plugboard plugboard = new();
        public Enigma()
        {
            //set rotars
            rotars[0] = rotarI;
            rotars[1] = rotarII;
            rotars[2] = rotarIII;
            rotars[3] = rotarIV;
            rotars[4] = rotarV;

            chosenRotars[0] = 2;
            chosenRotars[1] = 1;
            chosenRotars[2] = 0;

            reflectors[0] = reflectorA;
            reflectors[1] = reflectorB;
            reflectors[2] = reflectorC;
        }
        //encrypt a letter
        public char Encrypt(char letter)
        {
           letter = plugboard.Process(letter);
            rotars[chosenRotars[0]].Rotate();
            letter = rotars[chosenRotars[0]].Encrypt(letter);
            bool hasRotated = false;
            if (rotars[chosenRotars[0]].IsAtNotch())
            {
                rotars[chosenRotars[1]].Rotate();
                hasRotated = true;
            }
            letter = rotars[chosenRotars[1]].Encrypt(letter);
            if (hasRotated && rotars[chosenRotars[1]].IsAtNotch())
            {
                rotars[chosenRotars[2]].Rotate();
            }
            letter = rotars[chosenRotars[2]].Encrypt(letter);
            letter = reflectors[selectedReflector].Reflect(letter);
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
        public void SetSelectedReflector(int reflector)
        {
            selectedReflector = reflector;
        }
        public int GetSelectedReflector()
        {
            return selectedReflector;
        }
        public Rotar GetRotar(int rotar)
        {
            return rotars[rotar];
        }
    }
}
