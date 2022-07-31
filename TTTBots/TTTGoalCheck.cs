namespace TTTBots
{
    public class TTTGoalCheck : IGoalCheck
    {
        public bool CheckGoal(Node node, char CurrentPlayer)
        {
            char[,] tempRaster = node.value as char[,];


            if (!char.IsWhiteSpace(tempRaster[1, 1]) && tempRaster[1, 1] == CurrentPlayer)
            {
                if (tempRaster[1, 1] == tempRaster[1, 0] && tempRaster[1, 1] == tempRaster[1, 2])
                {
                    return true;
                }
                if (tempRaster[1, 1] == tempRaster[0, 1] && tempRaster[1, 1] == tempRaster[2, 1])
                {
                    return true;
                }
                if (tempRaster[1, 1] == tempRaster[0, 0] && tempRaster[1, 1] == tempRaster[2, 2])
                {
                    return true;
                }
                if (tempRaster[1, 1] == tempRaster[2, 0] && tempRaster[1, 1] == tempRaster[0, 2])
                {
                    return true;
                }
            }

            if (!char.IsWhiteSpace(tempRaster[2, 0]) && tempRaster[2, 0] == CurrentPlayer)
            {
                if (tempRaster[2, 0] == tempRaster[2, 1] && tempRaster[2, 0] == tempRaster[2, 2])
                {
                    return true;
                }
                if (tempRaster[2, 0] == tempRaster[0, 0] && tempRaster[2, 0] == tempRaster[1, 0])
                {
                    return true;
                }
            }

            if (!char.IsWhiteSpace(tempRaster[0, 2]) && tempRaster[0, 2] == CurrentPlayer)
            {
                if (tempRaster[0, 2] == tempRaster[0, 1] && tempRaster[0, 2] == tempRaster[0, 0])
                {
                    return true;
                }
                if (tempRaster[0, 2] == tempRaster[2, 2] && tempRaster[0, 2] == tempRaster[1, 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
