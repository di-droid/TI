using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTI
{
    class RotatingLattice
    {
        private static int[,] RotationMatrix(ref int[,] matrix)
        {
            int[,] TMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    TMatrix[j, matrix.GetLength(0) - 1 - i] = matrix[i, j];
                }
            }

            matrix = TMatrix;
            return matrix;
        }

        private static void InitMatrix(ref char[,] matrix)
        {
            char c;
            Random r = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    c = Convert.ToChar(r.Next(97, 122));
                    matrix[i, j] = c;
                }
            }
        }

        private static void FillMatrix(ref char[,] matrix, ref int[,] grid, string input, ref int k)
        {
            for (int time = 1; time <= 4; time++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int j = 0;
                    while (j < matrix.GetLength(1) && k < input.Length)
                    {
                        if (grid[i, j] == 0)
                        {
                            matrix[i, j] = input[k++];
                        }

                        j++;
                    }
                }

                grid[2, 2] = 7;
                if (time != 4)
                {
                    RotationMatrix(ref grid);
                }
            }
        }

        private static void FromMatrixToStr(ref char[,] matrix, ref string output)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += matrix[i, j];
                }
            }
        }

        private static void FromStrToMatrix(ref char[,] matrix, ref string input, ref int k)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j = 0;

                while (j < matrix.GetLength(1) && k < input.Length)
                {
                    matrix[i, j] = input[k];
                    j++;
                    k++;
                }
            }
        }

        private static void FillStr(ref char[,] matrix, ref int[,] grid, string input, ref string output)
        {
            char c;
            bool flag = true;

            for (int time = 1; time <= 4; time++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (grid[i, j] == 0)
                        {
                            c = matrix[i, j];
                            if (c == 'а')
                            {
                                flag = !flag;    
                            }
                            
                            if (flag)
                            {
                                output += c;
                            }
                        }
                    }
                }

                grid[2, 2] = 7;
                if (time != 4)
                {
                    RotationMatrix(ref grid);
                }
            }
        }

        public static string Encipher(string input)
        {
            string output = "";
            const int size = 5;
            int k = 0;
            char[,] matrix = new char[size, size];
            int times = input.Length % (size * size);
            
            if (times == 0)
            {
                times = input.Length / (size * size);
            }
            else
            {
                times = input.Length / (size * size) + 1;
            }

            if (input.Length != 25)
            {
                input += 'а';
            }
            
            int i = 1;
            while (i <= times)
            {
                int[,] grid = 
                {
                    { 0, 2, 0, 4, 1 },
                    { 2, 5, 6, 5, 0 },
                    { 3, 6, 0, 0, 3 },
                    { 4, 0, 6, 5, 4 },
                    { 1, 0, 3, 2, 1 }
                };

                InitMatrix(ref matrix);
                FillMatrix(ref matrix, ref grid, input, ref k);
                FromMatrixToStr(ref matrix, ref output);

                i++;
            }

            return output;
        }

        public static string Decipher(string input)
        {
            string output = "";
            const int size = 5;
            int k = 0;
            char[,] matrix = new char[size, size];
            int times = input.Length % (size * size);

            if (times == 0)
            {
                times = input.Length / (size * size);
            }
            else
            {
                times = input.Length / (size * size) + 1;
            }

            int i = 1;
            while (i <= times)
            {
                int[,] grid = 
                {
                    { 0, 2, 0, 4, 1 },
                    { 2, 5, 6, 5, 0 },
                    { 3, 6, 0, 0, 3 },
                    { 4, 0, 6, 5, 4 },
                    { 1, 0, 3, 2, 1 }
                };

                FromStrToMatrix(ref matrix, ref input, ref k);
                FillStr(ref matrix, ref grid, input, ref output);

                i++;
            }

            return output;
        }
    }
}
