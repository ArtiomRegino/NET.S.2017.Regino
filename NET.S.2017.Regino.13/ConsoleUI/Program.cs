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
            CustomQueue.CustomQueue<int> queue = new CustomQueue.CustomQueue<int>(3);

            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Dequeue();
            Console.WriteLine($"{queue.Head}, {queue.Tail}");
            queue.Enqueue(1);
            Console.WriteLine(queue.Count);
            Console.WriteLine($"{queue.Head}, {queue.Tail}");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine($"{queue.Head}, {queue.Tail}");
            queue.Enqueue(1);
            queue.Enqueue(1);
            Console.WriteLine($"{queue.Head}, {queue.Tail}");
            queue.Enqueue(1);
            Console.WriteLine($"{queue.Head}, {queue.Tail}");

            Console.WriteLine(queue.Count);
        }
    }
}
