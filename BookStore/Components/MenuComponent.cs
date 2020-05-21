using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class MenuComponent : ViewComponent
    {
        private MenuService _menuService;

        public MenuComponent(MenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Menu> menus = _menuService.GetAllMenus();
            return View(menus);
        }
    }

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
