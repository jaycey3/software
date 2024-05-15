using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        private const int capacity = 10;
        public List<Animal> Contents { get; set; }

        public Wagon()
        {
            Contents = new List<Animal>();
        }

        public bool TryToAddAnimal(Animal animal)
        {
            int animalSize = (int)animal.AnimalSize;
            int wagonContents = 0;

            foreach (Animal animalInWagon in Contents)
            {
                wagonContents += (int)animalInWagon.AnimalSize;
            }

            if (wagonContents >= capacity ||
                wagonContents + animalSize > capacity ||
                WillAnimalsEatEachOther(animal))
            { 
                return false;
            }
            else
            {
                this.AddAnimal(animal);
                return true;
            }
        }
        public bool WillAnimalsEatEachOther(Animal newAnimal)
        {
            foreach (Animal wagonAnimal in Contents)
            {
                if (newAnimal.WillEatEachother(wagonAnimal))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddAnimal(Animal animal)
        {
            Contents.Add(animal);
        }
    }
}
