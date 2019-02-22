using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте класс MyClass<T>, содержащий статический фабричный метод -  
//T FacrotyMethod(), который будет порождать экземпляры типа, указанного в качестве параметра типа (указателя места заполнения типом – Т).
namespace Task9_CollectGeneric
{
    public class MyClass<T>
    {
        private T instance;

        public T Instance { get => instance; set => instance = value; }

        public static T FactoryMethod()
        {
             return new MyClass<T>().Instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var intInstance = MyClass<int>.FactoryMethod();
            Console.WriteLine($"intInstance type is {intInstance.GetType()}");
            var longInstance = MyClass<long>.FactoryMethod();
            Console.WriteLine($"longInstance type is {longInstance.GetType()}");
            var stringInstance = MyClass<string>.FactoryMethod();
            stringInstance = "Hello World!";
            Console.WriteLine($"stringInstance type is {stringInstance.GetType()}");

            Console.ReadKey();
        }
    }
}
