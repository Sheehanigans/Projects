namespace TerribleRoommates.DLL
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Size { get; set; } //= int.MinValue; can bee added to set it too
        public ItemType TypeOfItem { get; set; }

        public Item(string name, int size, ItemType typeOfItem)
        {
            Name = name;
            Size = size;
            TypeOfItem = typeOfItem;
        }
    }
}
