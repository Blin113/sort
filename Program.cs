using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

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

                    List<int> unsorted = new List<int>(num);       //Add all num[] elements to unsorted List<int>
                    List<int> sorted;

                    sw.Start();

                    sorted = MergeSort(unsorted);

                    sw.Stop();

                    for (int y = 0; y < sorted.Count; y++)
                    {
                        Console.Write(sorted[y] + " ");
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

                    QuickSort(num, 0, num.Length - 1);      //funkar inte

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

        private static List<int> MergeSort(List<int> unsorted)      //mergesort
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)     //mergesort
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }

        private static void QuickSort(int[] num, int left, int right)       //quicksort
        {
            if (left < right)
            {
                int pivot = Partition(num, left, right);

                if (pivot > 1)
                {
                    QuickSort(num, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(num, right, pivot + 1);
                }
            }
        }

        private static int Partition(int[] num, int left, int right)        //quicksort
        {
            int pivot = num[left];
            while (true)
            {
                while (num[left] < pivot)
                {
                    left++;
                }
                while (num[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = num[left];
                    num[left] = num[right];
                    num[right] = temp;

                    if (num[left] == num[right])
                    {
                        left++;
                    }
                }
                else
                {
                    return right;
                }
            }
        }
    }
}

