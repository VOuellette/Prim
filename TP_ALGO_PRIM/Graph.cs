using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ALGO_PRIM
{
    class Graph
    {
        public Dimension dim { get; }
        public Node[,] nodes { get; private set; }
        Random rnd = new Random();
        private Node[,] newNodes;

        public Graph(Dimension dim)
        {
            this.dim = dim;
            InitNodes();
        }

        public Graph(Node[,] newNodes)
        {
            this.newNodes = newNodes;
            this.dim = new Dimension(newNodes.GetLength(1), newNodes.GetLength(0));
        }

        public Graph Prim()
        {
            int startRow = rnd.Next(0, dim.y);

            int nodeRow = 0;
            int nodeCol = 0;
            int minLinkIndex = 0;

            int ctrBoucleExterne = 0;

            List<Node> B = new();
            List<NodeLink> S = new();

            NodeLink minLink;
            Node n;
            Node minNode;

            Node[,] newNodes = new Node[dim.y, dim.x];

            B.Add(nodes[0, 0]);
            while(B.Count != dim.x * dim.y)
            {
                minLink = new NodeLink(100);
                minNode = new Node();

                // On Boucle dans les Nodes
                for (int row = 0; row < this.dim.y; row++)
                {
                    for (int col = 0; col < this.dim.x; col++)
                    {
                        n = nodes[row, col];

                        if (!B.Contains(n)) continue;

                        for(int i = 0; i < n.links.Count; i++)
                        {
                            NodeLink nl = n.links[i];
                            if (nl.val < minLink.val && !B.Contains(nl.secondaryNode))
                            {
                                minLink = nl;
                                minNode = n;

                                nodeRow = row;
                                nodeCol = col;
                            }
                        }
                    }
                }

                if (ctrBoucleExterne != 0)
                    B.Add(minLink.secondaryNode);

                // Reste a formatter et les node et links pour l'affichage

                /*minNode.links.Clear();
                minNode.links.Add(minLink);

                newNodes[nodeRow, nodeCol] = minNode;  */              

                ++ctrBoucleExterne;
            }

            Debug.WriteLine("Prim done :)\n");
            Graph newGraph = new Graph(newNodes);

            return newGraph;
        }

        public void LinkAllNodes()
        {
            // On assume que la liste de Nodes a été initialisée avec succès
            for (int row = 0; row < this.dim.y; row++)
            {
                for (int col = 0; col < this.dim.x; col++)
                {
                    // Liens du haut et du bas
                    if (row - 1 >= 0) this.nodes[row, col].AddLink(this.nodes[row - 1, col], 0);
                    if (row + 1 < this.dim.y) this.nodes[row, col].AddLink(this.nodes[row + 1, col], 0);

                    // Liens de gauche et de droite
                    if (col - 1 >= 0) this.nodes[row, col].AddLink(this.nodes[row, col - 1], 0);
                    if (col + 1 < this.dim.x) this.nodes[row, col].AddLink(this.nodes[row, col + 1], 0);
                }
            }
        }

        internal void GenerateWeights()
        {
            Debug.WriteLine("");
            for (int row = 0; row < this.dim.y; row++)
            {
                for (int col = 0; col < this.dim.x; col++)
                {
                    nodes[row, col].GenerateWeights();
                    Debug.Write(nodes[row, col].links.Count + " ");
                }
                Debug.Write("\n");
            }
            Debug.WriteLine("");
        }

        private void InitNodes()
        {
            if (this.dim == null) return;

            this.nodes = new Node[this.dim.y, this.dim.x];

            for (int row = 0; row < this.dim.y; row++)
            {
                for(int col = 0; col < this.dim.x; col++)
                {
                    this.nodes[row, col] = new Node();
                }
            }
        }
    }
}
