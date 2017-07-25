using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Task2.Logic;
using Timer;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            //Timer.Timer timer = new Timer.Timer();

            //MobilePhone mobilePhone = new MobilePhone(timer);
            //Pager pager = new Pager();

            //pager.Register(timer);
            //Console.WriteLine(Int32.MaxValue);
            //timer.SimulateNewTimer(0, 0, 60, "Hi");

            int[] ints = {1, 2, 4, 5, 6, 8, 23, 48, 98, 333};
            Console.WriteLine(ArrayExtension.BinarySearch(ints, 2, (x, y) => x - y));
            

        }


    }
}
