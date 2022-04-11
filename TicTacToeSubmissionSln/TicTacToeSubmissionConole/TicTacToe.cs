using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _boardPositions = new int[9];
        private int _rounds;
        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        private void PlayMove(int Player)
        {
            Console.SetCursorPosition(2, 19);

            if (Player == 1)
                Console.Write("Player X");
            else
                Console.Write("Player O");

            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

            int rowNumber = int.Parse(row);
            int columnNumber = int.Parse(column);
            int arrayPos = (rowNumber * 3) + columnNumber;

            _boardPositions[arrayPos] = Player;

            if (Player == 1)
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.X, true);
            else
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.O, true);
        }

        public bool CheckIfPlayerwins(int player)
        {
            if ((_boardPositions[0] == player) && (_boardPositions[1] == player) && (_boardPositions[2] == player))
                return true;
            if ((_boardPositions[0] == player) && (_boardPositions[4] == player) && (_boardPositions[8] == player))
                return true;
            if ((_boardPositions[0] == player) && (_boardPositions[3] == player) && (_boardPositions[6] == player))
                return true;
            if ((_boardPositions[3] == player) && (_boardPositions[4] == player) && (_boardPositions[5] == player))
                return true;
            if ((_boardPositions[6] == player) && (_boardPositions[7] == player) && (_boardPositions[8] == player))
                return true;
            if ((_boardPositions[1] == player) && (_boardPositions[4] == player) && (_boardPositions[7] == player))
                return true;
            if ((_boardPositions[2] == player) && (_boardPositions[5] == player) && (_boardPositions[8] == player))
                return true;
            if ((_boardPositions[2] == player) && (_boardPositions[4] == player) && (_boardPositions[6] == player))
                return true;

            return false;
        }
        public void Run()
        {
            _rounds = 0;
            bool playerXwins = false;
            bool playerOwins = false;

            while (_rounds < 4)
            {
                PlayMove(1);
                playerXwins = CheckIfPlayerwins(1);

                if (playerXwins)
                {
                    Console.WriteLine(" Player X wins !!!");

                    break;
                }

                PlayMove(2);
                playerOwins = CheckIfPlayerwins(2);

                if (playerOwins)
                {

                    Console.WriteLine("Player O Wins !!!");
                }
                _rounds++;
            }
            if (!playerOwins && !playerXwins)
                Console.WriteLine(" The game is draw!");
            /*
                        // FOR ILLUSTRATION CHANGE TO YOUR OWN LOGIC TO DO TIC TAC TOE

                        Console.SetCursorPosition(2, 19);

                        Console.Write("Player 1");

                        Console.SetCursorPosition(2, 20);

                        Console.Write("Please Enter Row: ");
                        var row = Console.ReadLine();

                        Console.SetCursorPosition(2, 22);


                        Console.Write("Please Enter Column: ");
                        var column = Console.ReadLine();


                        // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
                        _boardRenderer.AddMove(int.Parse(row), int.Parse(column), PlayerEnum.X, true);            
            */
        }

    }
}
