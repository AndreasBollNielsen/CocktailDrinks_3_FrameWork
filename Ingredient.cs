using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
    public class Ingredient: Master
    {
        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

    }
}
