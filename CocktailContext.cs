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
        public CocktailContext() : base("name=DBCocktail")
        {
            Database.SetInitializer<CocktailContext>(new CreateDatabaseIfNotExists<CocktailContext>());
        }

        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
