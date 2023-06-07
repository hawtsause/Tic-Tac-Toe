using System.Diagnostics.Metrics;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace TicTacToe
{
    internal class Program
    {

        private static string[] board = new string[9];
        private static bool playAgainBool = true;
        private static int counterForDraw = 0;

        static void Main(string[] args)
        {
            while (playAgainBool)
            {
                Console.Clear();
                Introduction();
                InitializeBoard();

                while (CheckingForWin() == false)
                {
                    PlayingProcess("X");
                    if (CheckingForWin()) break;
                    PlayingProcess("O");
                }

                Console.WriteLine("Do you want to play again? (Y/N)");
                PlayAgain(Console.ReadLine());
                continue;
            }
            Console.WriteLine("\nThank you for playing");
        }

        static void PlayingProcess(string player)
        {
            counterForDraw++;

            //getting selection
            Console.WriteLine("-------------------------------------------------------\n");
            Console.WriteLine($"Player {player}, enter your selection:");
            DrawBoard();

            Console.Write("\nSELECTION: ");
            int selection = Convert.ToInt32(Console.ReadLine());

            if (board[selection - 1] != "X" && board[selection - 1] != "O")
            {
                board[selection - 1] = player;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis section is already taken! Pick another one");
                Console.ForegroundColor = ConsoleColor.White;
                counterForDraw--;
                PlayingProcess(player);
            }
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = (i + 1).ToString();
            }
        }
        static void DrawBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < board.Length; i += 3)
            {
                Console.WriteLine(board[i]+ "|" + board[i + 1] + "|" + board[i + 2]);
            }
            Console.WriteLine();
        }
        static bool CheckingForWin()
        {
            //horizontal comparsion
            for (int i = 0; i < board.Length - 2; i += 3)
            {
                if (board[i].Equals(board[i+1]) && board[i+1].Equals(board[i + 2]))
                {
                    EndGameMsg();
                    return true;
                }
            }
            //vertical comparsion
            for (int i = 0; i < board.Length - 6; i++)
            {
                if (board[i].Equals(board[i + 3]) && board[i + 3].Equals(board[i + 6]))
                {
                    EndGameMsg();
                    return true;
                }
            }
            //diagonals comparsion
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
            {
                EndGameMsg();
                return true;
            }
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
            {
                EndGameMsg();
                return true;
            }
            //checking for a draw game
            if(counterForDraw == 9)
            {
                EndGameMsg("\nNobody wins!\n");
                return true;
            }
            return false;
        }
        static void EndGameMsg(string winMsg = "\nYou won!\n")
        {
            DrawBoard();
            Console.WriteLine(winMsg);
        }
        static void PlayAgain(string answ)
        {
            if (answ == "Y") 
            { 
                playAgainBool = true; 
                counterForDraw = 0; 
            }
            else if (answ == "N") playAgainBool = false;
            else
            {
                Console.WriteLine("Wrong input! Please use Y or N");
                PlayAgain(Console.ReadLine());
            }
        }
        static void Introduction()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
