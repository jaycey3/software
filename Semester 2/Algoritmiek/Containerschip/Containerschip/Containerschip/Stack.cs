using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Stack
    {
        private readonly int MaxWeightOnContainer = 120;
        public int Position { get; set; }
        public bool Front { get; private set; }
        public bool Back { get; private set; }
        public bool Reserved { get; set; }
        public List<Container> Containers { get; set; }
        public int MaxWeight { get { return MaxWeightOnContainer + (Containers.Count > 0 ? Containers[0].Weight : 0); } }
        public int ContainersWeight { get { return Containers.Sum(container => container.Weight); } }

        public Stack(int position, bool front, bool back)
        {
            Position = position;
            Front = front;
            Back = back;
            Containers = new List<Container>();
        }

        public bool TryAddingContainer(Container container)
        {
            if (Reserved)
            {
                container.UnfitReason = Container.UnfitReasons.Reserved;
                return false;
            }
            else if (container.ContainerType == Container.ContainerTypes.Coolable && Position > 0)
            {
                container.UnfitReason = Container.UnfitReasons.TooManyCoolables;
                return false;
            }
            else if (container.ContainerType == Container.ContainerTypes.CoolableAndValuable && Position > 0)
            {
                container.UnfitReason = Container.UnfitReasons.TooManyCoolableValuables;
                return false;
            }

            if (ContainersWeight + container.Weight <= MaxWeight)
            {
                if (container.ContainerType == Container.ContainerTypes.Valueable || container.ContainerType == Container.ContainerTypes.CoolableAndValuable)
                {
                    if (Containers.Count == 0 ||
                        Containers.LastOrDefault().ContainerType != Container.ContainerTypes.Valueable &&
                        Containers.LastOrDefault().ContainerType != Container.ContainerTypes.CoolableAndValuable)
                    {
                        Containers.Add(container);
                    }
                    else
                    {
                        container.UnfitReason = Container.UnfitReasons.TooManyValuables;
                        return false;
                    }
                }
                else
                {
                    Containers.Insert(0, container);
                }
                return true;
            }
            else
            {
                container.UnfitReason = Container.UnfitReasons.ExceedsMaxWeight;
                return false;
            }
        }
    }
}