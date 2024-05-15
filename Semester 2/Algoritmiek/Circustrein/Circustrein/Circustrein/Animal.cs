using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Animal
    {
        public enum Size
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        public enum Diet
        {
            Carnivore,
            Herbivore
        }

        public Size AnimalSize { get; set; }
        public Diet AnimalDiet { get; set; }

        public Animal(Size size, Diet diet)
        {
            AnimalSize = size;
            AnimalDiet = diet;
        }

        public override string ToString()
        {
            return AnimalSize.ToString() + " " + AnimalDiet.ToString();
        }

        public bool WillEatEachother(Animal otherAnimal)
        {
            return (this.AnimalDiet == Diet.Carnivore && (int)this.AnimalSize >= (int)otherAnimal.AnimalSize) ||
                   (otherAnimal.AnimalDiet == Diet.Carnivore && (int)otherAnimal.AnimalSize >= (int)this.AnimalSize);
        }
    }
}