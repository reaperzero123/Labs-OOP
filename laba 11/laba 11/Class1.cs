using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class BelBook
    {
        public string BelAuthor { get; set; }
        public string BelTitle { get; set; }
        public BelBook(string belAuthor, string belTitle)
        {
            BelAuthor = belAuthor;
            BelTitle = belTitle;
        }
    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Book
    {
        public string title;
        public string author;
        private string publishingHouse;
        public ushort year;
        private uint pageNumber;
        private uint cost;
        private string blindingType;
        private int blindingTypeNumber;
        public Book(string title, string author, string publishingHouse, ushort year, uint pageNumber, uint cost, string blindingType, int blindingTypeNumber)
        {
            this.title = title;
            this.author = author;
            this.publishingHouse = publishingHouse;
            this.year = year;
            this.pageNumber = pageNumber;
            this.cost = cost;
            this.blindingType = blindingType;
            this.blindingTypeNumber = blindingTypeNumber;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }
        public ushort Year
        {
            get { return year; }
            set
            {
                if (year <= 2020)
                    year = value;
                else year = 0;
            }
        }
        public uint PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }
        public uint Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public string BlindingType
        {
            get { return blindingType; }
            set { blindingType = value; }
        }
        public int BlindingTypeNumber
        {
            get { return blindingTypeNumber; }
            set { blindingTypeNumber = value; }
        }
    }
}


