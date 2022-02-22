using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
    public class Drink : Master
    {
        private Recipe drinkRecipe;

        public Recipe DrinkRecipe
        {
            get { return drinkRecipe; }
            set { drinkRecipe = value; }
        }

    }
}
