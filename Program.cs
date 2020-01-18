using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the desired ammount of random numbers to sort.");
            int ammount = int.Parse(Console.ReadLine());

            Console.WriteLine("please enter the desired range for the random numbers, from.");
            int rangefrom = int.Parse(Console.ReadLine());

            Console.WriteLine("please enter the desired range for the random numbers, to.");
            int rangeto = int.Parse(Console.ReadLine());

            Console.WriteLine("------------------------------------------------------------");

            int[] num = new int[ammount];
            int x = 0;
            Random random = new Random();
            while (x < ammount)
            {
                num[x] = random.Next(rangefrom, rangeto);
                Console.Write(num[x] + " ");
                x++;
            }

            Console.WriteLine("\n\npick your poison");
            Console.WriteLine("1. Insertion sort");
            Console.WriteLine("2. Bubble sort");
            Console.WriteLine("3. Merge sort");
            Console.WriteLine("4. quicksort\n");

            Stopwatch sw = new Stopwatch();
            int temp;
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    //insertion sort
                    Console.WriteLine("\nSorting...\n");

                    sw.Start();

                    int a = 1;
                    int b = a;

                    while (a < num.Length)
                    {
                        b = a;
                        while (b > 0 && num[b - 1] > num[b])
                        {
                            temp = num[b];
                            num[b] = num[b - 1];
                            num[b - 1] = temp;
                            b--;
                        }
                        a++;
                    }

                    sw.Stop();

                    for (int y = 0; y < num.Length; y++)
                    {
                        Console.Write(num[y] + " ");
                    }

                    Console.WriteLine("\ninsertion sort tog={0} tidenheter", sw.Elapsed);
                    Console.WriteLine("\nklicka enter för att starta om");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    break;

                case 2:
                    //bubble sort
                    Console.WriteLine("\nSorting...\n");

                    sw.Start();

                    for (int i = 0; i <= num.Length; i++)
                    {
                        for (int j = 0; j < num.Length - 1; j++)
                        {
                            if (num[j] > num[j + 1])
                            {
                                temp = num[j + 1];
                                num[j + 1] = num[j];
                                num[j] = temp;
                            }
                        }
                    }

                    sw.Stop();

                    for (int y = 0; y < num.Length; y++)
                    {
                        Console.Write(num[y] + " ");
                    }

                    Console.WriteLine("\nbubble sort tog={0} tidenheter", sw.Elapsed);
                    Console.WriteLine("\nklicka enter för att starta om");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    break;

                case 3:
                    //merge sort
                    Console.WriteLine("\nSorting...\n");

                    sw.Start();

                    TestMergeSort();
                        
                    sw.Stop();

                    for (int y = 0; y < num.Length; y++)
                    {
                        Console.Write(num[y] + " ");
                    }

                    Console.WriteLine("\nmerge sort tog={0} tidenheter", sw.Elapsed);
                    Console.WriteLine("\nklicka enter för att starta om");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    break;

                case 4:
                    //quicksort
                    Console.WriteLine("\nSorting...\n");

                    sw.Start();

                    
                        
                    sw.Stop();

                    for (int y = 0; y < num.Length; y++)
                    {
                        Console.Write(num[y] + " ");
                    }

                    Console.WriteLine("\nquicksort tog={0} tidenheter", sw.Elapsed);
                    Console.WriteLine("\nklicka enter för att starta om");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    break;


                default:
                    Console.Write("invalid");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                    break;
            }
        }

        private static void TestMergeSort(ref int[] num)
        {
            num.DoMergeSort();
        }
    }
}
