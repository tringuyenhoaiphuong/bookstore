using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Categorybook
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
