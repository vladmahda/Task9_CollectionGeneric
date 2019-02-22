using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Создайте класс MyList<T>. Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса List<T>. Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества элементов.

namespace Task9_2
{
    public class Item<T>
    {
        //Данные
        private T data;
        public T Data { get => data; set => data = value; }

        //Ссылка на следующий элемент
        private Item<T> next;
        public Item<T> Next { get => next; set => next = value; }

        //Создание нового элемента
        public Item(T data)
        {
            if (data != null)
            {
                this.data = data;
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }
        }

        //приведение объекта к строке
        public override string ToString()
        {
            return data.ToString();
        }
    }

    public class MyList<T>
    {
        //голова списка
        private Item<T> head = null;
        public Item<T> Head { get => head; set => head = value; }

        //хвост списка
        private Item<T> tail = null;
        public Item<T> Tail { get => tail; set => tail = value; }

        //количество элементов
        private int count = 0;
        //свойство только для чтения для получения общего количества элементов
        public int Count { get => count; }

        //Получение элемента по индексу
        public Item<T> GetElement(int index)
        {
            if (index > Count || index < 1)
            {
                Console.WriteLine($"Введен неверный индекс {index}. Количество элементов в списке {Count}");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            Item<T> item = Head;
            for (int i = 1; i < index; i++)
            {
                item = item.Next;
            }
            return item;
        }

        //добавление данных
        public void Add(T data)
        {
            //проверка, не пустые ли данные пришли?
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            //создаем новый элемент списка
            var item = new Item<T>(data);

            if (count == 0) //если это первый элемент списка
            {
                head = item;
            }
            else
            {
                tail.Next = item;   //устанавливаем указатель с хвоста на новый элемент              
            }
            //делаем элемент хвостом
            tail = item;
            count++;
        }

        //индексатор для получения значения элемента по указанному индексу
        public T GetData(int index)
        {
            if (index > count)
            {
                Console.WriteLine($"Введен неверный индекс {index}. Количество элементов в списке {Count}");
                return default(T);
            }
            var item = head;
            for (int i = 1; i < index; i++)
            {
                item = item.Next;
            }
            return item.Data;
        }

        public static void PrintList(MyList<T> list)
        {
            Console.WriteLine($"Список {typeof(T)} элементов:");
            Console.WriteLine($"Количество элементов {list.Count}");
            for (int i = 1; i <= list.Count; i++)
            {
                Console.WriteLine($"{i}-й элемент : {list.GetData(i).ToString()}");
            }
        }

        //удаление данных
        public void Delete(int index)
        {
            if (index > count)
            {
                Console.WriteLine($"Введен неверный индекс {index}. Количество элементов в списке {Count}");
            }

            if (index == 1)  //если удаляем голову
            {
                head = head.Next;
            }
            else if (index == Count)     //если удаляем хвост
            {
                Item<T> item = GetElement(index-1);
                Tail = item;
                item.Next = null;
            }
            else
            {
                Item<T> itemPrev = GetElement(index - 1);
                Item<T> itemNext = GetElement(index + 1);
                itemPrev.Next = itemNext;
            }
            count--;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            MyList<int> list1 = new MyList<int>();
            list.Add(1);
            list.Add(2277);
            list.Add(333);
            list.Add(4444);
            list.Add(55555);
            //Console.WriteLine($"Количество элементов {list.Count}");
            //Console.WriteLine($"{1}-й элемент {list.GetData(1).ToString()}");
            //Console.WriteLine($"{2}-й элемент {list.GetData(2).ToString()}");
            //Console.WriteLine($"{3}-й элемент {list.GetData(3).ToString()}");
            MyList<int>.PrintList(list);
            Console.WriteLine(new string('-', 35));
            MyList<int>.PrintList(list1);
            //list.GetData(5);
            //Console.WriteLine(new string('-', 35));
            //Console.WriteLine($"{3}-й элемент {list.GetElement(3).ToString()}");
            //Console.WriteLine($"{1}-й элемент {list.GetElement(1).ToString()}");
            ////Console.WriteLine($"{0}-й элемент {list.GetElement(0).ToString()}");
            ////Console.WriteLine($"{6}-й элемент {list.GetElement(6).ToString()}");
            //Console.WriteLine(new string('-', 35));
            //list.Delete(5);
            //MyList<int>.PrintList(list);
            //list.Delete(2);
            //MyList<int>.PrintList(list);

            Console.ReadKey();
        }
    }
}
