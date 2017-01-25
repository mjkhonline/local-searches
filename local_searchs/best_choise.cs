using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class best_choise<STATE>: hill_climbing<STATE>
    {
        public override STATE next_state(ICSP<STATE> csp, STATE state)
        {
            STATE best_neighbor = state;
            int best_score = csp.constraint_satisfaction(state);
            STATE[] neighbors = csp.neighbors_states(state);
            foreach (STATE node in neighbors)
            {
                int score = csp.constraint_satisfaction(node);
                if (best_score < score)
                {
                    best_score = score;
                    best_neighbor = node;
                }
            }
            return best_neighbor;
        }
    }
}
