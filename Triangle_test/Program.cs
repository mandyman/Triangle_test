using System;
using System.Linq;
using System.IO;

namespace Triangle_test
{
    class TriangleMaxSumCalculator
    {
        static public double Calculate(int[][] triangle)
        {
            double[] current_sum = new double[] { triangle[0][0] };

            for (int i = 1; i < triangle.Length; i++)
            {
                double[] temp_array = new double[current_sum.Length + 1];

                if (temp_array.Length > 2)
                {
                    for (int j = 1; j < triangle[i].Length - 1; j++)
                    {
                        temp_array[j] = Math.Max(triangle[i][j] + current_sum[j - 1], triangle[i][j] + current_sum[j]);
                    }
                }

                temp_array[0] = triangle[i][0] + current_sum[0];
                temp_array[temp_array.Length - 1] = triangle[i][triangle[i].Length - 1] + current_sum[current_sum.Length - 1];

                current_sum = temp_array;
            }

            return current_sum.Max();

        }
    }

    class Program
    {
        static int[][] ReadTriangle(string file_path)
        {
            StreamReader reader = new StreamReader(file_path);
            string[] rows_array = reader.ReadToEnd().Split('\r');

            int[][] triangle = new int[rows_array.Length][];

            for (int i = 0; i < rows_array.Length; i++)
            {
                string[] str_values = rows_array[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int[] values = new int[str_values.Length];

                for (int j = 0; j < str_values.Length ; j++)
                {
                    values[j] = int.Parse(str_values[j]);
                }

                triangle[i] = values;
            }
            
            reader.Close();
            return triangle;
        }
        static void Main(string[] args)
        {
            /*int[][] triangle = new int[][]
            {
                new int[]{ 5 },
                new int[]{ 9, 6 },
                new int[]{ 4, 6, 8 },
                new int[]{ 0, 7, 1, 5 },
            };

            int[][] triangle2 = new int[][]
            {
                new int[]{ 23 },
                new int[]{ 48, 33 },
                new int[]{ 101, 24, 3 },
                new int[]{ 93, 68, 25, 16 },
                new int[]{ 13, 42, 58, 43, 2 },
                new int[]{ 36, 12, 18, 73, 93, 85 }
            };

            int[][] triangle3 = new int[][]
{
                new int[]{ 49 },
                new int[]{ 488, 1 },
                new int[]{ 112, 24, 35 },
                new int[]{ 1, 1, 259, 16 },
                new int[]{ 13, 42, 58, 43, 2 },
                new int[]{ 36, 1, 48, 1, 93, 85 },
                new int[]{ 36, 1, 48, 1, 93, 333, 111 }
};

            double result = TriangleMaxSumCalculator.Calculate(triangle); // 27
            Console.WriteLine("Max sum is {0}",result);

            double result2 = TriangleMaxSumCalculator.Calculate(triangle2); // 371
            Console.WriteLine("Max sum is {0}", result2);

            double result3 = TriangleMaxSumCalculator.Calculate(triangle3); // 1289
            Console.WriteLine("Max sum is {0}", result3);
            */

            int[][] triangle4 = ReadTriangle("../../../resources/Triangle.txt"); // 732506
            double result4 = TriangleMaxSumCalculator.Calculate(triangle4);
            Console.WriteLine("Max sum is {0}", result4);

            
        }
    }
}
