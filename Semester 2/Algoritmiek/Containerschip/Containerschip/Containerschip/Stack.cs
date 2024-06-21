using System.Collections.Generic;
using System.Linq;

namespace Containerschip
{
    public class Stack
    {
        private readonly int MaxWeightOnContainer = 120;
        public int Position { get; set; }
        public bool Reserved { get; set; }
        public List<Container> Containers { get; set; }
        public int MaxWeight { get { return MaxWeightOnContainer + (Containers.Count > 0 ? Containers[0].Weight : 0); } }
        public int ContainersWeight { get { return Containers.Sum(container => container.Weight); } }

        public Stack(int position)
        {
            Position = position;
            Containers = new List<Container>();
        }

        public bool TryToAddContainerToStack(Container container)
        {
            // Als de stack reserved is, of de stack niet vooraan staat voor een gekoelde container, kan het niet
            if (Reserved ||
                container.ContainerType == Container.ContainerTypes.Coolable && Position > 0 ||
                container.ContainerType == Container.ContainerTypes.CoolableAndValuable && Position > 0)
            {
                return false;
            }

            // Als de container er niet voor zorgt dat het te zwaar wordt, probeer de container toe te voegen
            if (ContainersWeight + container.Weight <= MaxWeight)
            {
                // Als de container valuable is, probeer bovenop te plaatsen, anders kan de container ook onder andere containers geplaatst worden
                if (container.ContainerType == Container.ContainerTypes.Valueable || 
                    container.ContainerType == Container.ContainerTypes.CoolableAndValuable)
                {
                    // Als de stack leeg is, of de bovenste container geen valuable container is, plaats de container bovenop de stack
                    if (Containers.Count == 0 ||
                        Containers.LastOrDefault().ContainerType != Container.ContainerTypes.Valueable &&
                        Containers.LastOrDefault().ContainerType != Container.ContainerTypes.CoolableAndValuable)
                    {
                        Containers.Add(container);
                    }
                    else
                    {
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
                return false;
            }
        }
    }
}