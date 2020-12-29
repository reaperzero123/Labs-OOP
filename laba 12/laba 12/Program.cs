using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public interface Show
    {
        void Show();
    }
    public class Test : Show
    {
        public string name;
        public Test(string name)
        {
            this.name = name;
        }
        public Test()
        {
            this.name = null;
        }
        public void Show()
        {
            Console.WriteLine(name);
        }
        public void ToConsole(List<string> spisok)
        {
            foreach (string str in spisok)
            {
                Console.WriteLine(str);
            }
        }
        public override string ToString()
        {
            return "Объект класса Test с именем " + name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
    static class Reflector
    {
        static public void ClName(string classname) 
        {
            Assembly tekushchayaAssembly = Assembly.GetExecutingAssembly();
            Type t = tekushchayaAssembly.GetType(classname);
            Assembly assem = t.Assembly;
            Console.WriteLine("Полное имя сборки: ");//выводим полное имя сборки
            Console.WriteLine(assem.FullName);
            Console.WriteLine();
            Console.WriteLine("Расположение сборки: ");//выводим располоение сборки
            Console.WriteLine(assem.CodeBase);
        }
        static public void GetConstructor(string classname) 
        {
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            Console.WriteLine();
            Console.WriteLine("Имеет ли класс конструкторы?");//проверяем есть ли у класса в конструкторе
            if (p.Length > 0)
                Console.WriteLine($"Да, {p.Length}");
            else
                Console.WriteLine("Нет!");
        }
        static public void Publi(string classname) 
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список методов: ");//выводим список методов
            foreach (MethodInfo cMethod in t.GetMethods()) 
            {
                Console.WriteLine(cMethod.Name);
            }
        }
        static public void Field(string classname) 
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список полей: ");//выводим информацию о полях
            foreach (FieldInfo fInfo in t.GetFields())
            {
                Console.WriteLine(fInfo.FieldType.Name + " " + fInfo.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Список свойств: ");//выводим информацию о свойствах
            foreach (PropertyInfo pInfo in t.GetProperties())
            {
                Console.WriteLine(pInfo.PropertyType.Name + " " + pInfo.Name);
            }
        }
        static public void Interface(string classname) 
        {
            Type t = Type.GetType(classname); 
            Console.WriteLine();
            Console.WriteLine("Список интерфейсов: ");//выводим информацию о интерфейсах
            foreach (Type tp in t.GetInterfaces())
            {
                Console.WriteLine(tp.Name);
            }
        }
        static public void MethodForType(string classname, string parametr) 
        {
            Type t = Type.GetType(classname);
            MethodInfo[] methods = t.GetMethods();
            Console.WriteLine();
            Console.WriteLine("Методы класса {0} с типом аргумента: {1}", classname, parametr);//выводим информацию о методах класса с заданный тип параметров
            for (int i = 0; i < methods.Length; i++)
            {
                ParameterInfo[] param = methods[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name)
                    {
                        Console.WriteLine(methods[i].Name);
                    }
                }
            }
        }
        public static void CallMethod(string className, string methodName) 
        {
            Type type = Type.GetType(className);
            List<string> FirstParam = File.ReadAllLines(@"C:\Users\HP\Desktop\laba 12\laba 12\Refl.txt").ToList();//берем имя метода, параметры и объект из файла
            List<string>[] parametrs = new List<string>[] { FirstParam };
            try
            {
                object obj = Activator.CreateInstance(type);//выполняем метод и выводим информацию о выполнении
                MethodInfo method = type.GetMethod(methodName);
                Console.WriteLine();
                Console.WriteLine("Результат выполнения метода: ");
                Console.WriteLine(method.Invoke(obj, parametrs));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public void Create(string classname, string name) 
        {
            Type t = Type.GetType(classname);
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            object obj = Activator.CreateInstance(t, args: name); 
            Console.WriteLine(obj.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.ClName("lab12.Test"); 
            Reflector.GetConstructor("lab12.Test");
            Reflector.Publi("lab12.Test"); 
            Reflector.Field("lab12.Test"); 
            Reflector.Interface("lab12.Test"); 
            Reflector.MethodForType("lab12.Test", "Int32"); 
            Reflector.CallMethod("lab12.Test", "ToConsole");
            Reflector.Create("lab12.Test", "Alina FIT"); 
    }
}
}