using System;
using TTTBots;

namespace wf_tictactoe
{
    public class Bot
    {
        public ISearchStrategy SearchStrategy { get; set; }

        public Tuple<int,int> TakeAction(char[,] raster)
        {
            Node tree = TreeFactory.CreateTree(in raster, 'O');
            //ISearchStrategy Search = new DepthSearch(new TTTGoalCheck());
            var treePath = SearchStrategy.Search(tree, 'O');

            if (treePath != null)
            {
                char[,] f = treePath.value as char[,];

                for (int i = 0; i < raster.GetLength(0); i++)
                {
                    for (int n = 0; n < raster.GetLength(1); n++)
                    {
                        if (f[i, n] != raster[i, n])
                        {
                            //button_click((Buttons[i, n] as Button), null);
                            return Tuple.Create(i,n);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < raster.GetLength(0); i++)
                {
                    for (int n = 0; n < raster.GetLength(1); n++)
                    {
                        if (char.IsWhiteSpace(raster[i, n]))
                        {
                            //button_click((Buttons[i, n] as Button), null);
                            return Tuple.Create(i, n);
                        }
                    }
                }
            }

            return null;
        }

    }
}
