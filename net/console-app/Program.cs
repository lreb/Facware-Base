// See https://aka.ms/new-console-template for more information

using System;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
        // if(args.Length > 0)
        // {
        //     for(int i = 0; i < args.Length; i++)
        //     {
        //         Console.WriteLine(args[i]);
        //     }
        // }
        // else
        //     Console.WriteLine("No arguments provided.");

        // Console.WriteLine("Name: ");
        // string? name = Convert.ToString(Console.ReadLine());
        // Console.WriteLine($"Hello World {name}!");
    // int num = 5;
    //   int temp = 0;
		// 	int f = 0;
		// 	for(int i = 1; i <= num; i++)
		// 	{
		// 			if(i==1)
		// 			{
		// 				temp = i;	
		// 			}
		// 			else 
		// 			{
		// 				f = temp * i;
		// 				temp = f;
		// 			}
    //       Console.WriteLine($"Factorial of {i} is {f}");
		// 	}
      //Console.WriteLine($"Factorial of {num} is {f}");
      //HammingDistance("abcde", "abcde");

      var arr = new int[] { 5, 2, 3, 1, 4, 6 };
      var sortedArr = bubbleSort(arr);
      foreach (var item in sortedArr)
      {
        Console.WriteLine(item);
      }

    }

    public static int[] bubbleSort(int[] arr)
    {
      int temp;
      for(int i = 0; i < arr.Length -1; i++)
      {
        for(int j = 0; j < arr.Length - i - 1; j++)
        {
          if(arr[j] > arr[j + 1])
          {
            temp = arr[j];
            arr[j] = arr[j+1];
            arr[j+1] = temp;
          }
        }
      }
      return arr;
    }

    public static int HammingDistance(string str1, string str2)
    {
			int difference = 0;
			for(int i = 0; i < str1.Length; i++)
			{
				if(str1[i] != str2[i])
				{
					difference++;
				}
			}
			return difference;
    }
  }
}
