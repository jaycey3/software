using System.Collections.Generic;

namespace Containerschip
{
    public class Stack
    {
        public int Posistion { get; set; }
        public int TotalWeight { get; set; }
        public int MaxWeight { get; set; }
        public List<Container> Containers { get; set; }

        public Stack(int posistion)
        {
            Posistion = posistion;
            List<Container> containers = new List<Container>();
            Containers = containers;
            MaxWeight = 150;
        }

        public bool CanAddContainer(Container container)
        {

        }

        public void AddContainerToStack(Container container)
        {
            Containers.Add(container);
        }
    }
}
