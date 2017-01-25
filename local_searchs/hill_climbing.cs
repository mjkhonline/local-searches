using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    abstract class hill_climbing<STATE> : ILocal_Search<STATE>
    {
        public STATE solve(ICSP<STATE> csp, STATE initialize_state)
        {
            STATE state = initialize_state;
            while (!csp.total_satisfaction(state))
            {
                STATE next = next_state(csp, state);
                if (csp.is_equal_state(state, next))//trapped in local optimum
                    return state;
                state = next;
            }
            return state;
        }

        public abstract STATE next_state(ICSP<STATE> csp, STATE state);
 
    }
}
