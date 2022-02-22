using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
    public class Recipe: Master
    {
        private GlassType glassType;
        private List<Ingredient> ingredients;
        private List<Accessory> accessories;

        public GlassType Glass_Type
        {
            get { return glassType; }
            set { glassType = value; }
        }
        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        public List<Accessory> Accessories
        {
            get { return accessories; }
            set { accessories = value; }
        }

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            accessories = new List<Accessory>();
        }




    }
}
