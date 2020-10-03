using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class03.EntityFramework.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Book(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
