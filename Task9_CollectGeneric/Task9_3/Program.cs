using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте класс MyDictionary<TKey,TValue>. Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса Dictionary. Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод добавления пар элементов, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества пар элементов.

namespace Task9_3
{
    public class Item<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public TKey Key { get => key; set => key = value; }
        public TValue Value { get => value; set => this.value = value; }

        public Item() { }

        public Item(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class MyDictionary<TKey, TValue>
    {
        private List<Item<TKey, TValue>> dataList;

        public MyDictionary()
        {
            dataList = new List<Item<TKey, TValue>>();
        }

        private int count;
        public int Count { get => count; }

        public void Add(TKey key, TValue value)
        {
            Item<TKey, TValue> newItem = new Item<TKey, TValue>(key, value);

            if (count > 0)
            {
                foreach (var keyItem in dataList)
                {
                    if (keyItem.Key.ToString() == key.ToString())
                    {
                        //throw new ArgumentException("Уже существует элемент с ключом: ", nameof(keyItem)/*key.ToString()*/);
                        Console.WriteLine($"Элемент с ключом {key} уже существует"); return;
                    }
                }
            }

            dataList.Add(newItem);
            count++;
        }

        public Item<TKey, TValue> GetItemByIndex(int index)
        {
            if (index < 1 || index > Count)
            {
                //throw new ArgumentOutOfRangeException("Неверный индекс", index.ToString());
                Console.WriteLine("Неверный индекс");
                return new Item<TKey, TValue>();
            }
            int i = 0;
            foreach (var item in dataList)
            {
                if (index == ++i)
                {
                    return item;
                }
            }
            return new Item<TKey, TValue>();
        }

        public static void PrintDictionary(MyDictionary<TKey, TValue> dictionary, string title)
        {
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(title);
            Console.WriteLine($"Dictionary contains {dictionary.Count} elements");
            Console.WriteLine(new string('-', 35));
            foreach (var item in dictionary.dataList)
            {
                Console.WriteLine($"key: {item.Key,5} | value: {item.Value}");
            }
            Console.WriteLine(new string('-', 35));
        }

        public static void PrintItem (Item<TKey, TValue> item)
        {
            Console.WriteLine($"key: {item.Key,5} | value: {item.Value}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> dictionary = new MyDictionary<int, string>();
            dictionary.Add(1, "Rome");
            dictionary.Add(2, "Kyiv");
            dictionary.Add(3, "Dnipro");
            MyDictionary<int, string>.PrintDictionary(dictionary, "first dictionary");
            dictionary.Add(-1, "Dnipro");
           // dictionary.Add(2, "Kharkiv");

            MyDictionary<int, string>.PrintDictionary(dictionary, "modified dictionary");
            MyDictionary<int, string>.PrintItem(dictionary.GetItemByIndex(7));
            Console.ReadKey();
        }
    }
}
