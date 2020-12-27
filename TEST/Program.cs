using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {

           




        }
        #region exercise9
        static void FormatData(string dateInput)
        {
            try
            {
              
                var parsedDate = DateTime.Parse(dateInput).ToString("dd MMM, h:mm t"); //t теоретически должно отображать AM/PM но этого не делает, видимо связяно с региональными настройками Visual Studio
                var isTimeAmOrPm = DateTime.Parse(dateInput).ToString("HH t");
                int time = Convert.ToInt32(isTimeAmOrPm); //костыль для определения время суток
                if (time >= 12)
                    parsedDate += "PM";
                else
                    parsedDate += "AM";
                Console.WriteLine(parsedDate);
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect datatime! \n\nInput the correct datatime");
                Console.ReadLine();
            }
          
        }
        #endregion
        #region exercise6
        static void ReversedArray()
        {
            int[,] array = new int[3, 3];
            List<int> list = new List<int>();
            Random random = new Random();
            Console.WriteLine("Изначальный массиив:");
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    array[y, x] = random.Next(10); // заполянем массив случайными числами
                    Console.Write(array[y, x] + "\t");
                    list.Add(array[y, x]); //добавляем числа в список
                }
                Console.WriteLine();
            }
            list.Sort(); //сортируем список, использовал готовый метод, хотя и знаю как сортировать пузырьком
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    array[y, x] = list.First();  //заменяем массив отсотрироваными числами из списка
                    if (list.Count >= 1)
                    {
                        list.RemoveAt(0);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Отсортированый массив:");
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    Console.Write(array[y, x] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        #endregion
        #region exercise5
        static void StringDisplay(int limit = 30)
        {
            string line = string.Empty;
            for (int i = 0; i <= limit; i++)
            {
                string number = i.ToString();
                line += "(" + number + ")";
            }
            Console.WriteLine(line);
            Console.ReadKey();
        }
        #endregion
        #region exercise4
        public static void ShowAllCombinations<T>(IList<T> arr, string current = "")
        {
            if (arr.Count == 0) //если все элементы использованы, выводим на консоль получившуюся строку и возвращаемся
            {
                Console.WriteLine(current);
                return;
            }
            for (int i = 0; i < arr.Count; i++) //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, и вызываем эту же функцию рекурсивно с новыми параметрами.
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                ShowAllCombinations(lst, current + arr[i].ToString());
            }
        }
        #endregion
        #region exercise3
        static void IsNumberPrime(int number)
        {
            int count = 0;
            int[] dividers = new int[number];
            for (int i = 1; i <= number; i++)
            {
                int result = number / i;
                if (number == result * i)
                {
                    count++;
                    dividers[i - 1] = i;
                }
            }
            if (count > 2)
            {
                Console.WriteLine($"Число {number} является составным. Его делители:");

                foreach (var item in dividers)
                {
                    if (item != 0)
                    {
                        Console.Write(item + ",");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Число {number} является простым");
            }
            Console.ReadKey();

        }
        #endregion
        #region exercise2
        static void DisplayArray(int limit = 10)
        {
            int[] array = new int[limit];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10, 20);
            }
            double arrayAvg = array.Average();
            Console.WriteLine(arrayAvg);
            Console.ReadKey();
        }
        #endregion
        #region exercise1
        static void FizzBuzz(int limit = 101)
        {
            for (int i = 1; i <= limit; i++)
            {
                if (i % 5 == 0)
                {
                    Console.Write("Hello");
                }
                else if (i % 3 == 0)
                {
                    Console.Write("World");
                }
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("Hello World");
                }
                else
                {
                    Console.Write(i);
                }
            }
            Console.ReadKey();
        }
        #endregion
    }

}

