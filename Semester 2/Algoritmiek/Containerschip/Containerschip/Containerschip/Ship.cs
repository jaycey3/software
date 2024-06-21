using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Ship
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int MaxWeight { get; set; }
        public int MinWeight { get; set; }
        public List<Row> Rows { get; private set; }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }
        public double WeightDifference { get { return ((LeftWeight / (double)Weight) * 100) - ((RightWeight / (double)Weight) * 100); } }
        public int Weight { get { return Rows.Sum(row => row.Stacks.Sum(stack => stack.Containers.Sum(container => container.Weight))); } }

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            MaxWeight = (length * width) * 150;
            MinWeight = MaxWeight / 2;
            Rows = new List<Row>();

            // Defineer de zijdes voor de rijen.
            for (int i = 0; i < Width; i++)
            {
                Row.Sides side;

                if (Width % 2 == 0)
                {
                    side = CalculateEvenRow(i);
                }
                else
                {
                    side = CalculateUnevenRow(i);
                }

                Rows.Add(new Row(Length, side));
            }
        }

        // Geef de rijen een zijde, links of rechts. als er 4 rijen zijn (0, 1, 2, 3) is 0 en 1 links, en 2 en 3 rechts
        private Row.Sides CalculateEvenRow(int i)
        {
            if (i < Width / 2)
            {
                return Row.Sides.Left;
            }
            else
            {
                return Row.Sides.Right;
            }
        }

        // Geef de rijen een zijde, links of rechts, en anders midden. Als er 5 rijen zijn (0, 1, 2, 3, 4) is 0 en 1 links, 2 midden, en 3 en 4 zijn rechts.
        private Row.Sides CalculateUnevenRow(int i)
        {
            if (i < Width / 2)
            {
                return Row.Sides.Left;
            }
            else if (i > Width / 2)
            {
                return Row.Sides.Right;
            }
            else
            {
                return Row.Sides.Center;
            }
        }
    }
}