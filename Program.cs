using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CocktailContext())
            {
                //var ingredient = new Ingredient() { Name = "Gin" };

                //context.Ingredients.Add(ingredient);
                //context.SaveChanges();

                var query = from ing in context.Ingredients
                            where ing.Name == "Gin"
                            select ing;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                //var myingredient = query.FirstOrDefault();

                Console.WriteLine("added ingredient");
                //Console.WriteLine("ingredient name is: " + myingredient.Name);
                Console.ReadLine();
            }
        }
    }
}
