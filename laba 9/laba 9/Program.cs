using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void BeLate(string str);
    public delegate void TakeMoney(object obj, EventArgs args);
    public delegate void Promotion(object obj, EventArgs args, string str);
    public delegate void Balance(Student b);
    class Program
    {
        static void Main(string[] args)
        {
            BeLate massage = (str) => Console.WriteLine(str);
            Balance balance = (show) => Console.WriteLine($"Текущая зарплата: { show.Salary} рублей");

            Dekan dekan = new Dekan();//создаем декана

            Student student1 = new Student(220, "студент");//создаем студента
            Undergraduate undergraduate1 = new Undergraduate(380, "магистрант");//создаем магистра
            
            student1.Late(); //добавляем опаздания студенту 
            student1.Late();

            balance(student1);//смотрим зарплату
            dekan.money += student1.Money;
            dekan.money += undergraduate1.Money; //подсчитываем количество денег которые заплатит декан
            dekan.newMoney();//проверяем пропуски
            student1.Late();//добавляем опаздания студенту
            student1.Late();
            balance(student1);//смотрим зарплату
            dekan.newMoney();//проверяем пропуски, если превысил уменьшаем зарплату
            balance(student1);//смотрим зарплату

            dekan.promotion += student1.ToPromoteStudent;//повышаем студента и магистра до выпускников
            dekan.ToPromote("выпускник-студент"); 
            dekan.promotion -= student1.ToPromoteStudent; 
            dekan.promotion += undergraduate1.ToPromoteUndergraduate;
            dekan.ToPromote("выпускник-магистрант");
            balance(undergraduate1);//смотрим зарплату
            Console.WriteLine();

            string str1 = "Beer of bear";

            //5 действий со строкой

            Func<string, string> func;    //удаляем буквы а        
            func = ChangeString.Delet;
            str1 = func(str1);
            Console.WriteLine(str1);

            Action<string, char> action;    //добавляем в конец букву s
            action = ChangeString.AddLetter;
            action(str1, 's');

            func += ChangeString.Oa;    //заменяем все e на A
            str1 = func(str1);
            Console.WriteLine(str1);

            func += ChangeString.SToApper;  //переводим все в верхний регистр
            str1 = func(str1);
            Console.WriteLine(str1);

            func += ChangeString.SToLower;  //переводим все в нижний регистр
            str1 = func(str1);
            Console.WriteLine(str1);
        }
    }
}
