﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UnbeatableTicTacToeLibrary
{
    public class AIclass
    {

        static int player_sum_row1;
        static int player_sum_row2;
        static int player_sum_row3;

        static int cpu_sum_row1;
        static int cpu_sum_row2;
        static int cpu_sum_row3;

        static int player_sum_col1;
        static int player_sum_col2;
        static int player_sum_col3;

        static int cpu_sum_col1;
        static int cpu_sum_col2;
        static int cpu_sum_col3;

        private static bool first_move = true;
        
        private static string o_player = "O";
        private static string x_cpu = "X";

        public static void cpu_move(string player_or_cpu, string[,] board)
        {
            cpu_sum_row1 = cpu_sum_row2 = cpu_sum_row3 = 0; //clear for start of a new count

            player_sum_row1 = player_sum_row2 = player_sum_row3 = 0;

            player_sum_col1 = player_sum_col2 = player_sum_col3 = 0;

            cpu_sum_col1 = cpu_sum_col2 = cpu_sum_col3 = 0;

            List<int> player_sum_list_row = new List<int>();
            List<int> cpu_sum_list_row = new List<int>();

            List<int> player_sum_list_col = new List<int>();
            List<int> cpu_sum_list_col = new List<int>();

            player_sum_list_row.Add(player_sum_row1);
            player_sum_list_row.Add(player_sum_row2);
            player_sum_list_row.Add(player_sum_row3);

            cpu_sum_list_row.Add(player_sum_row1);
            cpu_sum_list_row.Add(player_sum_row2);
            cpu_sum_list_row.Add(player_sum_row3);


            player_sum_list_col.Add(player_sum_col1);
            player_sum_list_col.Add(player_sum_col2);
            player_sum_list_col.Add(player_sum_col3);

            cpu_sum_list_col.Add(player_sum_col1);
            cpu_sum_list_col.Add(player_sum_col2);
            cpu_sum_list_col.Add(player_sum_col3);

            int buffer_val_player;
            int buffer_val_cpu;



            //CPU move

            //iterates by row for the count
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Console.Write(board[i, j]);
                    if (board[i, j].Equals(x_cpu))
                    {
                        buffer_val_cpu = cpu_sum_list_row[i];
                        buffer_val_cpu++; //increment count
                        cpu_sum_list_row[i] = buffer_val_cpu;
                    }
                    else if (board[i, j].Equals(o_player))
                    {
                        buffer_val_player = player_sum_list_row[i];
                        buffer_val_player++;
                        player_sum_list_row[i] = buffer_val_player;
                    }
                }
            }

            //iterates by column for the count

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Console.Write(board[i, j]);
                    if (board[j, i].Equals(x_cpu))
                    {
                        buffer_val_cpu = cpu_sum_list_col[i];
                        buffer_val_cpu++; //increment count
                        cpu_sum_list_col[i] = buffer_val_cpu;
                    }
                    else if (board[j, i].Equals(o_player))
                    {
                        buffer_val_player = player_sum_list_col[i];
                        buffer_val_player++;
                        player_sum_list_col[i] = buffer_val_player;
                    }
                }
            }

            //get the col that has the max 

            bool run_once_flag = true;

            int amount = 2; //number of moves

            //   cpu_move(player_or_cpu, board);

            //diag block


            //SECOND MOVE, always check first for winning condition
            ///////////////////WINNING MOVE TAKES PRECEDENCE OVER BLOCKING
            for (int index = 0; index < 3; index++)
            {
                if (cpu_sum_list_col[index] == amount)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[j, index] == "*" && run_once_flag)
                        {
                            Class1.set_move(j, index, x_cpu);

                            run_once_flag = false;
                        }
                    }
                }
            }

            for (int index = 0; index < 3; index++)
            {
                if (cpu_sum_list_row[index] == amount)//0!!!!!
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[index, j] == "*" && run_once_flag)
                        {
                            Class1.set_move(index, j, x_cpu);

                            run_once_flag = false;
                        }
                    }
                }
            }




            if (board[0, 0] == o_player && board[1, 1] == o_player && board[2, 2] == "*" && run_once_flag)
            {
                Class1.set_move(2, 2, x_cpu);
                run_once_flag = false;
            }
            else if (board[2, 0] == o_player && board[1, 1] == o_player && board[0, 2] == "*" && run_once_flag)
            {
                Class1.set_move(0, 2, x_cpu);
                run_once_flag = false;
            }
            else if (board[0, 2] == o_player && board[1, 1] == o_player && board[2, 0] == "*" && run_once_flag)
            {
                Class1.set_move(2, 0, x_cpu);
                run_once_flag = false;
            }
            else if (board[2, 2] == o_player && board[1, 1] == o_player && board[0, 0] == "*" && run_once_flag)
            {
                Class1.set_move(0, 0, x_cpu);
                run_once_flag = false;
            }
            else if (board[2, 2] == o_player && board[0, 0] == o_player && board[1, 1] == "*" && run_once_flag)
            {
                Class1.set_move(1, 1, x_cpu);
                run_once_flag = false;
            }else if (board[2, 0] == o_player && board[0, 2] == o_player && board[1, 1] == "*" && run_once_flag)
            {
                Class1.set_move(1, 1, x_cpu);
                run_once_flag = false;
            }


            //////////////
            for (int index = 0; index < 3; index++)
            {
                if (player_sum_list_col[index] == amount)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[j, index] == "*" && run_once_flag)
                        {
                            Class1.set_move(j, index, x_cpu);

                            run_once_flag = false;
                        }
                    }
                }
            }

            for (int index = 0; index < 3; index++)
            {
                if (player_sum_list_row[index] == amount)//0!!!!!
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[index, j] == "*" && run_once_flag)
                        {
                            Class1.set_move(index, j, x_cpu);

                            run_once_flag = false;
                        }
                    }
                }
            }

            amount--;//decrements the check, so now it will check for one move CRITICAL

            //FIRST MOVE, reversed from the above loops so the row gets checkd first

            if (first_move)
            {
                if (board[1, 1] == o_player)
                {
                    board[0, 0] = x_cpu;
                    first_move = false;
                    run_once_flag = false;

                }
                else if (board[1,1]!=o_player)
                {
                    board[1, 1] = x_cpu;
                    first_move = false;
                    run_once_flag = false;


                }
            }

            if (first_move == false) { 
            for (int index = 0; index < 3; index++)
            {
                if (player_sum_list_row[index] == amount && cpu_sum_list_row[index] != amount)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[index, j] == "*" && run_once_flag)
                        {
                            Class1.set_move(index, j, x_cpu);

                            run_once_flag = false;
                        }
                    }
                }
                
            }

                for (int index = 0; index < 3; index++)
                {
                    if (player_sum_list_col[index] == amount && cpu_sum_list_col[index] != amount)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[j, index] == "*" && run_once_flag)
                            {
                                Class1.set_move(j, index, x_cpu);

                                run_once_flag = false;

                            }
                        }
                    }

                }
            }


            /*
            Console.WriteLine("CPU SUM LIST COL 0: " + cpu_sum_list_col[0]);
            Console.WriteLine("CPU SUM LIST COL 1: " + cpu_sum_list_col[1]);
            Console.WriteLine("CPU SUM LIST COL 2: " + cpu_sum_list_col[2]);

            Console.WriteLine("PLAYER SUM LIST COL 0: " + player_sum_list_col[0]);
            Console.WriteLine("PLAYER SUM LIST COL 1: " + player_sum_list_col[1]);
            Console.WriteLine("PLAYER SUM LIST COL 2: " + player_sum_list_col[2]);

            Console.WriteLine("CPU SUM LIST ROW 0: " + cpu_sum_list_row[0]);
            Console.WriteLine("CPU SUM LIST ROW 1: " + cpu_sum_list_row[1]);
            Console.WriteLine("CPU SUM LIST ROW 2: " + cpu_sum_list_row[2]);

            Console.WriteLine("PLAYER SUM LIST ROW 0: " + player_sum_list_row[0]);
            Console.WriteLine("PLAYER SUM LIST ROW 1: " + player_sum_list_row[1]);
            Console.WriteLine("PLAYER SUM LIST ROW 2: " + player_sum_list_row[2]);

            Console.WriteLine("Min player col INDEX: " + player_sum_list_col.IndexOf(player_sum_list_col.Min()));
            Console.WriteLine("Min player row INDEX: " + player_sum_list_row.IndexOf(player_sum_list_row.Min()));

            Console.WriteLine("Max player col INDEX: " + player_sum_list_col.IndexOf(player_sum_list_col.Max()));
            Console.WriteLine("Max player row INDEX: " + player_sum_list_row.IndexOf(player_sum_list_row.Max()));
            */
            if (Class1.check_board(player_or_cpu))//if the check_board function returns as true the game will come to an end
            {
                Console.ReadLine();
                //System.Environment.Exit(1);
            }
        }
    }
}