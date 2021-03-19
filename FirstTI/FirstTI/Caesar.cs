using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTI
{
    class Caesar
    {
        private static char Cipher(char c, int key)
        {
            if(!char.IsLetter(c))
            {
                return c;
            }

            char gain = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + key) - gain) % 26) + gain);
        }

        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach(char c in input)
            {
                output += Cipher(c, key);
            }

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
