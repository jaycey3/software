using System;

namespace Containerschip
{
    public class Container
    {
        public int Weight { get; set; }
        private readonly int MaxWeight = 30;
        private readonly int MinWeight = 4;
        public ContainerTypes ContainerType { get; set; }
        public UnfitReasons UnfitReason { get; set; }

        public enum ContainerTypes
        {
            Normal = 1,
            Valueable = 2,
            Coolable = 3,
            CoolableAndValuable = 4
        }

        public enum UnfitReasons
        {
            ExceedsMaxWeight = 1,
            Reserved = 2,
            TooManyValuables = 3,
            TooManyCoolableValuables = 4,
            TooManyCoolables = 5
        }

        public Container(int weight, int containerType)
        {
            Weight = weight;
            ContainerType = (ContainerTypes)containerType;
        }

        private int SetWeight(int weight)
        {
            if (weight < MinWeight)
            {
                throw new Exception("Weight mininum is 4 tons");
            }
            else if (weight > MaxWeight)
            {
                throw new Exception("Weight maximun is 30 tons");
            }

            return weight;
        }
    }
}
