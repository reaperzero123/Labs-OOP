using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Client first_client = new Client("Карпович Илья");
            try//ищем исключения
            {
                Console.WriteLine("---------------------------------------------------------------------");
                try//ищем исключения
                {
                    Waybill first_waybill = new Waybill("Накладная на машину", new DateTime(2020, 11, 12), first_client, new Organization("С"), 7800, 1);
                }
                catch (IsNotNameOfOrganization ex)//если находит исключение связанное с неправильным именем организации выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try//ищем исключения
                {
                    Receipt first_receipt = new Receipt("Кви", new DateTime(2020, 12, 08), first_client, new Organization("Организация 1"), 650, 2);
                }
                catch (IsNotTitle ex)//если находит исключение связанное с неправильным названием формы выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try//ищем исключения
                {
                    Check first_check = new Check("Чек за оплату мобильного телефона ", new DateTime(2019, 11, 15), first_client, new Organization("А1"), 50, 3);
                }
                catch (WrongIdValue ex)//если находит исключение связанное с неправильным значением id выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");
             
                Waybill second_waybill = new Waybill("Накладная на стиральную машину", new DateTime(2013, 03, 15), first_client, new Organization("Atlant"), 1200, 0);
                Waybill third_waybill = new Waybill("Накладная на мобильный телефон", new DateTime(2014, 02, 10), first_client, new Organization("АЛЛО"), 800, 5);
                Waybill fours_waybill = new Waybill("Накладная на машину", new DateTime(2020, 07, 12), first_client, new Organization("Пограничная служба"), 1200, 6);

                Document[] documents = new Document[] { second_waybill, third_waybill, fours_waybill};

                try//ищем исключения
                {
                    Console.WriteLine(documents[4].Id);
                }
                catch (IndexOutOfRangeException ex)//если находит исключение связанное с неправильным указанным количеством элементов в массиве выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try//ищем исключения
                {
                    object obj = third_waybill.Title;
                    int title = (int)obj;
                }
                catch (InvalidCastException ex)//если находит исключение связанное с невозможным приведением выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");
                try//ищем исключения
                {
                    double countHashCode = third_waybill.Id / second_waybill.Id;

                }
                catch (DivideByZeroException ex)//если находит исключение связанное с делением на ноль выводит данные об ошибке
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("---------------------------------------------------------------------");

                int index = 10;
                Debug.Assert(index > -1, "Значение должно быть больше -1");
            }
            catch (Exception ex)//если находит любое исключение
            {
                Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
            }
            finally//выполняется всегда после try и catch
            {
                Console.WriteLine("Finally block");
            }
        }
    }
}
