using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Dekan
    {
        public event TakeMoney money;
        public event Promotion promotion;
        public void newMoney()
        {
            Console.WriteLine("Проверяем пропуски...");
            money?.Invoke(this, null); 
            Console.WriteLine();
        }
        public void ToPromote(string newPosotion)
        {
            Console.WriteLine("Назначаем новую должность...");
            promotion?.Invoke(this, null, newPosotion);
            Console.WriteLine();
        }
    }
    public class Student
    {
        private int salary;
        private string position;
        public int lateCounter = 0;

        BeLate late; 
        public void RegisterHandler(BeLate late)
        {
            this.late = late;
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public Student() { }
        public Student(int salary, string position)
        {
            Salary = salary;
            Position = position;
        }
        public void Late()
        {
            lateCounter++;
            Console.WriteLine("Студент опоздал!");
            late?.Invoke($"Количество опозданий: {lateCounter}");
            Console.WriteLine();
        }
        public virtual void Money(object sender, EventArgs e) 
        {
            if (lateCounter >=3)
            {
                Console.WriteLine("Слишком много опозданий, штраф 10 рублей");
                Salary -= 10;
            }
            else Console.WriteLine("Допустимое количество опазданий");
        }
        public void ToPromoteStudent(object sender, EventArgs e, string str)  
        {
            Position = str;
            Console.WriteLine($"Новая должность: {Position}");
        }
    }
    public class Undergraduate : Student
    {
        public Undergraduate(int salary, string position) : base(salary, position)
        {
        }
        public override void Money(object sender, EventArgs e) 
        {
            if (lateCounter >= 3)
            {
                Console.WriteLine("Слишком много опозданий, штраф 10 рублей");
                Salary -= 10;
            }
            else Console.WriteLine("Допустимое количество опазданий");
        }
        public void ToPromoteUndergraduate(object sender, EventArgs e, string str)  
        {
            Position = str;
            Console.WriteLine($"Новая должность: {Position}");
        }
    }
    static public class ChangeString
    {
        public static string SToApper(string str)
        {
            str = str.ToUpper();
            return str;
        }
        public static string SToLower(string str)
        {
            str = str.ToLower();
            return str;
        }
        public static string Delet(string str)
        {
            int del = 10;
            str = str.Remove(del, 1);
            return str;
        }
        public static void AddLetter(string str, char letter)
        {
            str = str + letter;
            Console.WriteLine(str);
        }
        public static string Oa(string str)
        {
            str = str.Replace("e", "A");
            return str;
        }
    }
}
