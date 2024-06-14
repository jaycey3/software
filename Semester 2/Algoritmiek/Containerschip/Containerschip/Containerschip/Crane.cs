using System;
using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Crane
    {
        public Ship Ship { get; set; }
        public List<Container> Containers { get; set; } = new List<Container>();

        public Crane(int shipWidth, int shipLength)
        {
            Ship = new Ship(shipWidth, shipLength);
            SortContainers();
        }

        public void SortContainers()
        {
            Containers = Containers
                .OrderByDescending(c => c.ContainerType)
                .ThenBy(c => c.Weight)
                .ToList();
        }
    }
}