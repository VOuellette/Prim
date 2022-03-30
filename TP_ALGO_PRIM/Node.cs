using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_ALGO_PRIM
{
    class Node
    {
        public List<NodeLink> links { get; } = new();
        public NodeLink linkFrom { get; set; } = null;
        public void AddLink(Node node, int val, Direction direction) 
        {
            Boolean verification = true;
            foreach (NodeLink link in node.links) 
            {
                if (link.secondaryNode == this) 
                {
                    verification = false;
                }
            }

            if (verification)
            {
                this.links.Add(new NodeLink(this, node, val, direction));
            }
        }

        public void GenerateWeights()
        {
            foreach(NodeLink link in this.links)
            {
                link.GenerateWeight();
            }
        }

        public override string ToString()
        {
            string res = "";

            foreach(NodeLink link in this.links)
            {
                res += link.val + " ";
            }

            return res;
        }
    }
}
