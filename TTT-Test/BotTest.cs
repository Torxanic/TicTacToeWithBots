using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTTBots;

namespace TTT_Test
{
    [TestClass]
    public class BotTest
    {
        [TestMethod]
        public void testGoal()
        {
            TTTGoalCheck check = new TTTGoalCheck();
            char[,] raster = { { 'X', 'X', 'X' },{' ',' ',' '},{' ',' ',' '} };
            char[,] raster1 = { { 'X', 'O', 'X' }, { 'O', 'O', 'O' }, { ' ', ' ', ' ' } };
            char[,] raster2 = { { 'X', 'O', 'X' }, { ' ', ' ', ' ' }, { 'X', 'X', 'X' } };
            char[,] raster3 = { { 'O', 'O', 'X' }, { ' ', 'O', ' ' }, { ' ', ' ', 'O' } };
            Node node = new Node() { index = 0, value = raster};
            Node node1 = new Node() { index = 0, value = raster1 };
            Node node2 = new Node() { index = 0, value = raster2 };
            Node node3 = new Node() { index = 0, value = raster3 };

            bool result = check.CheckGoal(node, 'X') && check.CheckGoal(node1, 'O') && check.CheckGoal(node2, 'X') && check.CheckGoal(node3, 'O');
            bool expected = true;

            Assert.AreEqual(expected, result, "Account not debited correctly");
        }

        [TestMethod]
        public void testNoGoal()
        {
            TTTGoalCheck check = new TTTGoalCheck();
            char[,] raster = { { 'X', ' ', 'X' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char[,] raster1 = { { 'X', 'O', 'X' }, { 'O', 'X', 'O' }, { ' ', ' ', ' ' } };
            char[,] raster2 = { { 'X', 'O', 'X' }, { ' ', ' ', ' ' }, { 'X', 'X', 'X' } };
            char[,] raster3 = { { 'O', 'O', 'X' }, { ' ', 'X', ' ' }, { ' ', ' ', 'O' } };
            Node node = new Node() { index = 0, value = raster };
            Node node1 = new Node() { index = 0, value = raster1 };
            Node node2 = new Node() { index = 0, value = raster2 };
            Node node3 = new Node() { index = 0, value = raster3 };

            bool result = check.CheckGoal(node, 'X') || check.CheckGoal(node1, 'X') || check.CheckGoal(node2, 'O') || check.CheckGoal(node3, 'X');
            bool expected = false;

            Assert.AreEqual(expected, result, "Account not debited correctly");
        }

        [TestMethod]
        public void testHeuristic()
        {
            GreedySearch greedy = new GreedySearch(new TTTGoalCheck());
            char[,] raster = { { 'X', ' ', 'X' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char[,] raster1 = 
                { 
                                { 'X', 'X', 'X' }, 
                                { 'O', ' ', 'O' }, 
                                { ' ', ' ', ' ' } 
                };
            char[,] raster2 = 
                { 
                    { 'O', 'O', 'X' }, 
                    { ' ', 'X', ' ' }, 
                    { 'X', 'O', 'O' } 
                };
            char[,] raster3 = 
                { 
                    { 'O', 'X', 'X' }, 
                    { 'O', 'X', ' ' }, 
                    { 'O', ' ', 'O' } 
                };

            int result = greedy.heuristicFunktion(raster1, 'X');
            int result1 = greedy.heuristicFunktion(raster, 'X');
            int result2 = greedy.heuristicFunktion(raster2, 'X');
            int result3 = greedy.heuristicFunktion(raster3, 'O');
            int expected = 100;

            Assert.AreEqual(100, result, "Null");
            Assert.AreEqual(expected, result3, "Account not debited correctly");
            Assert.AreEqual(0, result1, "Account not debited correctly");
            Assert.AreEqual(expected, result2, "Account not debited correctly");
        }
    }
}
