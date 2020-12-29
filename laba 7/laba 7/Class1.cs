using System;
using System.Collections.Generic;

namespace lab6
{
    interface IDocument
    {
        void Info();
    }
    public abstract class Document
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new WrongIdValue("Недопустимое значение для задания id ", value);
                }
                else id= value  ;
            }
        }

        private Client client;
        private Organization organization;
        public Document(string title, DateTime date, Client client, Organization organization, int id)
        {
            if (title.Length <= 3)
            {
                throw new IsNotTitle("Недопустимое значение для названия документа", title);
            }
            else this.title = title;
            this.date = date;
            this.client = client;
            this.organization = organization;
            this.id = id;
        }
        public string Name
        {
            get { return client.Name; }
            set { client.Name = value; }
        }
        public string NameOfOrganization
        {
            get { return organization.NameOfOrganization; }
            set { organization.NameOfOrganization = value; }
        }
        public abstract void Info();
        virtual public int GetTotalPrice() { return 0; }
    }
    sealed public class Receipt : Document, IDocument //квитанция
    {
        private int servicePrice;
        public Receipt(string title, DateTime date, Client client, Organization organization, int servicePrice, int id) : base(title, date, client, organization, id)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name + " " + NameOfOrganization + " " + servicePrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed public class Waybill : Document, IDocument //накладная
    {
        private int servicePrice;
        public Waybill(string title, DateTime date, Client client, Organization organization, int servicePrice, int id) : base(title, date, client, organization, id)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()   
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name + " "  + NameOfOrganization + " " + servicePrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed public class Check : Document, IDocument
    {
        private int totalPrice;
        public Check(string title, DateTime date, Client client, Organization organization, int totalPrice, int id) : base(title, date, client, organization, id)
        {
            this.totalPrice = totalPrice;
        }
        public override string ToString()  
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name +  " " + NameOfOrganization + " " + totalPrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + totalPrice);
        }
        override public int GetTotalPrice()
        {
            return totalPrice;
        }
    }
    public class Client
    {
        private string name;
        public Client(string name)
        {
 this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }




    class IsNotNameOfOrganization : ArgumentException
    {
        string Value { get; set; }
        public IsNotNameOfOrganization(string message, string value) : base(message)
        {
            Value = value;
        }
    }
    class IsNotTitle : ArgumentException
    {
        string Value { get; set; }
        public IsNotTitle(string message, string value) : base(message)
        {
            Value = value;
        }
    }
    class WrongIdValue : Exception
    {
        int Value { get; set; }
        public WrongIdValue(string message, int value) : base(message)
        {
            Value = value;
        }
    }
    public class Organization
    {
        private string nameOfOrganization;
        public Organization(string nameOfOrganization)
        {
            if (nameOfOrganization.Length <= 1)
            {
                throw new IsNotNameOfOrganization("Недопустимое значение для имени организации", nameOfOrganization);
            }
            else this.nameOfOrganization = nameOfOrganization;
        }
        public string NameOfOrganization
        {
            get { return nameOfOrganization; }
            set { nameOfOrganization = value; }
        }
    } 
}

