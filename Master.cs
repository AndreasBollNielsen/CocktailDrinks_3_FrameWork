using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
    //parent class for inheritance. 
    //Name & ID is inherited down to Recipe,Drink,GlassType,Ingredient & Accessories classes
    public abstract class Master
    {
        private int id;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
