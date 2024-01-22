using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEngimaWeb.EnigmaModel
{
    public class Enigma
    {
        Rotar rotarI = new ([8, 2, 12, 5, 18, 10, 3, 15, 20, 25, 13, 19, 14, 22, 24, 7, 23, 21, 9, 16, 0, 4, 1, 17, 6, 11], 10, 5);
        Rotar rotarII = new ([5, 1, 15, 7, 2, 11, 17, 14, 9, 0, 18, 12, 16, 24, 23, 20, 8, 25, 22, 19, 6, 21, 10, 3, 13, 4], 0, 19);
        Rotar rotarIII = new ([15, 4, 25, 20, 14, 7, 23, 18, 2, 21, 5, 12, 19, 1, 6, 11, 17, 8, 13, 16, 0, 24, 22, 10, 3, 9], 5, 8);
        Rotar rotarIV = new ([25, 14, 20, 4, 18, 24, 3, 10, 5, 22, 15, 2, 8, 16, 23, 7, 12, 21, 1, 11, 6, 13, 9, 17, 0, 19], 17, 22);
        Rotar rotarV = new ([22, 26, 9, 10, 12, 13, 14, 24, 6, 25, 11, 23, 7, 8, 15, 16, 17, 18, 19, 20, 21, 1, 2, 3, 4, 5], 15, 20);

        Reflector reflectorB = new ([24, 17, 20, 7, 16, 18, 11, 3, 15, 23, 13, 6, 14, 10, 12, 8, 4, 1, 5, 25, 2, 22, 21, 9, 0, 19]);
        Plugboard plugboard = new();
        
        public char Encrypt(char letter)
        {
           letter = plugboard.Process(letter);
            rotarI.Rotate();
            letter = rotarI.Encrypt(letter);
            if (rotarI.IsAtNotch())
            {
                rotarII.Rotate();
            }
            letter = rotarII.Encrypt(letter);
            if (rotarII.IsAtNotch())
            {
                rotarIII.Rotate();
            }
            letter = rotarIII.Encrypt(letter);
            letter = reflectorB.Reflect(letter);
            letter = rotarIII.Encrypt(letter, true);
            letter = rotarII.Encrypt(letter, true);
            letter = rotarI.Encrypt(letter, true);
            letter = plugboard.Process(letter);
            return letter;
        }
    }
}
