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
    }
}
