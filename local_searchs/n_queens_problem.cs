using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class n_queens_problem : ICSP<int[]>
    {
        public int constraint_satisfaction(int[] state)
        {
            int n = state.Length;
            int score = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int dif = j - i;
                    if (state[i] == state[j] || state[i] == state[j] + dif || state[i] == state[j] - dif)
                        score--;
                }
            }
            return score;
            throw new NotImplementedException();
        }

        public int[][] neighbors_states(int[] state)
        {
            int n = state.Length;
            int row = n * (n - 1);
            int[][] output = new int[row][];
            for (int i = 0; i < row; i++)
            {
                output[i] = (int[])state.Clone();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    int k = i * (n - 1) + j;
                    output[k][i] = (output[k][i] + j + 1) % n;
                }
            }
            return output;
            throw new NotImplementedException();
        }

        public Boolean total_satisfaction(int[] state)
        {
            return (constraint_satisfaction(state) == 0);
        }

        public Boolean total_satisfaction(int score)
        {
            return (score == 0);
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
    }
}
