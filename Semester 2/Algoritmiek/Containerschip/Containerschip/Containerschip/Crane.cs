using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Containerschip
{
    public class Crane
    {
        public Ship Ship { get; set; }
        public List<Container> Containers { get; set; } = new List<Container>();
        public List<Container> ExcessContainers { get; set; } = new List<Container>();

        public Crane(int shipWidth, int shipLength)
        {
            Ship = new Ship(shipWidth, shipLength);
            SortContainers();
        }

        public void SortContainers()
        {
            Containers = Containers
                .OrderByDescending(c => c.ContainerType)
                .ThenBy(c => c.Weight)
                .ToList();
        }

        public bool Run()
        {
            if (DistributeContainers())
            {
                if (Ship.TotalWeight < Ship.MinWeight)
                {
                    Console.WriteLine("Containers are too light.");
                }

                if (Ship.WeightDifferencePercentage > 20)
                {
                    Console.WriteLine("Ship is capsizing.");
                }

                StartVisualizer();

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DistributeContainers()
        {
            List<Container> containersToRemove = new List<Container>();

            foreach (Container container in Containers)
            {
                if (!AddContainerLeftOrRight(container))
                {
                    if (!AddContainerCenter(container).Item1)
                    {
                        ExcessContainers.Add(AddContainerCenter(container).Item2);
                        containersToRemove.Add(container);
                    }
                }
            }

            foreach (Container container in containersToRemove)
            {
                Containers.Remove(container);
            }

            return true;
        }


        private bool AddContainerLeftOrRight(Container container)
        {
            foreach (Row row in Ship.Rows)
            {
                if ((Ship.LeftWeight < Ship.RightWeight && row.Side == Row.Sides.Left) || (Ship.LeftWeight >= Ship.RightWeight && row.Side == Row.Sides.Right))
                {
                    if (row.TryAddingContainer(container))
                    {
                        if (Ship.LeftWeight < Ship.RightWeight)
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

        private (bool, Container) AddContainerCenter(Container container)
        {
            foreach (Row row in Ship.Rows)
            {
                if (row.Side == Row.Sides.Centre)
                {
                    if (row.TryAddingContainer(container))
                    {
                        return (true, container);
                    }
                }
            }
            return (false, container);
        }

        private string StartVisualizer()
        {
            string fullStack = "";
            string fullWeight = "";
            for (int z = 0; z < Ship.Rows.Count; z++)
            {
                if (z > 0)
                {
                    fullStack += '/';
                    fullWeight += '/';
                }

                for (int x = 0; x < Ship.Rows[z].Stacks.Count; x++)
                {
                    if (x > 0)
                    {
                        fullStack += ",";
                        fullWeight += ",";
                    }

                    if (Ship.Rows[z].Stacks[x].Containers.Count > 0)
                    {
                        for (int y = 0; y < Ship.Rows[z].Stacks[x].Containers.Count; y++)
                        {
                            Container container = Ship.Rows[z].Stacks[x].Containers[y];

                            fullStack += Convert.ToString((int)container.ContainerType);
                            fullWeight += Convert.ToString(container.Weight);
                            if (y < (Ship.Rows[z].Stacks[x].Containers.Count - 1))
                            {
                                fullWeight += "-";
                            }
                        }
                    }
                }
            }

            Process.Start($"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + fullStack + "&weights=" + fullWeight + "");
            return $"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + fullStack + "&weights=" + fullWeight + "";
        }
    }
}