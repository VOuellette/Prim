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
        public int nbOperations { get; private set; }
        public int n2 { get; private set; }

        public Graph(Dimension dim)
        {
            this.dim = dim;
            InitNodes();
        }

        public Graph(Node[,] newNodes)
        {
            this.nodes = newNodes;
            this.dim = new Dimension(newNodes.GetLength(1), newNodes.GetLength(0));
            this.n2 = dim.x * dim.y;
        }

        public Graph Prim()
        {
            nbOperations = 0;

            List<Node> B = new();
            List<NodeLink> S = new();

            NodeLink minLink;

            B.Add(nodes[0, 0]);
            while(B.Count < dim.x * dim.y)
            {
                minLink = new NodeLink(100);
                foreach (Node n in B) 
                {
                    for (int i = 0; i < n.links.Count; i++)
                    {
                        nbOperations++;

                        NodeLink nl = n.links[i];

                        if (nl.val < minLink.val && !B.Contains(nl.secondaryNode))
                            minLink = nl;
                    }


                }


                minLink.secondaryNode.linkFrom = minLink;
                B.Add(minLink.secondaryNode);
                S.Add(minLink);
            }

            this.n2 = (int) Math.Pow(dim.x * dim.y, 2);
            
            Debug.WriteLine(Math.Pow(dim.x * dim.y, 2) + " | " + nbOperations);

            for (int row = 0; row < this.dim.y; row++)
            {
                for (int col = 0; col < this.dim.x; col++)
                {
                    Node n = this.nodes[row, col];
                    Node temporaryNode = new Node();
               
                    foreach (NodeLink link in n.links)
                    {
                        if (S.Contains(link))
                        {
                            temporaryNode.links.Add(link);
                        }
                    }
                    temporaryNode.linkFrom = n.linkFrom;
                    this.nodes[row, col] = temporaryNode;
                }
            }

            return new Graph(nodes);
        }

        public void LinkAllNodes()
        {
            // On assume que la liste de Nodes a été initialisée avec succès
            for (int row = 0; row < this.dim.y; row++)
            {
                for (int col = 0; col < this.dim.x; col++)
                {
                    // Liens du haut et du bas
                    if (row - 1 >= 0) this.nodes[row, col].AddLink(this.nodes[row - 1, col], 0, Direction.Top);
                    if (row + 1 < this.dim.y) this.nodes[row, col].AddLink(this.nodes[row + 1, col], 0, Direction.Bottom);

                    // Liens de gauche et de droite
                    if (col - 1 >= 0) this.nodes[row, col].AddLink(this.nodes[row, col - 1], 0, Direction.Left);
                    if (col + 1 < this.dim.x) this.nodes[row, col].AddLink(this.nodes[row, col + 1], 0, Direction.Right);
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
                }
            }
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
