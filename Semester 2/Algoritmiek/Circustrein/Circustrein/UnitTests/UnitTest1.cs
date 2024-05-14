using Circustrein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace unitests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestC1H5H5H3H3H3_2Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(2, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void TestH3H3H5H5C1C1_2Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(2, Director.Train.Wagons.Count);
        }


        [TestMethod]
        public void TestC1H5H3H3H1H1H1H1H1_2Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(2, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void TestC1C3C5H1H3H5_4Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(4, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void TestC5C5C3C1H5H3H3H3H3H3H1_5Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(5, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void C1H5H5H3H1_2Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(2, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void TestC1C1C1H5H5H5H3H3_3Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(3, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void TestC5C5C5C3C3C3C1C1C1C1C1C1C1H5H5H5H5H5H3H3H3H3H3_13Wagons()
        {
            List<Animal> animals = new List<Animal>();
            Director Director = new Director();

            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));

            Director.SortAndProcessAnimals(animals);

            Assert.AreEqual(13, Director.Train.Wagons.Count);
        }

        [TestMethod]
        public void SortAnimalsTest()
        {
            List<Animal> animals = new List<Animal>();
            Train train = new Train();

            animals.Add(new Animal(Animal.Size.Small, Animal.Diet.Carnivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));
            animals.Add(new Animal(Animal.Size.Large, Animal.Diet.Herbivore));

            train.SortAndAddAnimals(animals);

            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void TryToAddAnimalTest()
        {
            Wagon wagon = new Wagon();

            wagon.Contents.Add(new Animal(Animal.Size.Medium, Animal.Diet.Herbivore));
            wagon.Contents.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));

            Animal animal = new Animal(Animal.Size.Large, Animal.Diet.Herbivore);


            Assert.IsTrue(wagon.TryToAddAnimal(animal, wagon));
        }

        [TestMethod]
        public void AddAnimalTest()
        {
            Wagon wagon = new Wagon();

            Animal animal = new Animal(Animal.Size.Large, Animal.Diet.Herbivore);

            wagon.AddAnimal(animal);

            bool animalInWagon = false;

            if (wagon.Contents.Contains(animal))
            {
                animalInWagon = true;
            }

            Assert.IsTrue(animalInWagon);
        }

        [TestMethod]
        public void WillEatEachotherTest()
        {
            Wagon wagon = new Wagon();

            Animal carnivore = new Animal(Animal.Size.Medium, Animal.Diet.Carnivore);
            wagon.Contents.Add(new Animal(Animal.Size.Small, Animal.Diet.Herbivore));

            bool result = carnivore.WillEatEachother(carnivore, wagon);

            Assert.IsTrue(result);
        }
    }
}
