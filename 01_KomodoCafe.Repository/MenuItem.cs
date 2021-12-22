using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItem
    {
        public MenuItem()
        {

        }

        public MenuItem(int mealNumber, string mealName, string mealDescription, string ingredients, double price)
        {
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
            MealNumber = mealNumber;
            MealName = mealName;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }

    }
}
