using System.Collections.Generic;

namespace Containerschip
{
    public class Row
    {
        public int Position { get; set; }
        public List<Stack> Stacks { get; set; }

        public Row(int position, int rowWidth)
        {
            Position = position;
            List<Stack> stacks = new List<Stack>();
            for (int i =0; i < rowWidth; i++)
            {
                Stack stack = new Stack(i);
                stacks.Add(stack);
            }
            Stacks = stacks;
        }
    }
}
