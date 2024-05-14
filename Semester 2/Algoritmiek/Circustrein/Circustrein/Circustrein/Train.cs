using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circustrein
{
    public class Train
    {
        public List<Wagon> Wagons { get; set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public List<Wagon> SortAndAddAnimals(List<Animal> animals)
        {
            Wagons.Clear();
            foreach (Animal animal in animals)
            {

                bool animalAdded = false;

                foreach (Wagon wagon in Wagons)
                {
                    if (wagon.TryToAddAnimal(animal, wagon))
                    {
                        animalAdded = true;
                        break;
                    }
                }

                if (!animalAdded)
                {
                    Wagon wagon = new Wagon();
                    wagon.Contents.Add(animal);
                    Wagons.Add(wagon);
                }
            }

            return Wagons;
        }
    }
}