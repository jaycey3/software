namespace Containerschip
{
    public class Container
    {
        public int Weight { get; set; }
        private readonly int MaxWeight = 30;
        private readonly int MinWeight = 4;
        public ContainerTypes ContainerType { get; set; }

        public enum ContainerTypes
        {
            Normal = 1,
            Valueable = 2,
            Coolable = 3,
            CoolableAndValuable = 4
        }
        public Container(int weight, int containerType)
        {
            Weight = weight;
            ContainerType = (ContainerTypes)containerType;
        }
    }
}
