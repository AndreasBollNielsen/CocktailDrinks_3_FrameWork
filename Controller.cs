using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CocktailDrinks_3_FrameWork
{
    public class Controller
    {
        //search through the database for drinks
        public List<Drink> SearchDrink(string searchQuery)
        {
            List<Drink> drinks = new List<Drink>();
            using (var dbContext = new CocktailContext())
            {
                var query = from drink in dbContext.Drinks.Include(x => x.DrinkRecipe.Ingredients).Include(x => x.DrinkRecipe.Accessories).Include(x => x.DrinkRecipe.Glass_Type)
                            where drink.Name.Contains(searchQuery) || (drink.DrinkRecipe.Ingredients.Any(x => x.Name.Contains(searchQuery)))
                            select drink;

                drinks = query.ToList();

            }

            return drinks;
        }

        //adding new drink to DB
        public void CreateDrink(Drink newDrink)
        {
            using (var dbContext = new CocktailContext())
            {
                dbContext.Drinks.Add(newDrink);
                dbContext.SaveChanges();
                Console.WriteLine("drink er blevet oprettet");

            }
        }

        //get all Drinks from Database
        public List<Drink> GetDrinks()
        {
            using (var dbContext = new CocktailContext())
            {
                var query = dbContext.Drinks.Include(x => x.DrinkRecipe.Ingredients).Include(x => x.DrinkRecipe.Accessories).Include(x => x.DrinkRecipe.Glass_Type).ToList();
                return query;
            }
        }

        //change drink
        public void UpdateDrink(int id,Drink changedDrink)
        {
            using (var dbContext = new CocktailContext())
            {
                var currentDrink = dbContext.Drinks.Find(id);
                currentDrink.Name = changedDrink.Name;
                currentDrink.DrinkRecipe = changedDrink.DrinkRecipe;
                dbContext.SaveChanges();
            }
        }

        //delte drink
        public void DeleteDrink(int id)
        {
            using (var dbContext = new CocktailContext())
            {
                Drink drinkToDelete = dbContext.Drinks.Find(id);
                dbContext.Drinks.Remove(drinkToDelete);
                dbContext.SaveChanges();
            }
        }

    }
}
