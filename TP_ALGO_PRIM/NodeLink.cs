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

        private Random rnd;
        public Direction direction { get; }
        public int val { get; private set; }

        public NodeLink(Node primaryNode, Node secondaryNode, int val, Direction direction)
        {
            this.direction = direction;
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
