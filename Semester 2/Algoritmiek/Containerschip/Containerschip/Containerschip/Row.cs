using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Row
    {
        public int Position { get; set; }
        public List<Stack> Stacks { get; set; }

        public Row(int position, int rowWidth)
        {
            Position = position;
            Stacks = new List<Stack>();
            for (int i =0; i < rowWidth; i++)
            {
                Stacks.Add(new Stack(i));
            }
        }

        public bool CanAddContainerToAnyStack(Container container)
        {
            return Stacks.Any(stack => stack.CanAddContainerToStack(container));
        }

        public void AddContainerToFirstAvailableStack(Container container)
        {
            foreach (var stack in Stacks)
            {
                if (stack.CanAddContainerToStack(container))
                {
                    stack.AddContainerToStack(container);
                    return;
                }
            }
        }
    }
}
