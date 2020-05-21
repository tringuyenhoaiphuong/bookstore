using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Category
    {
        public Category()
        {
            Categorybook = new HashSet<Categorybook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Parentid { get; set; }

        public virtual ICollection<Categorybook> Categorybook { get; set; }
    }
}
