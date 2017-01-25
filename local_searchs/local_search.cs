using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    interface ILocal_Search<STATE>
    {
        STATE solve(ICSP<STATE> csp, STATE initialize_state);
        STATE next_state(ICSP<STATE> csp, STATE state);
    }
}
