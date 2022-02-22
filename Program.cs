using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CocktailDrinks_3_FrameWork
{
    class Program
    {
        static Controller controller = new Controller();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                //user is represented with choices
                Console.WriteLine("vælg følgende muligheder: \n tast 1 for at søge efter drinks " +
                    "\n tast 2 for at få vist et menu kort " +
                    "\n tast 3 for at lave en ny drink " +
                    "\n tast 4 for at ændre en drink " +
                    "\n tast 5 for at slette en drink" +
                    "\n tast 0 for at lukke");

                SelectOption(int.Parse(Console.ReadLine()));

            }

            //method for switching different menus
            void SelectOption(int option)
            {
                switch (option)
                {
                    case 1:
                        Menu_SearchDrink();
                        break;
                    case 2:
                        Menu_ShowDrinks();
                        break;
                    case 3:
                        Menu_CreateDrink();
                        break;
                    case 4:
                        Menu_ChangeDrink();
                        break;
                    case 5:
                        Menu_DeleteDrink();
                        break;
                    case 0:
                        running = false;
                        break;

                    default:
                        break;
                }
            }

        }

        //creates a new drink 
        private static void Menu_CreateDrink()
        {
            Console.Write("Drink navn: ");
            string drinkName = Console.ReadLine();


            //add ingredients to drink
            Console.Write("vælg antal ingredienser: ");
            int incredientsNum = int.Parse(Console.ReadLine());
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < incredientsNum; i++)
            {
                Ingredient ingre = new Ingredient();
                Console.Write("ingrediens navn: ");
                ingre.Name = Console.ReadLine();
                Console.Write("mængde: ");
                ingre.Amount = int.Parse(Console.ReadLine());
                ingredients.Add(ingre);

            }


            //add accessories
            Console.Write("vælg antal tilbehør: ");
            int accessoriesNum = int.Parse(Console.ReadLine());
            List<Accessory> accessories = new List<Accessory>();
            for (int j = 0; j < accessoriesNum; j++)
            {
                Accessory acc = new Accessory();
                Console.Write("ingrediens navn: ");
                acc.Name = Console.ReadLine();

                accessories.Add(acc);
            }

            //add glass type
            Console.WriteLine("indtast 1 for at vælge lille str glas " +
                "\n indtast 2 for at vælge mellem str glas " +
                "\n indtast 3 for at vælge stor str glas " +
                "\n indtast 4 for at vælge cocktail glas" +
                "\n indtast 5 for at vælge Flute glas" +
                "\n indtast 6 for at vælge Poko Grange glas");

            int glassNum = int.Parse(Console.ReadLine());
            string glasName = GetGlassName(glassNum);

            //create new Drink class
            Recipe recipe = new Recipe() { Name = drinkName, Glass_Type = new GlassType() { Name = glasName }, Accessories = accessories, Ingredients = ingredients };
            Drink drink = new Drink() { Name = drinkName, DrinkRecipe = recipe };

            controller.CreateDrink(drink);

        }

        //deletes a drink from id
        private static void Menu_DeleteDrink()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("vent venligst...");

                List<Drink> drinks = controller.GetDrinks();
                foreach (Drink drink in drinks)
                {
                    Console.WriteLine($"id: {drink.ID}  Name: {drink.Name}");
                }

                Console.WriteLine("indtast id nummeret for drinken du vil slette");
                int _id = int.Parse(Console.ReadLine());

                controller.DeleteDrink(_id);

                Console.WriteLine("tast 1 for at vende tilbage til hoved menu " +
                      "\ntast 2 for at slette en ny drink");

                int choice = int.Parse(Console.ReadLine());

                //exit menu 
                if (choice < 2)
                {
                    run = false;
                }
            }
        }


        //changes the name of the drink or adds or removes an ingredient
        private static void Menu_ChangeDrink()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();

                Console.WriteLine("Indtast id nummeret for den drink du gerne vil opdatere");
                List<Drink> drinks = controller.GetDrinks();
                foreach (Drink drink in drinks)
                {
                    Console.WriteLine($"id: {drink.ID}  Name: {drink.Name}");
                }
                int _id = int.Parse(Console.ReadLine());
                Drink d = drinks.Where(x => x.ID == _id).FirstOrDefault();
                Drink updatedDrink = controller.SearchDrink(d.Name).FirstOrDefault();

                Console.WriteLine("tast 1 for at tilføje en ingrediens" +
                    "\ntast 2 for at fjerne en ingrediens" +
                    "\nindtast 3 for at ændre navnet på drinken");

                int ingredientChoice = int.Parse(Console.ReadLine());
                if (ingredientChoice == 1)
                {
                    foreach (var ingredient in d.DrinkRecipe.Ingredients)
                    {
                        Console.WriteLine($"id: {ingredient.ID}  navn: {ingredient.Name}");
                    }


                    Ingredient ingre = new Ingredient();
                    Console.Write("ingrediens navn: ");
                    ingre.Name = Console.ReadLine();
                    Console.Write("mængde: ");
                    ingre.Amount = int.Parse(Console.ReadLine());
                    updatedDrink.DrinkRecipe.Ingredients.Add(ingre);
                }
                else if (ingredientChoice == 2)
                {
                    int index = 0;
                    foreach (var ingredient in d.DrinkRecipe.Ingredients)
                    {
                        Console.WriteLine($"id: {index + 1}  navn: {ingredient.Name}");
                        index++;
                    }

                    Console.WriteLine("indtast id nummeret på den ingrediens du vil fjerne");
                    int deleteId = int.Parse(Console.ReadLine());
                    updatedDrink.DrinkRecipe.Ingredients.RemoveAt(deleteId - 1);
                }
                else if (ingredientChoice > 2)
                {
                    Console.Write("indtast det nye navn på drinken: ");
                    string drinkName = Console.ReadLine();
                    updatedDrink.Name = drinkName;
                }

                controller.UpdateDrink(_id, updatedDrink);

                Console.WriteLine("tast 1 for at vende tilbage til hoved menu " +
                     "\ntast 2 for at ændre ny drink");

                int choice = int.Parse(Console.ReadLine());

                //exit menu 
                if (choice < 2)
                {
                    run = false;
                }

            }
        }

        //shows a list of drinks
        private static void Menu_ShowDrinks()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("søger...");

                List<Drink> drinksList = controller.GetDrinks();
                if (drinksList.Count > 0)
                {
                    ShowDrinks(drinksList);
                }
                else
                {
                    Console.WriteLine("Der er desværre ingen drinks i dag...\n");
                }

                Console.WriteLine("tast 1 for at vende tilbage til hoved menu " +
                      "\ntast 2 for at hente menuen igen");

                int choice = int.Parse(Console.ReadLine());

                //exit menu 
                if (choice < 2)
                {
                    run = false;
                }
            }
        }

        //gets a list of drinks from a search string. looks up in drinks name & ingredients
        private static void Menu_SearchDrink()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("indtast søgekriterie");
                string searchQuery = Console.ReadLine();
                Console.WriteLine("søger...");
                List<Drink> drinksList = controller.SearchDrink(searchQuery);

                if (drinksList.Count > 0)
                {
                    ShowDrinks(drinksList);
                }
                else
                {
                    Console.WriteLine("søgningen gav intet resultat...\n");
                }

                Console.WriteLine("tast 1 for at vende tilbage til hoved menu " +
                       "\ntast 2 for ny søgning");

                int choice = int.Parse(Console.ReadLine());

                //exit menu 
                if (choice < 2)
                {
                    run = false;
                }

            }

        }

        //helper methods
        private static string GetGlassName(int choice)
        {
            string name = "";
            switch (choice)
            {
                case 1:
                    name = "lille";
                    break;
                case 2:
                    name = "mellem";
                    break;
                case 3:
                    name = "stor";
                    break;
                case 4:
                    name = "cocktail";
                    break;
                case 5:
                    name = "Flute";
                    break;
                case 6:
                    name = "Poko Grange";
                    break;
                default:
                    break;
            }
            return name;
        }
        //generic print method for gui
        public void PrintSingleResult(string result)
        {

        }

        private static void ShowDrinks(List<Drink> drinksList)
        {
            foreach (Drink drink in drinksList)
            {
                Console.WriteLine(new string('-', 25));
                Console.WriteLine($"Drink name: {drink.Name}\nGlass: {drink.DrinkRecipe.Glass_Type.Name}");
                Console.Write("Ingredients: ");
                foreach (Ingredient ingredient in drink.DrinkRecipe.Ingredients)
                {
                    Console.Write($"{ingredient.Name},");
                }
                Console.WriteLine("\n");
                Console.Write("Accessories: ");
                foreach (Accessory accessory in drink.DrinkRecipe.Accessories)
                {
                    Console.Write($"{accessory.Name},");
                }
                Console.WriteLine("\n");

            }
            Console.WriteLine("\n");
        }
    }
}
