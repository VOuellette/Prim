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
            long sumn2 = 0;
            long sumNbOperations = 0;
            int n2;
            int nbOperations;
            
            Graph graph;
            Graph solution = new Graph(this.labDim);
            
            for(int i = 0; i < window.settings.xFois; i++) {
                graph = new Graph(this.labDim);
                solution =  new Graph(this.labDim);

                graph.LinkAllNodes();
                graph.GenerateWeights();

                this.lab = new Labyrinth(graph);
                solution = this.lab.GetSolution();
                
                sumn2 += graph.n2;
                sumNbOperations += graph.nbOperations;
            }

            n2 = (int) sumn2 / window.settings.xFois;
            nbOperations = (int) sumNbOperations / window.settings.xFois;

            window.DrawGraph(solution);
            window.setSettings(n2, nbOperations);
        }
    }
}
