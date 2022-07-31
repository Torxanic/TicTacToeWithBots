using System.Collections.Generic;

namespace TTTBots
{
    public class Node
    {
        public int index;
        public object value;
        public Node precursor;
        public List<Node> adjacentNodes = new List<Node>();

        public void ConnectNodes(Node targetNode)
        {
            this.adjacentNodes.Add(targetNode);
        }
    }
}
