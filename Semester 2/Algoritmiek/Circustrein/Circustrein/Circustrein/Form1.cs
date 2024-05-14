using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circustrein
{
    public partial class Circustrein : Form
    {
        public List<Animal> animals = new List<Animal>();
        public Director Director = new Director();

        public Circustrein()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            wagonList.Items.Clear();
            animals.Clear();
            Director.Train.Wagons.Clear();

            for (int i = 0; i < smallHerbivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            }

            for (int i = 0; i < mediumHerbivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            }

            for (int i = 0; i < largeHerbivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            }

            for (int i = 0; i < smallCarnivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            }

            for (int i = 0; i < mediumCarnivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            }

            for (int i = 0; i < largeCarnivoreCount.Value; i++)
            {
                animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            }

            Director.SortAndProcessAnimals(animals);

            foreach (Wagon w in Director.Train.Wagons)
            {        int wagonIndex = Director.Train.Wagons.IndexOf(w);
                wagonList.Items.Add($"Wagon {wagonIndex + 1}");
            }
        }

        private void WagonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            wagonAnimals.Items.Clear();

            Wagon selectedWagon = Director.Train.Wagons[wagonList.SelectedIndex];

            foreach (Animal animal in selectedWagon.Contents)
            {
                wagonAnimals.Items.Add(animal.ToString());
            }

        }
    }
}
