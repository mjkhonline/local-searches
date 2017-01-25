using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    interface ICSP<STATE>
    {
        // methods signatures:
        STATE[] neighbors_states(STATE state);
        int constraint_satisfaction(STATE state);
        Boolean total_satisfaction(STATE state);
        Boolean total_satisfaction(int score);
        Boolean is_equal_state(STATE stateA, STATE stateB);
    }
}
