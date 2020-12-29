using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    partial struct Information 
    {
        public string document;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client first_client = new Client("Карпович Илья");

            Waybill first_waybill = new Waybill("Накладная 1", new DateTime(2020, 11, 12), first_client, new Organization("Организация 1"), 7800);//добавляем накладную, квитанцию, чек
            Receipt first_receipt = new Receipt("Квитанция 1", new DateTime(2020, 12, 08), first_client, new Organization("Организация 2"), 650);
            Check first_check = new Check("Чек 1", new DateTime(2019, 11, 15), first_client, new Organization("Организация 3"), 50);

            Waybill second_waybill = new Waybill("Накладная 2", new DateTime(2013, 03, 15), first_client, new Organization("Организация 4"), 1200);//добавляем 3 накладные
            Waybill third_waybill = new Waybill("Накладная 3", new DateTime(2014, 02, 10), first_client, new Organization("Организация 5"), 800);
            Waybill fours_waybill = new Waybill("Накладная 4", new DateTime(2020, 07, 12), first_client, new Organization("Организация 6"), 1200);

            Summa summa = new Summa();//заносим все чеки, квитанции, накладные в список
            summa.AddWaybill(first_waybill);
            summa.AddReceipt(first_receipt);            
            summa.AddCheck(first_check);

            summa.AddWaybill(second_waybill);
            summa.AddWaybill(third_waybill);
            summa.AddWaybill(fours_waybill);

            summa.ShowList();//выводим список

            Console.WriteLine("\n"+"Суммарную стоимость продукции заданного наименования по всем накладным = {0}", summa.GetWaybillPrice("Накладная 4"));
            Console.WriteLine(summa.GetCheckCount());
            summa.GetTime(new DateTime(2019, 01, 01), new DateTime(2021, 01, 01));
        }
    }
}
