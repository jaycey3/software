﻿using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Stack
    {
        public int Position { get; set; }
        public bool IsFront { get; private set; }
        public bool IsBack { get; private set; }
        public bool Reserved { get; set; }
        public List<Container> Containers { get; set; }
        private readonly int BaseMaxWeight = 120;
        public int MaxWeight
        {
            get
            {
                if (Containers.Count > 0)
                {
                    return BaseMaxWeight + Containers[0].Weight;
                }
                return BaseMaxWeight;
            }
        }

        public int ContainersWeight
        {
            get
            {
                int totalWeight = 0;
                foreach (Container container in Containers)
                {
                    totalWeight += container.Weight;
                }
                return totalWeight;
            }
        }

        public Stack(int position, bool isfront, bool isBack)
        {
            Position = position;
            IsFront = isfront;
            IsBack = isBack;
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