using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTI
{
    class RailFence
    {
        public static string Encipher(string input, int key)
        {
            int cycle = (key * 2) - 2;
            int length = input.Length;

            if (cycle == 0)
            {
                cycle = 1;
            }

            float pow = length / cycle;
            int fullCycle = (int)Math.Round(pow, MidpointRounding.ToEven);
            string output = "";

            string[] arr = new string[key];
            int i = 0;

            for (int k = 0; k < key; k++)
            {
                i = k;
                while (i < length)
                {
                    if (k == 0 || k == key - 1)
                    {
                        arr[k] += input[i];
                        i += cycle;
                    }
                    else
                    {
                        int sPow = i + (cycle - (2 * k));
                        if (sPow >= length)
                        {
                            arr[k] += input[i];
                            i += cycle;
                        }
                        else
                        {
                            arr[k] += input[i];
                            arr[k] += input[i + (cycle - (2 * k))];
                            i += cycle;
                        }
                    }
                }
            }

            for (int k = 0; k < key; k++)
            {
                output += arr[k];
            }

            return output;
        }

        public static string Decipher(string input, int key)
        {
            if (key == 1)
            {
                return input;
            }

            int length = input.Length;
            List<List<int>> railFence = new List<List<int>>();
            
            for (int i = 0; i < key; i++)
            {
                railFence.Add(new List<int>());
            }

            int line = 0, incr = 1;
            for (int i = 0; i < length; i++)
            {
                if (line + incr == key)
                {
                    incr = -1;
                }
                else if(line + incr == -1)
                {
                    incr = 1;
                }

                railFence[line].Add(i);
                line += incr;
            }

            int c = 0;
            char[] output = new char[length];

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < railFence[i].Count; j++)
                {
                    output[railFence[i][j]] = input[c];
                    c++;
                }
            }

            return new string(output);
        }
    }
}
