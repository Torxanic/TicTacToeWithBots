using System;
using System.Collections.Generic;

namespace TTTBots
{
    public static class TreeFactory
    {
        public static Node CreateTree(in char[,] startRaster, char currentPlayer)
        {

            Node startNode = new Node { index = 0, value = startRaster };
            if (IsArrayFull(startRaster))
            {
                return startNode;
            }


            char[,] oldRaster = new char[3, 3];
            Array.Copy(startRaster, oldRaster, 9);
            char[,] newRaster = new char[3, 3];
            Array.Copy(startRaster, newRaster, 9);
            int highestIndex = startNode.index;
            char newPlayer;
            if (currentPlayer == 'X')
            {
                newPlayer = 'O';
            }
            else
            {
                newPlayer = 'X';
            }

            for (int i = 0; i < oldRaster.GetLength(0); i++)
            {
                for (int n = 0; n < oldRaster.GetLength(1); n++)
                {
                    if (char.IsWhiteSpace(oldRaster[i, n]))
                    {
                        char[,] addRaster = new char[3, 3];
                        Array.Copy(oldRaster, addRaster, 9);
                        addRaster[i, n] = currentPlayer;
                        highestIndex++;
                        Node newNode = new Node { index = highestIndex, value = addRaster };
                        startNode.adjacentNodes.Add(newNode);
                    }
                }
            }



            startNode.adjacentNodes.ForEach(node =>
            {
                var raster = (char[,])node.value;
                var upperNode = CreateTree(raster, newPlayer);
                upperNode.adjacentNodes.ForEach(node2 => node.adjacentNodes.Add(node2));

            });

            return startNode;
        }

        public static List<Node> CreateTree(char[,] startRaster, char currentPlayer, int index)
        {
            Node startNode = new Node { index = index, value = startRaster };
            char[,] oldRaster = new char[3, 3];
            Array.Copy(startRaster, oldRaster, 9);
            char[,] newRaster = new char[3, 3];
            Array.Copy(startRaster, newRaster, 9);
            int highestIndex = startNode.index;
            char newPlayer = 'X';
            if (currentPlayer == 'X')
            {
                newPlayer = 'O';
            }

            for (int i = 0; i < oldRaster.GetLength(0); i++)
            {
                for (int n = 0; n < oldRaster.GetLength(1); n++)
                {
                    if (char.IsWhiteSpace(oldRaster[i, n]))
                    {
                        newRaster[i, n] = currentPlayer;
                        Node newNode = new Node { index = highestIndex++, value = newRaster, adjacentNodes = CreateTree(newRaster, newPlayer, highestIndex++) };
                        startNode.adjacentNodes.Add(newNode);
                        Array.Copy(oldRaster, newRaster, 9);
                    }
                }
            }

            return startNode.adjacentNodes;
        }

        private static bool IsArrayFull(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int n = 0; n < array.GetLength(1); n++)
                {
                    if (char.IsWhiteSpace(array[i, n]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
