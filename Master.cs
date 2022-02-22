using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDrinks_3_FrameWork
{
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
