using System;
using System.Collections.Generic;

namespace TTTBots
{
    public class GreedySearch : ISearchStrategy
    {
        private readonly List<Node> Fringe = new List<Node>();
        private readonly IGoalCheck GoalCheck;
        public GreedySearch(IGoalCheck goalCheck)
        {
            this.GoalCheck = goalCheck;
        }
        public Node Search(Node StartNode, char CurrentPlayer)
        {
            
            if (GoalCheck.CheckGoal(StartNode, CurrentPlayer))
            {
                
                return StartNode;
            }
            StartNode.adjacentNodes.ForEach(n => {
                n.precursor = StartNode;
                Fringe.Add(n);

            });
            Node nextNode = null;
            StartNode.adjacentNodes.ForEach(n =>
            {
                if(nextNode == null)
                {
                    nextNode = n;
                }
                else
                {
                    if(heuristicFunktion(n.value as char[,], CurrentPlayer) > heuristicFunktion(nextNode.value as char[,], CurrentPlayer))
                    {
                        nextNode = n;
                    }
                }
                
            });

            //Node goalNode = Search(nextNode, CurrentPlayer);

            //if (goalNode != null)
            //{
            //    if (goalNode.precursor != null)
            //    {
            //        //StartNode soll nicht zurückgegeben werden, da der nächste Schritt berechnet werden soll
            //        if (goalNode.precursor.value != StartNode.value)
            //        {
            //            //Gebe Vorgänger zurück
            //            return goalNode.precursor;
            //        }
            //    }
            //}

            return nextNode;
        }

        public Node Search(Node StartNode, char CurrentPlayer, Node currentNode)
        {
            Fringe.Clear();
            if (GoalCheck.CheckGoal(StartNode, CurrentPlayer))
            {
                return StartNode;
            }
            StartNode.adjacentNodes.ForEach(n => Fringe.Add(n));
            Fringe.ForEach(n =>
            {
                heuristicFunktion(n.value as char[,], CurrentPlayer);
            });
            return Search(StartNode, CurrentPlayer);
        }



        public int heuristicFunktion(char[,] raster, char currentPlayer)
        {
            int score = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (!char.IsWhiteSpace(raster[i, 1]) && raster[i, 1] == currentPlayer)
                {
                    if (raster[i, 1] == raster[i, 0] && raster[i, 1] == raster[i, 2])
                    {
                        score += 1000;
                    }
                }
                if (!char.IsWhiteSpace(raster[1, i]) && raster[1, i] == currentPlayer)
                {
                    if (raster[1, i] == raster[0, i] && raster[1, i] == raster[2, i])
                    {
                        score += 1000;
                    }
                }
            }
            if (!char.IsWhiteSpace(raster[1, 1]) && raster[1, 1] == currentPlayer)
            {
                if (raster[1, 1] == raster[0, 0] && raster[1, 1] == raster[2, 2] || raster[1, 1] == raster[2, 0] && raster[1, 1] == raster[0, 2])
                {
                    score += 1000;
                }
            }

            for (int i = 0; i <= 2; i++)
            {
                for (int n = 0; n <= 2; n++)
                {
                    if (!char.IsWhiteSpace(raster[i, n]) && raster[i, n] == currentPlayer)
                    {
                        if (!(i + 1 > 2))
                        {
                            if (raster[i, n] == raster[i + 1, n])
                            {
                                score += 50;
                            }
                        }
                        if (!(n + 1 > 2))
                        {
                            if (raster[i, n] == raster[i, n + 1])
                            {
                                score += 50;
                            }
                        }
                        if (!(i - 1 < 0))
                        {
                            if (raster[i, n] == raster[i - 1, n])
                            {
                                //score += 50;
                            }
                        }
                        if (!(n - 1 < 0))
                        {
                            if (raster[i, n] == raster[i, n - 1])
                            {
                                //score += 50;
                            }
                        }
                        if (!(i + 1 > 2 || n + 1 > 2))
                        {
                            if (raster[i, n] == raster[i + 1, n + 1])
                            {
                                score += 50;
                            }
                        }

                        if (!(i - 1 < 0 || n + 1 > 2))
                        {
                            if (raster[i, n] == raster[i - 1, n + 1])
                            {
                                score += 50;
                            }
                        }


                    }
                }
            }
            return score;
        }
    }
}
