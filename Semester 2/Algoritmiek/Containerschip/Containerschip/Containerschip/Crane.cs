using System.Collections.Generic;
using System.Linq;

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

        public void DistributeContainers()
        {
            foreach (Container container in Containers)
            {
                foreach (Row row in Ship.Rows)
                {
                    foreach (Stack stack in row.Stacks)
                    {
                        if (stack.Containers.Count == 0)
                        {
                            stack.AddContainerToStack(container);
                            break;
                        }
                        if (stack.Containers.Last().Weight + container.Weight <= 120)
                        {
                            stack.AddContainerToStack(container);
                            break;
                        }
                    }
                }
            }
    }
}