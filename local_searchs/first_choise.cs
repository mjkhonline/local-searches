using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class first_choise<STATE> : hill_climbing<STATE>
    {
        public override STATE next_state(ICSP<STATE> csp, STATE state)
        {
            int current_score = csp.constraint_satisfaction(state);
            STATE[] neighbors = csp.neighbors_states(state);
            foreach (STATE node in neighbors)
            {
                if (current_score < csp.constraint_satisfaction(node))
                    return node;
            }
            return state;
        }
    }
}
