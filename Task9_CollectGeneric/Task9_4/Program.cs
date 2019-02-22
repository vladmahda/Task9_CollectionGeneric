using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9_2;      //добавлена ссылка на 9_2

// Создайте расширяющий метод: public static T[] GetArray<T>(this MyList<T> list). Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2 для данного урока. Выведите на экран значения элементов массива, который вернул расширяющий метод GetArray().

namespace Task9_4
{
    public class MyNewList<T> : MyList<T>
    {
        public static T[] GetArray<T>(MyNewList<T> list)
        {
            T[] resultArray = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                resultArray[i] = list.GetData(i + 1);
            }
            return resultArray;
        }

        public static void PrintArray(T[] array)
        {
            Console.WriteLine($"Массив {typeof(T)} из {array.Length} элементов");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"[{i}] : {array[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyNewList<string> list = new MyNewList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("forth");
            MyNewList<string>.PrintList(list);
            Console.WriteLine(new string('-', 35));
            //string[] result = new string[0];
            //result = MyNewList<string>.GetArray<string>(list);
            //string[] result = MyNewList<string>.GetArray<string>(list);
            //MyNewList<string>.PrintArray(result);
            MyNewList<string>.PrintArray(MyNewList<string>.GetArray<string>(list));

            Console.ReadKey(); 
        }
    }
}
