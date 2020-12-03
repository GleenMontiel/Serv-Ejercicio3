using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {

        static readonly object l = new object();
        static bool running = true;
        static int n = 0;
        static string winner;

        static void Main(String[] args)
        {

            //Thread increment = new Thread(Increment);
            //Thread decrement = new Thread(Decrement);

            //increment.Start();
            //decrement.Start();

            Thread incrementB = new Thread(() => {
                while (running)
                {
                    lock (l)
                    {
                        if (running)
                        {
                            n++;
                            Console.WriteLine("Increment {0}", n);
                        }
                        if (n == 1000)
                        {
                            winner = "Increment";
                            running = false;
                        }
                    }

                }
            });
            Thread decrementB = new Thread(() => {
                while (running)
                {
                    lock (l)
                    {
                        if (running)
                        {
                            n--;
                            Console.WriteLine("Decrement {0}", n);
                        }
                        if (n == -1000)
                        {
                            winner = "Decrement";
                            running = false;
                        }
                    }
                }
            });

            incrementB.Start();
            decrementB.Start();
            //increment.Join();
            //decrement.Join();
            incrementB.Join();
            decrementB.Join();
            Console.WriteLine("The winner is: {0}", winner);
            Console.ReadLine();
        }


        static void Decrement()
        {
            while (running)
            {
                lock (l)
                {
                    if (running)
                    {
                        n--;
                        Console.WriteLine("Decrement {0}", n);
                    }
                    if (n == -1000)
                    {
                        winner = "Decrement";
                        running = false;
                    }
                }
            }
        }

        static void Increment()
        {
            while (running)
            {
                lock (l)
                {
                    if (running)
                    {
                        n++;
                        Console.WriteLine("Increment {0}", n);
                    }
                    if (n == 1000)
                    {
                        winner = "Increment";
                        running = false;
                    }
                }
               
            }
        }
    }
}