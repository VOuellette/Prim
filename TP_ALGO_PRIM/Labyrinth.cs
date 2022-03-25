using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ALGO_PRIM
{
    class Labyrinth
    {
        public Graph graph { get; set; }

        public Labyrinth(Graph graph)
        {
            this.graph = graph;
        }

        public Graph GetSolution()
        {
            return this.graph.Prim();
        }
    }
}
