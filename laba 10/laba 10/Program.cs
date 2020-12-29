using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Game<T> : IEnumerable<T> where T : Player
    {
        public BlockingCollection<T> players = new BlockingCollection<T>();
        public Dictionary<int, T> dict = new Dictionary<int, T>();
        public Player winner;
        Random rnd = new Random();
        public void StartGame()
        {
            foreach (var item in players)
            {
                item.number = rnd.Next(1, 1000); 
            }
            winner = players.OrderByDescending(i => i.number).First(); 
        }
        public void Show()
        {
            foreach (var item in players)
            {
                Console.WriteLine(item);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        IEnumerator<T> GetEnumerator()
        {
            foreach (T foo in this.players)
            {
                yield return foo; 
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() 
        {
            return ((IEnumerable<T>)players).GetEnumerator();
        }
    }
    public class Player
    {
        public string name;
        public int number;
        public Player(string name)
        {
            this.name = name;
            this.number = 0;
        }
        public override string ToString()
        {
            return name + " создал число " + number;
        }
    }
    class Program
    {
        public static void Ch(object sender, NotifyCollectionChangedEventArgs e) 
        {
            Console.WriteLine("Коллекция изменилась с действием: " + e.Action);
        }
        static void Main(string[] args)
        {
            Player firstPlayer = new Player("Илья");    //создаем игроков
            Player secondPlayer = new Player("Максим");
            Player thirdPlayer = new Player("Алина");
            Player foursPlayer = new Player("Рома");

            Game<Player> RollGame = new Game<Player>(); //создаем игру

            RollGame.players.Add(firstPlayer);  //добавляем игроков
            RollGame.players.Add(secondPlayer);
            RollGame.players.TryAdd(thirdPlayer); 
            RollGame.players.TryAdd(foursPlayer);

            RollGame.StartGame();   //задаем рандомные числа и находим победителя

            RollGame.Show();    //выводим имена игроков и их числа
            Console.WriteLine("Игрок-победитель -  " + RollGame.winner.name);//выводим победителя
            BlockingCollection<int> test = new BlockingCollection<int>();//создаем коллекцию
            test.Add(1);
            test.Add(5);// добавляем числа в коллекцию
            test.TryAdd(6); 
            int x;//убираем число из коллекции
            test.TryTake(out x);
            foreach (var item in test)//выводим коллекцию
            Console.WriteLine(item);
            RollGame.dict.Add(1, firstPlayer);//добавляем игроков с ключями в "словарь"
            RollGame.dict.Add(2, secondPlayer);
            RollGame.dict.Add(3, thirdPlayer);
            RollGame.dict.Add(4, foursPlayer);

            foreach (KeyValuePair<int, Player> element in RollGame.dict)//выводим словарь
            Console.WriteLine("Ключ: {0}. Значение: {1}", element.Key, element.Value);

            if (RollGame.dict.ContainsValue(secondPlayer))  //проверяем содержит ли значение второй игрок
                Console.WriteLine("Содержит значение");
            else Console.WriteLine("Не содержит значение");

            ObservableCollection<int> obs = new ObservableCollection<int>();//выводим действия с помощью которых изменялась коллекция
            obs.CollectionChanged += Ch;
            obs.Add(5);
            obs.Remove(5);
        }
    }
}