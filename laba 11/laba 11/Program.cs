using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Введите количество символов, которое должно совпадать с символами месяцев");
            int n = int.Parse(Console.ReadLine());
            IEnumerable<string> Months1 = months.Where(m => m.Length == n);
            foreach (string item in Months1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Только летние и зимние месяцы:");
            IEnumerable<string> Months2 = from m in months where m.StartsWith("J") || m.StartsWith("F") || m.StartsWith("Au") || m.StartsWith("D") select m;
            foreach (string item in Months2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Месяц в алфавитном порядке:");
            IEnumerable<string> Months3 = months.OrderBy(s => s);
            foreach (string item in Months3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Месяцы с \"u\" и длиной строки не менне 4ех: ");
            IEnumerable<string> Months4 = months.Where(n1 => n1.Contains("u") && n1.Length >= 4);
            foreach (string item in Months4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Book book1 = new Book("Лесное чудище", "Дима", "Беларусь", 2001, 241, 44, "тонкий", 3);//создаем книги
            Book book2 = new Book("Обитель Анубиса", "Саша", "Германия", 1995, 321, 32, "широкий", 6);
            Book book3 = new Book("Важный человек", "Дима", "США", 1950, 321, 100, "тонкий", 4);
            Book book4 = new Book("Величайший шоумен", "Женя", "Италия", 2010, 321, 28, "широкий", 2);
            Book book5 = new Book("Ведьмы", "Алина", "Норвегия", 1991, 321, 74, "тонкий", 8);

            List<Book> library = new List<Book>();//добавдяем в список
            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);

            Console.WriteLine("Введите автора для поиска:");
            string findAuthor = Console.ReadLine();
            var lib1 = library.Where(n3 => n3.Author == findAuthor);//находим книги по автору и добавляем в список
            foreach (Book item in lib1)//выводим их
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Year);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Введите, после какого года необходим список книг:");
            int year = int.Parse(Console.ReadLine());
            var lib2 = library.Where(n3 => n3.Year > year);
            foreach (Book item in lib2)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Year);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Cписок книг отсортированных по цене...");
            var lib3 = library.OrderBy(n4 => n4.Cost);
            foreach (Book item in lib3)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Cost);
            }
            Console.WriteLine("------------------------------------------------");

            var lib4 = library.Min(n5 => n5.BlindingTypeNumber);
            Console.WriteLine("Самая тонкая книга имеет толщину: " + lib4);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("5 первых самых толстых книг...");
            var lib5 = library.OrderByDescending(n5 => n5.BlindingTypeNumber).Take(5);
            foreach (Book item in lib5)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + "толщина: " + item.BlindingTypeNumber);
            }
            Console.WriteLine("------------------------------------------------");

            List<Team> teams = new List<Team>()//создаем команды
            {
                new Team { Name = "Оттава Сенаторз", Country ="Канада" },
                new Team { Name = "Сиэтл Кракен", Country ="США" }
            };
            List<Player> players = new List<Player>()//создаем игроков
            {
            new Player {Name="Мэтт Мюррей", Team="Оттава Сенаторз"},
            new Player {Name="Тома Шабо", Team="Оттава Сенаторз"},
            new Player {Name="Томми Томпсон", Team="Сиэтл Кракен"}
            };
            //выводим информацию о игроках
            var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country }); 
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");      
    }
    }
}
