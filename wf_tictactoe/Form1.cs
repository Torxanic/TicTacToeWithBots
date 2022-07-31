using System;
using System.Windows.Forms;
using System.Drawing;
using TTTBots;

namespace wf_tictactoe
{
    public partial class Form1 : Form
    {
        int i = 1;            // Runden 
        bool spieler = false; // false = X , true= Kreis
        bool spiel_ende = false;
        char[,] Raster = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        bool isBotActive = false;
        object[,] Buttons;
        Bot Bot;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Runde " + i;
            label2.Text = " Spieler: 1";

            InitButtons();
        }

        private void InitButtons()
        {
            Buttons = new object[3, 3];
            A1.Tag = new int[] { 0, 0 };
            Buttons[0, 0] = A1;

            A2.Tag = new int[] { 0, 1 };
            Buttons[0, 1] = A2;

            A3.Tag = new int[] { 0, 2 };
            Buttons[0, 2] = A3;

            B1.Tag = new int[] { 1, 0 };
            Buttons[1, 0] = B1;

            B2.Tag = new int[] { 1, 1 };
            Buttons[1, 1] = B2;

            B3.Tag = new int[] { 1, 2 };
            Buttons[1, 2] = B3;

            C1.Tag = new int[] { 2, 0 };
            Buttons[2, 0] = C1;

            C2.Tag = new int[] { 2, 1 };
            Buttons[2, 1] = C2;

            C3.Tag = new int[] { 2, 2 };
            Buttons[2, 2] = C3;
        }

        private void updateInfo()
        {
            label1.Text = "Runde " + i;
            if (spieler == false)
            {
                label2.Text = " Spieler: 1";
            }
            else
            {
                label2.Text = " Spieler: 2";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) //Help|About Button
        {
            MessageBox.Show("By Timon Gartung", "Tic Tac Toe About");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e) //Buttons zum Spielen
        {
            Button b = (Button)sender;
            int[] tag = b.Tag as int[];


            if (b.Text == "" && spiel_ende == false)
            {
                if (i == 5)
                {
                    b.Text = "X";
                    i++;
                    label1.Text = "Ende ";
                }

                if (i < 5)
                {
                    if (spieler == false)
                    {
                        b.Text = "X";
                        spieler = true;
                        Raster[tag[0], tag[1]] = 'X';
                        updateInfo();
                    }
                    else
                    {
                        b.Text = "O";
                        spieler = false;
                        i++;
                        Raster[tag[0], tag[1]] = 'O';
                        updateInfo();
                    }
                }

                spiel_ende = checkForWinner();

                if ((i == 6) && (spiel_ende == false))
                {
                    MessageBox.Show("Its a Draw", "sry for wasting your time");
                }
            }

            if (isBotActive && e != null && !spiel_ende)
            {
                spieler = true;
                var tuple = Bot.TakeAction(Raster);

                if (tuple == null)
                {

                }
                else
                {
                    button_click((Buttons[tuple.Item1, tuple.Item2] as Button), null);
                }



                spiel_ende = checkForWinner();

                if ((i == 6) && (spiel_ende == false))
                {
                    MessageBox.Show("Its a Draw", "sry for wasting your time");
                }

            }

        }//end click_Button



        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";
            i = 1;
            Raster = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            label1.Text = "Runde " + i;
            label2.Text = " Spieler: 1";
            spieler = false;
            spiel_ende = false;
            isBotActive = false;
        }

        private bool checkForWinner()
        {
            bool there_is_a_winner = false;

            //checking horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Text != ""))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Text != ""))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Text != ""))
                there_is_a_winner = true;

            //Checking vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Text != ""))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (A2.Text == C2.Text) && (A2.Text != ""))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (A3.Text == C3.Text) && (A3.Text != ""))
                there_is_a_winner = true;
            //checking diagonal
            else if ((A1.Text == B2.Text) && (A1.Text == C3.Text) && (A1.Text != ""))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (C1.Text == A3.Text) && (A3.Text != ""))
                there_is_a_winner = true;

            if (there_is_a_winner == true)
            {
                string winner = "";
                if (spieler)
                    winner = "1";
                else
                    winner = "2";

                MessageBox.Show("The Winner is player" + winner, "Good Job");
            }//end if

            return there_is_a_winner;
        }//end there_is_a_winner

        private void FarbeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BlauToolStripMenuItem_Click(object sender, EventArgs e)
        {

            A1.BackColor = Color.LightBlue;

            A2.BackColor = Color.LightBlue;
            A3.BackColor = Color.LightBlue;
            B1.BackColor = Color.LightBlue;
            B2.BackColor = Color.LightBlue;
            B3.BackColor = Color.LightBlue;
            C1.BackColor = Color.LightBlue;
            C2.BackColor = Color.LightBlue;
            C3.BackColor = Color.LightBlue;
        }

        private void StandartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
        }

        private void RotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A1.BackColor = Color.Red;
            A2.BackColor = Color.Red;
            A3.BackColor = Color.Red;
            B1.BackColor = Color.Red;
            B2.BackColor = Color.Red;
            B3.BackColor = Color.Red;
            C1.BackColor = Color.Red;
            C2.BackColor = Color.Red;
            C3.BackColor = Color.Red;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void newBotGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


        }

        private void depthSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBotGame(new DepthSearch(new TTTGoalCheck()));
        }
        private void breathSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBotGame(new BreathSearch(new TTTGoalCheck()));
        }

        private void createBotGame(ISearchStrategy Strategy)
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";
            i = 1;
            Raster = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            spieler = false;
            label1.Text = "Runde " + i;
            label2.Text = " Spieler: 1";
            spiel_ende = false;
            Bot = new Bot() { SearchStrategy = Strategy };
            isBotActive = true;
        }

        private void greedySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBotGame(new GreedySearch(new TTTGoalCheck()));
        }
    }
}