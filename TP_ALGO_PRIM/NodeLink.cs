using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ALGO_PRIM
{
    class NodeLink
    {
        public Node primaryNode { get; }
        public Node secondaryNode { get; }
        Random rnd;
        public int val { get; private set; }

        public NodeLink(Node primaryNode, Node secondaryNode, int val)
        {
            this.primaryNode = primaryNode;
            this.secondaryNode = secondaryNode;
            this.val = val;
            this.rnd = new Random();
        }

        public NodeLink(int val)
        {
            this.val = val;
        }

        public void GenerateWeight()
        {
            this.val = this.rnd.Next(1, 11);
        }

        public override string ToString()
        {
            return this.val.ToString() + " ";
        }
    }
}
