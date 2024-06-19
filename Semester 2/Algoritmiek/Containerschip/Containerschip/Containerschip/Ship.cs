using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Containerschip
{
    public class Ship
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int MaxWeight { get; set; }
        public int MinWeight { get; set; }
        public int Weight { get; set; }
        private List<Row> RowsList;
        public List<Row> Rows { get { return InitializeRows(); } }
        public int LeftWeight { get; set; }
        public int RightWeight { get; set; }
        public List<Container> Containers { get; set; }

        public double WeightDifferencePercentage
        {
            get
            {
                return ((LeftWeight / TotalWeight) * 100) - ((RightWeight / TotalWeight) * 100);
            }
        }

        public int TotalWeight
        {
            get
            {
                int totalWeight = 0;
                foreach (Row row in Rows) {
                    foreach (Stack stack in row.Stacks)
                    {
                        foreach (Container container in stack.Containers)
                        {
                            totalWeight += container.Weight;
                        }
                    }
                }
                return totalWeight;
            }
        }

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            MaxWeight = (length * width) * 150;
            MinWeight = MaxWeight / 2;
        }
        private Row.Sides CalculateEvenRows(int i)
        {
            Row.Sides side;
            if (i < Width / 2)
            {
                side = Row.Sides.Left;
            }
            else
            {
                side = Row.Sides.Right;
            }

            return side;
        }

        private Row.Sides CalculateUnevenRows(int i)
        {
            Row.Sides side;

            if (i < Width / 2)
            {
                side = Row.Sides.Left;
            }
            else if (i > Width / 2)
            {
                side = Row.Sides.Right;
            }
            else
            {
                side = Row.Sides.Centre;
            }

            return side;
        }

        public List<Row> InitializeRows()
        {
            if (RowsList == null)
            {
                RowsList = new List<Row>();

                for (int i = 0; i < Width; i++)
                {
                    Row.Sides side;

                    if (Width % 2 == 0)
                    {
                        side = CalculateEvenRows(i);
                    }
                    else
                    {
                        side = CalculateUnevenRows(i);
                    }

                    Rows.Add(new Row(Length, side));
                }
            }

            return Rows;
        }
    }
}
