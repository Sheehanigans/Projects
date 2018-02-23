namespace TerribleRoommates.DLL.Containers
{
    public abstract class Container : Item //public so all can use it, abstract since there can be different types of containers and we don't want people to instantiate it. Ex: Backpack 
    {
        public int Capacity { get; set; }

        public Container(string name, int size, int capacity) 
            : base(name, size, ItemType.Container)
        {
            Capacity = capacity;
        }
    }
}
