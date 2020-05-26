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
        public int? ParentId { get; set; }

        public Menu Parent { get; set; }

        public virtual ICollection<Menu> ChildMenus { get; set; }
    }
}
