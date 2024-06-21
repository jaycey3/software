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
            Centre = 2,
            Right = 3,
        }

        public Row(int length, Sides side)
        {
            Length = length;
            Side = side;
            Stacks = new List<Stack>();

            for (int i = 0; i < Length; i++)
            {
                if (i == 0)
                {
                    Stacks.Add(new Stack(i));
                }
                else if ((i + 1) == Length)
                {
                    Stacks.Add(new Stack(i));
                }
                else
                {
                    Stacks.Add(new Stack(i));
                }
            }
        }

        public bool TryToAddContainerToRow(Container container)
        {
            for (int i = 0; i < Stacks.Count; i++)
            {
                if (Stacks[i].TryToAddContainerToStack(container))
                {
                    ReserveStackForValuableContainers(container, i);
                    return true;
                }
            }
            return false;
        }

        private void ReserveStackForValuableContainers(Container container, int stackPosition)
        {
            if (container.ContainerType == Container.ContainerTypes.Valueable || container.ContainerType == Container.ContainerTypes.CoolableAndValuable)
            {
                // Controleer of de stack niet aan de voor of achterkant zit en of de stack er voor of er achter niet gereserveerd is
                if (stackPosition > 0 && stackPosition + 1 < Stacks.Count  && !Stacks[stackPosition - 1].Reserved && !Stacks[stackPosition + 1].Reserved)
                {
                    Stacks[stackPosition + 1].Reserved = true;
                }
            }
        }
    }
}