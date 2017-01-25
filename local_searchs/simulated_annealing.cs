using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class simulated_annealing<STATE> : ILocal_Search<STATE>
    {
        private double temp;
        private double cooling_factor;
        private const double Freezing_temperature = 0.0;

        public simulated_annealing(double initial_temperature, double cooling_factor)
        {
            temp = initial_temperature;
            this.cooling_factor = cooling_factor;
        }

        public STATE solve(ICSP<STATE> csp, STATE initialize_state)
        {
            STATE state = initialize_state;
            while (!csp.total_satisfaction(state) && temp > Freezing_temperature)
            {
                state = next_state(csp, state);
                cool_down();
            }
            return state;
        }

        public STATE next_state(ICSP<STATE> csp, STATE state)
        {
            int current_score = csp.constraint_satisfaction(state);
            STATE[] neighbors = csp.neighbors_states(state);
            foreach (STATE node in neighbors)
            {
                int neighbor_socre = csp.constraint_satisfaction(node);
                int delta = neighbor_socre - current_score;
                if (accept(temp, delta))
                    return node;
            }
            return state;
        }

        private bool accept(double temperature, double delta)
        {
            if (delta >= 0)
                return true;
            double probability = Math.Exp(delta / temperature);
            Random rnd = new Random();
            if (rnd.NextDouble() < probability)
                return true;
            return false;

            throw new DivideByZeroException("temperature couldn't be zero!");
        }

        private void cool_down()
        {
            temp -= cooling_factor;
        }

    }
}
