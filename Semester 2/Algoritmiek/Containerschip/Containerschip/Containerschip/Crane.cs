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
                if (Ship.Weight < Ship.MinWeight)
                {
                    MessageBox.Show("Containers are too light.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (Ship.WeightDifference > 20)
                {
                    MessageBox.Show("Ship is capsizing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                StartVisualizer();
                return true;
            }
            else
            {
                MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DistributeContainers()
        {
            List<Container> AddedContainers = new List<Container>();
            List<Container> notSuitedContainers = new List<Container>();

            foreach (Container container in Containers)
            {
                if (AddContainer(container))
                {
                    AddedContainers.Add(container);
                }
                else
                {
                    notSuitedContainers.Add(container);
                }
            }
            Containers = AddedContainers;
            return true;
        }

        private bool AddContainer(Container container)
        {
            if (AddContainerToSide(container))
            {
                return true;
            }
            return AddContainerToCenter(container);
        }

        private bool AddContainerToSide(Container container)
        {
            foreach (Row row in Ship.Rows)
            {
                bool isLeftSideLighter = Ship.LeftWeight < Ship.RightWeight;
                if ((isLeftSideLighter && row.Side == Row.Sides.Left) ||
                    (!isLeftSideLighter && row.Side == Row.Sides.Right))
                {
                    if (row.TryAddingContainer(container))
                    {
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
                if (row.Side == Row.Sides.Centre)
                {
                    if (row.TryAddingContainer(container))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string StartVisualizer()
        {
            string fullStack = "";
            string fullWeight = "";

            foreach (Row row in Ship.Rows)
            {
                foreach (Stack stack in row.Stacks)
                {
                    foreach (Container container in stack.Containers)
                    {
                        fullStack += Convert.ToString((int)container.ContainerType);
                        fullWeight += Convert.ToString(container.Weight);
                        if (stack.Containers.Last() != container)
                        {
                            fullWeight += "-";
                        }
                    }
                    if (row.Stacks.Last() != stack)
                    {
                        fullStack += ",";
                        fullWeight += ",";
                    }
                }
                if (Ship.Rows.Last() != row)
                {
                    fullStack += "/";
                    fullWeight += "/";
                }
            }
            Process.Start($"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + fullStack + "&weights=" + fullWeight + "");
            return $"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Ship.Length + "&width=" + Ship.Width + "&stacks=" + fullStack + "&weights=" + fullWeight + "";
        }
    }
}