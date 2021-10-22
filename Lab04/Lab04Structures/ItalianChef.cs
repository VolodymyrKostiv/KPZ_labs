using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class ItalianChef : IChef, IItaliano
    {
        string someItalianString;

        public ItalianChef(Name name, ChefTypes types)
        {
            someItalianString = string.Empty;
        }

        public ItalianChef(Name name, ChefTypes types, string str) 
            : this(name, types)
        {
            someItalianString = str;
        }

        public Dish Cook()
        {
            Dish pizza = new Dish("Pizza", "It's pizza", 20, 30, "Italy", 1522, 600);
            Scream();
            return pizza; 
        }

        public void Scream()
        {
            Console.WriteLine("Molto saporito! Perfettamente! Meraviglioso");
        }

        public void IncreasePortion(Dish dish, int newPrice)
        {
            dish = new Dish("Increased dish", "d", 20, 200, "KPZ", 2021, 0.5) { price = 30 };
            Console.WriteLine(dish.name);
            newPrice = dish.price * 2;
        }

        public void IncreasePortion(ref Dish dish, out int newPrice)
        {
            dish = new Dish("Increased dish", "d", 20, 200, "KPZ", 2021, 0.5) { price = 30 };
            Console.WriteLine(dish.name);
            newPrice = dish.price * 2;
        }
        public void FunctionOverloading(int x) => Console.WriteLine("With int");
        public void FunctionOverloading(double x) => Console.WriteLine("With double");

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ItalianChef p = (ItalianChef)obj;
                return (someItalianString == p.someItalianString);
            }
        }
        public override int GetHashCode()
        {
            return someItalianString.GetHashCode() << 2;
        }
        public override string ToString()
        {
            return someItalianString;
        }
        ~ItalianChef()
        {
            Console.WriteLine("Actually, we don't need this method");
        }
    }
}
