using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class local_beam_search<STATE>
    {
        public STATE solve(ICSP<STATE> csp, STATE[] beams, int number_of_beams)
        {
            List<STATE> new_beams = beams.ToList<STATE>();
            while (new_beams.Count != 0)
            {
                MyDictionary<STATE, int> better_neighbors = new MyDictionary<STATE, int>();
                foreach (STATE beam in new_beams)
                {
                    STATE[] neighbors = csp.neighbors_states(beam);
                    int beam_score = csp.constraint_satisfaction(beam);
                    foreach (STATE neighbor in neighbors)
                    {
                        int score = csp.constraint_satisfaction(neighbor);
                        if (csp.total_satisfaction(score))
                            return neighbor;
                        if (beam_score < score)
                            better_neighbors.Add(neighbor, score);
                    }
                }

                if (better_neighbors.Count() == 0)//trapped in local optimum
                {
                    STATE best_state=new_beams.First();
                    int best_score = int.MinValue;
                    foreach (STATE beam in new_beams)
                    {
                        int score = csp.constraint_satisfaction(beam);
                        if (best_score < score)
                        {
                            best_score = score;
                            best_state = beam;
                        }
                    }
                    return best_state;
                }

                better_neighbors.SortByValue();
                new_beams = new List<STATE>(number_of_beams);
                for (int i = 0; i < number_of_beams; i++)
                {
                    if (better_neighbors.IsEmpty()) break;
                    new_beams.Add(better_neighbors.Pop().Key);
                }
                number_of_beams = new_beams.Count;
            }

            throw new ArgumentException("out of beam", "state[] beams");
        }
    }
}
