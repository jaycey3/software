using System.Collections.Generic;

namespace Containerschip
{
    public class Stack
    {
        public int Posistion { get; set; }
        public List<Container> Containers { get; set; }

        public Stack(int posistion)
        {
            Posistion = posistion;
            List<Container> containers = new List<Container>();
            Containers = containers;
        }

        public void AddContainerToStack(Container container)
        {
            Containers.Add(container);
        }
    }
}
