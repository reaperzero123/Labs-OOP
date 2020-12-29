using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace lab15
{
    class Program
    {
        public static bool Prostie(int n)
        {
            bool result = true;
            if (n > 1)
            {
                for (uint i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Operation()
        {
            int n = 100;
            for (int i = 2; i <= n; i++)
            {
                if (Prostie(i))
                {
                    Console.Write("Второй поток:");
                    Console.WriteLine(i);
                }
            }
        }
        public static void Event()
        {
            for (int i = 2; i < 100; i += 2)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
            Thread.Sleep(20); 
        }
        public static void NEvent()
        {
            for (int i = 1; i < 100; i += 2)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
            Thread.Sleep(20);
        }
        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("prosesses.txt", false, System.Text.Encoding.Default)) 
            {
                foreach (Process p in Process.GetProcesses())
                {
                    sw.WriteLine("Id " + p.Id);
                    sw.WriteLine("Name " + p.ProcessName);
                    sw.WriteLine("Priority " + p.BasePriority);
                    sw.WriteLine("Responding " + p.Responding); 
                    sw.WriteLine("HandleConut " + p.HandleCount);
                    sw.WriteLine();
                }
            }
            using (StreamWriter sw = new StreamWriter("Domain.txt")) 
            {           
                AppDomain app = AppDomain.CurrentDomain;
                sw.WriteLine("Id: " + app.Id);
                sw.WriteLine("Name: " + app.FriendlyName);
                sw.WriteLine("Directory: " + app.BaseDirectory);
                Assembly[] assApp = app.GetAssemblies();
                foreach (Assembly item in assApp)
                {
                    sw.WriteLine("Assembly name: " + item.FullName);
                }
            }
            int n = 100;
            
            Thread th = new Thread(new ThreadStart(Operation));//создаем поток
            Console.WriteLine(th.ThreadState);//выводим информацию о состоянии потока
            Console.WriteLine(th.Priority);//приоритете
            th.Name = "Second Thread";
            Console.WriteLine(th.Name);//имени
            Console.WriteLine("id " + th.ManagedThreadId);//id
            th.Start();//запускаем поток
            for (int i = 2; i <= n; i++)
            {
                if (Prostie(i))
                {
                    Console.Write("Главный поток:");
                    Console.WriteLine(i);
                }
            }
            Thread.Sleep(1000);//останавливаем поток

            Thread th1 = new Thread(new ThreadStart(Event));//создаем потоки
            Thread th2 = new Thread(new ThreadStart(NEvent));
            th1.Priority = ThreadPriority.AboveNormal;//выстовляем приоретет потока выше нормального
            th1.Start();//запускаем потоки
            th2.Start();

            Console.ReadLine();
            int num = 0;//таймер
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);
            Console.ReadLine();
        }
    }
}
