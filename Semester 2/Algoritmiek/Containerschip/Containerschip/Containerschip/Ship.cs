using System;
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
        public List<Row> Rows { get; set; }

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            MaxWeight = (length * width) * 150;
            MinWeight = MaxWeight / 2;
            List<Row> rows = new List<Row>();
            
            for (int i = 0; i < length; i++)
            {
                Row row = new Row(i, width);
                rows.Add(row);
            }

            Rows = rows;
        }

        public void LoadContainer(Container container)
        {
            Row row = null;

            if (container.ContainerType == Container.ContainerTypes.CoolableAndValuable ||
                container.ContainerType == Container.ContainerTypes.Coolable)
            {
                row = Rows.First();
            }
            else
            {
                row = Rows.FirstOrDefault(r => r.CanAddContainerToAnyStack(container));
            }

            if (row != null)
            {
                row.AddContainerToFirstAvailableStack(container);
            }
            else
            {
                Console.WriteLine("Er is geen ruimte beschikbaar om de container te plaatsen.");
            }
        }

    }
}
