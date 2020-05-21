using System.Collections.Generic;
using System.Linq;
using BookStore.Models;

namespace BookStore.Components
{
    public class MenuService
    {
        private AppDataContext _dataContext;

        public MenuService(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Menu> GetAllMenus()
        {
            return _dataContext.Menu.ToList();
        }
    }
}