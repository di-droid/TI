using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTI
{
    class Column
    {
        private static int[,] Cipher(int len, string str)
        {
            int length = str.Length;
            int arrHeight = (int)Math.Ceiling((decimal)len / (decimal)length) + 2;
            int[,] arr = new int[length, arrHeight];
            int num = 1, pos;

            for (int i = 0; i < length; i++)
            {
                arr[i, 0] = str[i];
            }

            for (int i = 0; i < length; i++)
            {
                pos = 0;

                for (int j = 0; j < length; j++)
                {
                    if (arr[j, 0] < arr[pos, 0])
                    {
                        pos = j;
                    }
                }

                arr[pos, 1] = num++;
                arr[pos, 0] = 256;
            }
            
            return arr;
        }

        public static string Encipher(string input, string key)
        {
            int arrHeight = (int)Math.Ceiling((decimal)input.Length / (decimal)key.Length) + 2;
            int[,] arr = Cipher(input.Length, key);

            int n = 0, k = 2;
            for (int i = 0; i < input.Length; i++)
            {
                arr[n, k] = input[i];
                n++;

                if(n == key.Length)
                {
                    n = 0;
                    k++;
                }
            }

            string output = "";
            for (int i = 1; i <= key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (arr[j, 1] == i)
                    {
                        for(k = arrHeight - 1; k > 1; k--)
                        {
                            if (arr[j, k] != '\0')
                            {
                                output += Convert.ToChar(arr[j, k]);
                            }
                        }

                        break;
                    }
                }
            }

            return output;
        }

        public static string Decipher(string input, string key)
        {
            int arrHeight = (int)Math.Ceiling((decimal)input.Length / (decimal)key.Length) + 2;
            int remain = ((arrHeight - 2) * key.Length) - input.Length;
            int[,] arr = Cipher(input.Length, key);

            int len, n = input.Length - 1;
            for (int i = key.Length; i >= 1; i--)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (arr[j, 1] == i)
                    {
                        if (j >= key.Length - remain)
                        {
                            len = arrHeight - 1;
                        }
                        else
                        {
                            len = arrHeight;
                        }

                        for (int k = 2; k < len; k++)
                        {
                            arr[j, k] = input[n--];
                        }

                        break;
                    }
                }
            }

            string output = "";
            for (int j = 2; j < arrHeight; j++)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (arr[i, j] != '\0')
                    {
                        output += Convert.ToChar(arr[i, j]);
                    }
                }
            }

            return output;
        }
    }
}
