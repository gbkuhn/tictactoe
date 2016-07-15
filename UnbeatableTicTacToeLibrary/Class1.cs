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
        
        private string o_player = "O";
        private string x_cpu = "X";
        private string player_or_cpu="O";//start as the player

        public static int x_coord=0;
        public static int y_coord=0;
        public static string[,] board = { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } };

        public int amount { get; set; }
        
        public static void print_board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void main_loop()
        {
            //player_or_cpu = "O"; //start as the player

            print_board();

                while(!check_board(player_or_cpu))
                {
                    //runs while this method returns false as no one has won
                    if (player_or_cpu.Equals("O"))
                    {
                        Console.WriteLine("Enter the X coordinate, coord starting at top left corner(0-2)");
                        x_coord = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the Y coordinate (0-2)");
                        y_coord = Convert.ToInt32(Console.ReadLine());

                        set_move(y_coord, x_coord, player_or_cpu);
                    }

   
                    // player_or_cpu = "O";//sets the string to O as it represents the player, X is CPU
                    if (player_or_cpu == "X")
                    {
                        AIclass.cpu_move(player_or_cpu, board);
                        print_board();
                    }
                    //print_board();

                    //change turns
                    
                    if (player_or_cpu.Equals("O"))
                    {
                        print_board();
                        player_or_cpu = x_cpu;
                    }
                    else
                    {
                        player_or_cpu = o_player;
                    }
                }
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

        public static void set_move(int x,int y,string player)//static as Class.set_move(y,x,"X"); is used in AIclass for cpus move
        {//this if statement doesnt do much
           //if (board[x, y] != "X" || board[x, y] != "Y")
            
                    board[x, y] = player;
                }
            }
        }

    


