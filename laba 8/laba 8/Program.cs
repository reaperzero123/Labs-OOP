using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8
{
    class Program
    {
        interface IInterface<T>
        {
            CollectionType<T> add(CollectionType<T> mass1, CollectionType<T> mass2);
            CollectionType<T> delete(CollectionType<T> mass2);
            CollectionType<T> outmass(CollectionType<T> mass2);
        }
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> mass1 = new CollectionType<int>() { abc = { 1, 6, 4, 7, 9, 3 } };//создаем 2 коллекции
                CollectionType<int> mass2 = new CollectionType<int>() { abc = { 6, 1, 7, 5 } };
                mass2.add(mass1, mass2);//объеденяем коллекции
                string way = @"C:\Users\HP\Desktop\laba 8\laba 8\8.txt";//записываем их в файл
                using (StreamWriter file = new StreamWriter(way))
                {
                    foreach (int i in mass2.abc)
                    {
                        file.WriteLine(i);
                    }
                }
                using (StreamReader str = new StreamReader(way))//читаем из файла
                {
                    string strall;
                    while ((strall = str.ReadLine()) != null)
                    {
                        Console.WriteLine(strall);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oшибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        }









        public class CollectionType<T> : IInterface<T>
        {
            public List<T> abc = new List<T> { };
            public CollectionType<T> add(CollectionType<T> mass1, CollectionType<T> mass2)
            {
                if ((mass1.abc != null && mass1.abc.Count > 0) && (mass2.abc != null && mass2.abc.Count > 0))
                {
                    mass2.abc.AddRange(mass1.abc);
                }
                mass2.abc = mass2.abc.ToList();
                return mass2;
            }
            public CollectionType<T> delete(CollectionType<T> mass2)
            {
                if (mass2.abc != null && mass2.abc.Count > 0)
                {
                    mass2.abc.RemoveAt(Count(mass2));
                }
                return mass2;
            }
            public CollectionType<T> outmass(CollectionType<T> mass2)
            {
                foreach (T i in mass2.abc)
                {
                    Console.WriteLine(i);
                }
                return mass2;
            }
            public static int Count(CollectionType<T> mass2)
            {
                int counter = 0;
                foreach (T i in mass2.abc)
                {
                    counter++;
                }
                return counter;
            }
            public static CollectionType<T> operator +(CollectionType<T> mass1, CollectionType<T> mass2)
            {
                CollectionType<T> mass3 = new CollectionType<T>() { };
                if ((mass1.abc != null && mass1.abc.Count > 0) && (mass2.abc != null && mass2.abc.Count > 0))
                {
                    mass3.abc.AddRange(mass1.abc);
                    mass3.abc.AddRange(mass2.abc);
                }
                mass3.abc = mass3.abc.ToList();
                return mass3;
            }
            public static explicit operator int(CollectionType<T> set)
            {
                int x = set.abc.Count();
                return x;
            }
            public class CollectionA<T>
            {

            }
            public class CollectionB<T> where T : CollectionA<int>
            {

            }
        }
    }
}
