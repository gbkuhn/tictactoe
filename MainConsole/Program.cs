using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnbeatableTicTacToeLibrary;

namespace MainConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Class1 board_obj = new Class1();
           
            //board_obj.print_board();

            board_obj.main_loop();

        }
    }
}
