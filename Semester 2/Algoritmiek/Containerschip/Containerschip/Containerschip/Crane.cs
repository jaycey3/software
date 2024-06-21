using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Containerschip
{
    public class Crane
    {
        public Ship Ship { get; set; }
        public List<Container> Containers { get; set; } = new List<Container>();

        public Crane(int shipWidth, int shipLength)
        {
            Ship = new Ship(shipWidth, shipLength);
        }

        private void SortContainers()
        {
            Containers = Containers
                .OrderByDescending(c => c.ContainerType)
                .ThenBy(c => c.Weight)
                .ToList();
        }

        public bool Run()
        {
            SortContainers();
            DistributeContainers();

            // Controleer of het verschil in gewicht voor de linker en rechter kant van het schip niet meer dan 20% verschilt
            if (Ship.WeightDifference > 20)
            {
                MessageBox.Show("Ship is capsizing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Controleer of meer dan de helft van het maximaal gewicht gebruikt wordt
            if (Ship.Weight < Ship.MinWeight)
            {
                MessageBox.Show("Containers are too light.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            StartVisualizer();
            return true;
        }

        private void DistributeContainers()
        {
            List<Container> AddedContainers = new List<Container>();
            List<Container> notSuitedContainers = new List<Container>();

            foreach (Container container in Containers)
            {
                // Kijk voor elke container of je hem toe kan voegen
                if (AddContainer(container))
                {
                    AddedContainers.Add(container);
                }
                else
                {
                    notSuitedContainers.Add(container);
                }
            }

            // Als er een lijst is met containers die niet passen, probeer ze nog een keer te plaatsen
            if (notSuitedContainers != null)
            {
                for (int i = notSuitedContainers.Count - 1; i >= 0; i--)
                {
                    Container container = notSuitedContainers[i];
                    if (AddContainer(container))
                    {
                        AddedContainers.Add(container);
                        notSuitedContainers.RemoveAt(i);
                    }
                }

                // Als er nog steeds containers zijn die niet passen, log dan naar de console welke containers niet op het schip passen
                Console.WriteLine("Not suited containers:");
                if (notSuitedContainers.Count > 0)
                {
                    foreach (Container container in notSuitedContainers)
                    {
                        Console.WriteLine(container.ContainerType.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("None.");
                }
            }

            Containers = AddedContainers;
        }

        private bool AddContainer(Container container)
        {
            // Probeer eerst de container in het midden te plaatsen, en als dat niet lukt probeer hem aan de zijkant te plaatsen
            if (AddContainerToCenter(container))
            {
                return true;
            }
            return AddContainerToSide(container);
        }

        private bool AddContainerToSide(Container container)
        {
            foreach (Row row in Ship.Rows)
            {
                // Als de linker kant lichter is dan de rechter kant en de rij is links, of de linker kant is niet lichter en de rij is rechts, probeer de container te plaatsen
                bool isLeftSideLighter = Ship.LeftWeight < Ship.RightWeight;
                if ((isLeftSideLighter && row.Side == Row.Sides.Left) ||
                    (!isLeftSideLighter && row.Side == Row.Sides.Right))
                {
                    if (row.TryToAddContainerToRow(container))
                    {
                        // Als de container links is geplaats, tel het gewicht van de container op bij het linker gewicht, anders bij het rechter gewicht
                        if (isLeftSideLighter)
                        {
                            Ship.LeftWeight += container.Weight;
                        }
                        else
                        {
                            Ship.RightWeight += container.Weight;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private bool AddContainerToCenter(Container container)
        {
            foreach (Row row in Ship.Rows)
            {
                // Wanneer een rij in het midden is gevonden, probeer de container toe te voegen
                if (row.Side == Row.Sides.Center)
                {
                    // Probeer de container toe te voegen aan de middelste rij
                    if (row.TryToAddContainerToRow(container))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string StartVisualizer()
        {
            // Maak een string aan voor de stacks en voor de weights
            string stacks = "";
            string weights = "";

            foreach (Row row in Ship.Rows)
            {
                foreach (Stack stack in row.Stacks)
                {
                    foreach (Container container in stack.Containers)
                    {
                        // Voeg elke container type en gewicht toe aan de strings
                        stacks += Convert.ToString((int)container.ContainerType);
                        weights += Convert.ToString(container.Weight);
                        // Voeg een - toe achter de laatste container van de stack
                        if (stack.Containers.Last() != container)
                        {
                            weights += "-";
                        }
                    }
                    // Voeg een , toe achter de laatste srack in de rij
                    if (row.Stacks.Last() != stack)
                    {
                        stacks += ",";
                        weights += ",";
                    }
                }
                // Voeg een / toe achter de laatste rij van het schip
                if (Ship.Rows.Last() != row)
                {
                    stacks += "/";
                    weights += "/";
                }
            }
            // Open de visualizer link
            Process.Start($"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + stacks + "&weights=" + weights + "");
            return $"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + stacks + "&weights=" + weights + "";
        }
    }
}