using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ALGO_PRIM
{
    class GameController
    {
        private ViewController vc;
        private Labyrinth lab;
        private Dimension labDim;
        private MainWindow window;
        
        public GameController(MainWindow window, Dimension labDim)
        {
            this.labDim = labDim;
            this.window = window;
        }

        public void GenererLabyrinthe()
        {
            Graph graph = new Graph(this.labDim);
            graph.LinkAllNodes();
            graph.GenerateWeights();

            this.lab = new Labyrinth(graph);
            Graph solution = this.lab.GetSolution();
            window.DrawGraph(solution);
        }
    }
}
