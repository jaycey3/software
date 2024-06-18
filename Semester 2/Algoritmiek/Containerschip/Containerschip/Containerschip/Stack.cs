using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Stack
    {
        public int Posistion { get; set; }
        public List<Container> Containers { get; set; }
        public int MaxWeight = 150;
        public int Weight { get; set; }

        public Stack(int posistion)
        {
            Posistion = posistion;
            List<Container> containers = new List<Container>();
            Containers = containers;
            Weight = 0;
        }

        public void AddContainerToStack(Container container)
        {
            Containers.Add(container);
            Weight = Containers.Sum(c => c.Weight);
        }

        public bool CanAddContainerToStack(Container container)
        {
            Container lastContainer = Containers.LastOrDefault();
            if (lastContainer != null &&
                 (lastContainer.ContainerType == Container.ContainerTypes.Valueable ||
                  lastContainer.ContainerType == Container.ContainerTypes.CoolableAndValuable))
            {
                return false;
            }
            else if (Weight + container.Weight > MaxWeight)
            {
                return false;
            } else
            {
                return true;
            }
        }

    }
}