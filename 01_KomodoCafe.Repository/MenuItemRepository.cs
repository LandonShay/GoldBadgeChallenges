using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    // The manager wants to be able to create new menu items, delete menu items,
    // and receive a list of all items on the cafe's menu. She needs a console app.
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _menuItemContext = new List<MenuItem>();
        private MenuItemRepository _menuItemRepo;
        private int _count;
        public bool AddMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                return false;
            }
            else
            {
                _count++;
                menuItem.MealNumber = _count;
                _menuItemContext.Add(menuItem);
                return true;
            }
        }

        public List<MenuItem> ViewAllMenuItems()
        {
            return _menuItemContext;
        }

        public MenuItem GetOneItem(int number)
        {
            foreach (MenuItem item in _menuItemContext)
            {
                if (item.MealNumber == number)
                {
                    return item;
                }
            }
            return null;
        }

        public bool DeleteMenuItem(MenuItem menuItem)
        {
            bool deleteMenuItem = _menuItemContext.Remove(menuItem);
            return deleteMenuItem;
        }
    }
}
