using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class graph_coloring : ICSP<int[]>
    {
        private int c;//number of available colors
        private int n;//number of node
        private bool[,] matrix;//Adjacency matrix

        public graph_coloring(bool[,] adjacency_matrix, int number_of_available_colors)
        {
            matrix = adjacency_matrix;
            c = number_of_available_colors;
            n = adjacency_matrix.GetLength(0);
        }

        public bool[,] get_matrix()
        {
            return matrix;
        }

        public int number_of_colors()
        {
            return c;
        }

        public int number_of_nodes()
        {
            return n;
        }

        public int constraint_satisfaction(int[] state)
        {
            int score = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] && state[i] == state[j])//the same color for neighbors
                        score--;
                }
            }
            return score;
            throw new NotImplementedException();
        }
        
        public int[][] neighbors_states(int[] state)
        {
            int row = n * (c - 1);
            int[][] output = new int[row][];
            for (int i = 0; i < row; i++)
            {
                output[i] = (int[])state.Clone();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c - 1; j++)
                {
                    int k = i *(c-1) + j;
                    output[k][i] = (output[k][i] + j + 1) % c;
                }
            }
            return output;

            throw new NotImplementedException();
        }

        public Boolean total_satisfaction(int[] state)
        {
            return (constraint_satisfaction(state) == 0);
        }

        public Boolean is_equal_state(int[] stateA, int[] stateB)
        {
            int n = stateA.Length;
            int m = stateB.Length;
            if (m == n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (stateA[i] != stateB[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool total_satisfaction(int score)
        {
            return (score == 0);
        }
    }
}
