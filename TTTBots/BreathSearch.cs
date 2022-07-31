using System.Collections.Generic;

namespace TTTBots
{
    public class BreathSearch : ISearchStrategy
    {
        private readonly Queue<Node> Fringe = new Queue<Node>();
        private readonly IGoalCheck GoalCheck;
        public BreathSearch(IGoalCheck goalCheck)
        {
            this.GoalCheck = goalCheck;
        }
        public Node Search(Node StartNode, char CurrentPlayer)
        {
            List<Node> emptyList = new List<Node>();
            Fringe.Clear();
            Fringe.Enqueue(StartNode);
            return Search(StartNode, emptyList, CurrentPlayer);
        }

        public Node Search(Node StartNode, List<Node> traversedNodes, char CurrentPlayer)
        {            
            if (Fringe.Count == 0)
            {
                //Ziel nicht gefunden
                return null;
            }
            Node node = Fringe.Dequeue();
            traversedNodes.Add(node);
            if (GoalCheck.CheckGoal(node, CurrentPlayer))
            {
                return node;
            }
            //Hinzufügen der nachfolgenden Knoten in den Fringe
            node.adjacentNodes.ForEach(n =>
            {
                n.precursor = node;
                Fringe.Enqueue(n);
            });

            Node goalNode = Search(StartNode, traversedNodes, CurrentPlayer);

            if (goalNode != null)
            {
                if (goalNode.precursor != null)
                {
                    //StartNode soll nicht zurückgegeben werden, da der nächste Schritt berechnet werden soll
                    if (goalNode.precursor.value != StartNode.value)
                    {
                        //Gebe Vorgänger zurück
                        return goalNode.precursor;
                    }
                }
            }

            return goalNode;
        }
    }
}
