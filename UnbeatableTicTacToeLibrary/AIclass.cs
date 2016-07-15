using System;
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

       public static void cpu_move(string player_or_cpu, string[,] board)
       {
           cpu_sum_row1 = 0; //clear for start of a new count
           cpu_sum_row2 = 0;
           cpu_sum_row3 = 0;

           player_sum_row1 = 0;
           player_sum_row2 = 0;
           player_sum_row3 = 0;

           player_sum_col1 = 0;
           player_sum_col2 = 0;
           player_sum_col3 = 0;

           cpu_sum_col1 = 0;
           cpu_sum_col2 = 0;
           cpu_sum_col3 = 0;


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
                   if (board[i, j].Equals("X"))
                   {
                       buffer_val_cpu = cpu_sum_list_row[i];
                       buffer_val_cpu++; //increment count
                       cpu_sum_list_row[i] = buffer_val_cpu;
                   }
                   else if (board[i, j].Equals("O"))
                   {
                       buffer_val_player = player_sum_list_row[i];
                       buffer_val_player++;
                       player_sum_list_row[i] = buffer_val_player;
                   }
               }
           }
           
            Console.WriteLine("CPU SUM LIST ROW 0: " + cpu_sum_list_row[0]);
            Console.WriteLine("CPU SUM LIST ROW 1: " + cpu_sum_list_row[1]);
            Console.WriteLine("CPU SUM LIST ROW 2: " + cpu_sum_list_row[2]);

            Console.WriteLine("PLAYER SUM LIST ROW 0: " + player_sum_list_row[0]);
            Console.WriteLine("PLAYER SUM LIST ROW 1: " + player_sum_list_row[1]);
            Console.WriteLine("PLAYER SUM LIST ROW 2: " + player_sum_list_row[2]);
            
           //iterates by column for the count

           for (int i = 0; i < 3; i++)
           {
               for (int j = 0; j < 3; j++)
               {
                   // Console.Write(board[i, j]);
                   if (board[j, i].Equals("X"))
                   {
                       buffer_val_cpu = cpu_sum_list_col[i];
                       buffer_val_cpu++; //increment count
                       cpu_sum_list_col[i] = buffer_val_cpu;
                   }
                   else if (board[j, i].Equals("O"))
                   {
                       buffer_val_player = player_sum_list_col[i];
                       buffer_val_player++;
                       player_sum_list_col[i] = buffer_val_player;
                   }
               }

           }
           
            Console.WriteLine("CPU SUM LIST COL 0: " + cpu_sum_list_col[0]);
            Console.WriteLine("CPU SUM LIST COL 1: " + cpu_sum_list_col[1]);
            Console.WriteLine("CPU SUM LIST COL 2: " + cpu_sum_list_col[2]);

            Console.WriteLine("PLAYER SUM LIST COL 0: " + player_sum_list_col[0]);
            Console.WriteLine("PLAYER SUM LIST COL 1: " + player_sum_list_col[1]);
            Console.WriteLine("PLAYER SUM LIST COL 2: " + player_sum_list_col[2]);

            Console.WriteLine("Min player col INDEX: " + player_sum_list_col.IndexOf(player_sum_list_col.Min()));
            Console.WriteLine("Min player row INDEX: " + player_sum_list_row.IndexOf(player_sum_list_row.Min()));

            Console.WriteLine("Max player col INDEX: " + player_sum_list_col.IndexOf(player_sum_list_col.Max()));
            Console.WriteLine("Max player row INDEX: " + player_sum_list_row.IndexOf(player_sum_list_row.Max()));
            

           //get the col that has the max 
           int move_x = player_sum_list_col.IndexOf(player_sum_list_col.Max());
           int move_y = player_sum_list_row.IndexOf(player_sum_list_row.Max());
           bool run_once_flag = true;

        //   cpu_move(player_or_cpu, board);

           //SECOND MOVE
           if (player_sum_list_col[0] == 2)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 0] == "*" && run_once_flag)
                   {
                       Class1.set_move(j, 0, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_col[1] == 2)
           {
               run_once_flag = true;
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 1] == "*" && run_once_flag)
                   {
                       Class1.set_move(j, 1, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_col[2] == 2)
           {
               run_once_flag = true;
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 2] == "*" && run_once_flag)
                   {
                       Class1.set_move(j, 2, "X");

                       run_once_flag = false;
                   }
               }

           }
           else if (player_sum_list_row[0] == 2)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[0, j] == "*" && run_once_flag)
                   {
                       Class1.set_move(0, j, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_row[1] == 2)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[1, j] == "*" && run_once_flag)
                   {
                       Class1.set_move(1, j, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_row[2] == 2)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[2, j] == "*" && run_once_flag)
                   {
                       Class1.set_move(2, j, "X");

                       run_once_flag = false;
                   }
               }
           }
            
           //FIRST MOVE
           
           if (player_sum_list_col[0] == 1)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 0] == "*"  && run_once_flag)
                   {
                       Class1.set_move(j,0,"X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_col[1] == 1)
           {
               run_once_flag = true;
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 1] == "*" && run_once_flag)
                   {
                       Class1.set_move(j, 1, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_col[2] == 1)
           {
               run_once_flag = true;
               for (int j = 0; j < 3; j++)
               {
                   if (board[j, 2] == "*"  && run_once_flag)
                   {
                       Class1.set_move(j, 2, "X");

                       run_once_flag = false;
                   }
               }

           }
           else if (player_sum_list_row[0] == 1)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[0, j] == "*" && run_once_flag)
                   {
                       Class1.set_move(0, j, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_row[1] == 1)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[1, j] == "*" && run_once_flag)
                   {
                       Class1.set_move(1, j, "X");

                       run_once_flag = false;
                   }
               }
           }
           else if (player_sum_list_row[2] == 1)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (board[2, j] == "*"  && run_once_flag)
                   {
                       Class1.set_move(2, j, "X");

                       run_once_flag = false;
                   }
               }
           }
           //SECOND MOVE
          
 
            /*
            if (move_x != 2 && move_y != 2 && board[move_y + 1, move_x + 1] == "*" && board[move_y + 1, move_x + 1] != "O" && board[move_y + 1, move_x + 1] != "X")
            {
                if (board[move_y + 1, move_x] == "*")
                {
                    Class1.set_move(move_y + 1, move_x, "X");

                }
                else
                {
                    Class1.set_move(move_y + 1, move_x + 1, "X");
                }
            }
            else if (move_y != 0 && move_x != 2 && board[move_y - 1, move_x + 1] == "*" && board[move_y - 1, move_x + 1] != "O" && board[move_y - 1, move_x + 1] != "X")
            {
                if (board[move_y - 1, move_x] == "*")
                {
                    Class1.set_move(move_y + 1, move_x, "X");
                }
                else
                {
                    Class1.set_move(move_y - 1, move_x + 1, "X");
                }
            }
            else if (move_x != 0 && move_y != 2 && board[move_y + 1, move_x - 1] == "*" && board[move_y + 1, move_x - 1] != "O" && board[move_y + 1, move_x - 1] != "X")
            {
                if (board[move_y - 1, move_x] == "*")
                {
                    Class1.set_move(move_y + 1, move_x, "X");
                }
                else
                {
                    Class1.set_move(move_y + 1, move_x - 1, "X");
                }
            }
            else if (move_x != 0 && move_y != 0 && board[move_y - 1, move_x - 1] == "*" && board[move_y - 1, move_x - 1] != "O" && board[move_y - 1, move_x - 1] != "X")
            {
                if (board[move_y - 1, move_x] == "*")
                {
                    Class1.set_move(move_y + 1, move_x, "X");
                }
                else
                {
                    Class1.set_move(move_y - 1, move_x - 1, "X");
                }
            }
             
            */

            if (Class1.check_board(player_or_cpu))//if the check_board function returns as true the game will come to an end
            {
                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }
    }
}
