using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class helper
    {
        public static int[] generate_random_array(int size)
        {
            return generate_random_array(size, size);
        }

        public static int[] generate_random_array(int size, int domain)
        {
            int[] output = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                output[i] = rnd.Next(domain);
            return output;
        }

        public static bool[,] generate_random_graph(int number_of_nodes)
        {
            bool[,] output = new bool[number_of_nodes, number_of_nodes];
            bool val = false;
            Random rnd = new Random();
            for (int i = 0; i < number_of_nodes; i++)
            {
                for (int j = i + 1; j < number_of_nodes; j++)
                {
                    if (rnd.NextDouble() < 0.5)
                        val = true;
                    else
                        val = false;

                    output[i, j] = val;
                    output[j, i] = val;
                }
            }
            return output;
        }
    }
}
