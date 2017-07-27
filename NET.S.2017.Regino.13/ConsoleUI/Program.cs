using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>(3);

            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Dequeue();
            Console.WriteLine($"{queue.Begin}, {queue.End}");
            queue.Enqueue(1);
            Console.WriteLine(queue.Count);
            Console.WriteLine($"{queue.Begin}, {queue.End}");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine($"{queue.Begin}, {queue.End}");
            queue.Enqueue(1);
            queue.Enqueue(1);
            Console.WriteLine($"{queue.Begin}, {queue.End}");
            queue.Enqueue(1);
            Console.WriteLine($"{queue.Begin}, {queue.End}");

            Console.WriteLine(queue.Count);
        }
    }
}
