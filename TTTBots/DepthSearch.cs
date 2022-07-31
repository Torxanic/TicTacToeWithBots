using System.Collections.Generic;

namespace TTTBots
{
    public class DepthSearch : ISearchStrategy
    {
        IGoalCheck GoalCheck;

        public DepthSearch(IGoalCheck goalCheck)
        {
            this.GoalCheck = goalCheck;
        }

        public Node Search(Node startNode, char CurrentPlayer)
        {
            List<Node> traversedNodes = new List<Node>();

            Node node = Search(startNode, traversedNodes, out bool isGoal, CurrentPlayer); // Rekursiver Aufruf der Methode mit dem Nachbarknoten als Startknoten

            if (isGoal)
            {
                return node;
            }

            return null;
        }


        public Node Search(Node startNode, in List<Node> traversedNodes, out bool isGoal, char CurrentPlayer)
        {
            isGoal = false;

            foreach (Node node in startNode.adjacentNodes) // foreach-Schleife, die alle benachbarten Knoten des Knotens durchläuft
            {

                if (GoalCheck.CheckGoal(node, CurrentPlayer))
                {

                    isGoal = true;
                    traversedNodes.Add(node);
                    return node;
                }

                if (!traversedNodes.Contains(node)) // Wenn der Knoten noch nicht markiert wurde
                {
                    Search(node, traversedNodes, out isGoal, CurrentPlayer); // Rekursiver Aufruf der Methode mit dem Nachbarknoten als Startknoten
                    if (isGoal)
                    {
                        return node;
                    }
                }

            }

            return null;
        }
    }
}
