using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CocktailDrinks_3_FrameWork
{
    public class CocktailContext : DbContext
    {
        //initializes database
        public CocktailContext() : base("name=DBCocktail")
        {
            Database.SetInitializer<CocktailContext>(new CreateDatabaseIfNotExists<CocktailContext>());
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

    }
}
