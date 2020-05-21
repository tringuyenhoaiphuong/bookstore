using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int ParentId { get; set; }
    }
}
