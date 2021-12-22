using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private readonly MenuItemRepository _menuItemRepo;

        public ProgramUI()
        {
            _menuItemRepo = new MenuItemRepository();
        }

        public void Run()
        {
            RunApplication();
        }

        public void RunApplication()
        {
            bool keepLooping = true;
            while (keepLooping == true)
            {
                Console.Clear();
                Console.WriteLine("Menu Item Database\n" +
                    "1. Add New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. Delete Menu Item");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItems();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;

                }
            }
        }

        public void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem menuItem = new MenuItem();
            Console.WriteLine("Please enter the name of the item you'd like to add.");
            menuItem.MealName = Console.ReadLine();
            Console.WriteLine($"Please list all ingredients in {menuItem.MealName}.");
            menuItem.Ingredients = Console.ReadLine();
            Console.WriteLine($"Please enter {menuItem.MealName}'s description.");
            menuItem.MealDescription = Console.ReadLine();
            Console.WriteLine($"Please enter {menuItem.MealName}'s price.");
            menuItem.Price = double.Parse(Console.ReadLine());
            _menuItemRepo.AddMenuItem(menuItem);
        }

        public void ViewAllMenuItems()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.ReadKey();
        }

        public void DeleteMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Please enter the meal number of the item you'd like to delete.");
            DisplayAllMenuItems();
            int input = int.Parse(Console.ReadLine());
            MenuItem menuItem = _menuItemRepo.GetOneItem(input);
            _menuItemRepo.DeleteMenuItem(menuItem);
        }

        public void DisplayAllMenuItems()
        {
            List<MenuItem> list = _menuItemRepo.ViewAllMenuItems();
            foreach (MenuItem menuItem in list)
            {
                Console.WriteLine($"Item Name: {menuItem.MealName}\n" +
                    $"Item Description: {menuItem.MealDescription}\n" +
                    $"Item Ingredients: {menuItem.Ingredients}\n" +
                    $"Item Number: {menuItem.MealNumber}\n" +
                    $"Item Price: {menuItem.Price}\n" +
                    $"");
            }
        }
    }
}
