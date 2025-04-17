// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;

namespace ConsoleApp
{
  class Program
  {
        static void Main(string[] args)
        {
            string input = "11112222333344445555";
            // 111122 223333  (2) ***
            // 1111 2222 3333  (3)
            // 111 122 223 333  (4)
            // 1111 22 22 33 33  (5)
            // 11 11 22 22 33 33  (6)

            int chunkSize = 7;

            List<string> chunks = SplitStringIntoChunks(input, chunkSize);

            foreach (var chunk in chunks)
            {
                Console.WriteLine(chunk);
            }
        }

        static List<string> SplitStringIntoChunks(string str, int chunkSize)
        {
            if (chunkSize <= 1)
            {
                throw new ArgumentException("Chunk size must be greater than one.");
            } 

            int stringLenght = str.Length;
            double division = stringLenght / chunkSize;

            if (division < 2)
            {
                throw new ArgumentException("string length must be greater");
            }

            double remainder = stringLenght % chunkSize;
            double chunkIndex = remainder == 0 ? division : (int)Math.Round(division);
            Console.WriteLine($"String Length: {stringLenght} Remainder: {remainder} chunkIndex: {chunkIndex}");

            List<string> chunks = new List<string>();

            str.Substring(0, (int)remainder);

            for (int i = 0; i < chunkSize; i++)
            {
                if (remainder == 0)
                {
                    chunks.Add(str.Substring((i * (int)chunkIndex), (int)chunkIndex));
                }
                else
                {
                    int temporalIndex = i == 0 ? 0 : i * (int)chunkIndex;
                    int temporalLength = i == 0 ? ((int)chunkIndex) + (int)remainder : (int)chunkIndex;
                    chunks.Add(str.Substring(temporalIndex, temporalLength));
                }
            }

            return chunks;
        }


        public static List<int> GradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                double division = grades[i] / 5;
                double difference = ((division + 1) * 5) - grades[i];
                if (difference < 3 && grades[i] >= 38)
                {
                    grades[i] = grades[i] + (int)difference;
                }
            }

            return grades;
        }

        public static void QueueFunction()
        {
            List<string> inputs = new List<string>();
            inputs.Add("01:sent");
            inputs.Add("02:sent");
            inputs.Add("01:read");
            inputs.Add("02:delivered");
            inputs.Add("01:delivered");

            var messages = inputs.GroupBy(x => x.Split(":")[0]).ToDictionary(x => x.Key, x => x.ToList());
            List<string> messagesList = new List<string>();
            foreach (var item in messages)
            {
                string info = item.Key;
                foreach (var status in item.Value)
                {
                    string statusInfo = status.Split(':')[1];
                    if (statusInfo == "sent")
                    {
                        info += " was sent";
                    }
                    if (statusInfo == "read")
                    {
                        info += " was read";
                    }
                    if (statusInfo == "delivered")
                    {
                        info += " was delivered";
                    }
                }
                messagesList.Add(info);
            }

            foreach (var message in messagesList)
            {
                Console.WriteLine(message);
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
