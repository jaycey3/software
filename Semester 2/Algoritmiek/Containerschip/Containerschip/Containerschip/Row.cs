using System.Collections.Generic;

namespace Containerschip
{
    public class Row
    {
        public List<Stack> Stacks { get; set; }
        public int Length { get; set; }
        public Sides Side { get; set; }

        public enum Sides
        {
            Left = 1,
            Center = 2,
            Right = 3,
        }

        public Row(int length, Sides side)
        {
            Length = length;
            Side = side;
            Stacks = new List<Stack>();

            // Maak stacks aan met een positie
            for (int i = 0; i < Length; i++)
            {
                Stacks.Add(new Stack(i));
            }
        }

        public bool TryToAddContainerToRow(Container container)
        {
            // Zoek de eerste stack waar de container aan toegevoegd kan worden
            for (int i = 0; i < Stacks.Count; i++)
            {
                // Probeer de container toe te voegen
                if (Stacks[i].TryToAddContainerToStack(container))
                {
                    // Als het een valuable container is, probeer een stack te reserveren
                    if (container.ContainerType == Container.ContainerTypes.Valueable || container.ContainerType == Container.ContainerTypes.CoolableAndValuable)
                    {
                        ReserveStackForValuableContainers(container, i);
                    }
                    return true;
                }
            }
            return false;
        }

        private void ReserveStackForValuableContainers(Container container, int stackPosition)
        {

            // Controleer of de stack niet aan de voor of achterkant zit en of de stack er voor of er achter niet gereserveerd is
            if (stackPosition > 0 && stackPosition + 1 < Stacks.Count && !Stacks[stackPosition - 1].Reserved && !Stacks[stackPosition + 1].Reserved)
            {
                Stacks[stackPosition + 1].Reserved = true;
            }

        }
    }
}