using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnbeatableTicTacToeLibrary
{
    public class Class1
    {

        private static string o_player = "O";
        private string x_cpu = "X";
        private string player_or_cpu = "O";//start as the player

        public static int x_coord = 0;
        public static int y_coord = 0;
        public static string[,] board = { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } };

        public static void print_board()
        {
            int index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "*")
                    {
                        Console.Write(index + " ");
                        index++;
                    }
                    else
                    {
                        index++;
                        Console.Write(board[i, j] + " ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();

            }
        }

        public void user_input()
        {
            Console.WriteLine("Enter the X coordinate, coord starting at top left corner(0-2)");
            x_coord = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Y coordinate (0-2)");
            y_coord = Convert.ToInt32(Console.ReadLine());
        }

        public void main_loop()
        {
            //player_or_cpu = "O"; //start as the player

            // print_board();

            while (!check_board(player_or_cpu))
            {


                if (tie_check())
                {
                    Console.WriteLine("Tie!");
                    print_board();
                    Console.ReadLine();
                    //System.Environment.Exit(1);
                }


                //runs while this method returns false as no one has won
                if (player_or_cpu.Equals(o_player))
                {
                    user_input();

                    if (board[y_coord, x_coord] == x_cpu || board[y_coord, x_coord] == o_player || y_coord > 2 || y_coord < 0 || x_coord > 2 || x_coord < 0)//checks to see if that spot is already played or coord out of bounds, if so then ask user again
                    {
                        Console.WriteLine("Spot already played, choose again");
                        user_input();
                    }

                    set_move(y_coord, x_coord, player_or_cpu);
                }


                // player_or_cpu = "O";//sets the string to O as it represents the player, X is CPU
                if (player_or_cpu == x_cpu)
                {
                    AIclass.cpu_move(player_or_cpu, board);
                    print_board();
                }
                //print_board();

                //change turns

                if (player_or_cpu.Equals(o_player))
                {
                    player_or_cpu = x_cpu;
                }
                else
                {
                    player_or_cpu = o_player;
                }
            }

            Console.ReadLine();//keeps the window open after a win

        }

        public bool tie_check()//if tie check still see unplayed move then it returns false
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "*")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool check_board(string player_or_cpu)
        {//column check
            if (board[0, 0] == player_or_cpu && board[1, 0] == player_or_cpu && board[2, 0] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }
            else if (board[0, 1] == player_or_cpu && board[1, 1] == player_or_cpu && board[2, 1] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }
            else if (board[0, 2] == player_or_cpu && board[1, 2] == player_or_cpu && board[2, 2] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }// row check
            else if (board[0, 0] == player_or_cpu && board[0, 1] == player_or_cpu && board[0, 2] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }
            else if (board[1, 0] == player_or_cpu && board[1, 1] == player_or_cpu && board[1, 2] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }
            else if (board[2, 0] == player_or_cpu && board[2, 1] == player_or_cpu && board[2, 2] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }//diagonal
            else if (board[0, 0] == player_or_cpu && board[1, 1] == player_or_cpu && board[2, 2] == player_or_cpu)
            {
                Console.WriteLine(player_or_cpu + " wins");
                print_board();
                return true;
            }
            else if (board[2, 0] == player_or_cpu && board[1, 1] == player_or_cpu && board[0, 2] == player_or_cpu)
            {
                print_board();
                Console.WriteLine(player_or_cpu + " wins");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void set_move(int x, int y, string player)//static as Class.set_move(y,x,"X"); is used in AIclass for cpus move
        {//this if statement doesnt do much
            //if (board[x, y] != "X" || board[x, y] != "Y")

            board[x, y] = player;
        }
    }
}



