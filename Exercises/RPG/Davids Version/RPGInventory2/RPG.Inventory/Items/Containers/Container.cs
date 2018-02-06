using RPG.Inventory.Items.Containers.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public abstract class Container : Item
    {
        public int Capacity { get; private set; }
        public Item[] Items { get; private set; }
        public int CurrentIndex { get; private set; }

		List<IItemRestriction> _containerRestrictions = new List<IItemRestriction>();

        public Container(int capacity)
        {
            Capacity = capacity;
            Items = new Item[Capacity];
            CurrentIndex = 0;

            AddRestriction(new CapacityRestriction());
        }

		public void AddRestriction(IItemRestriction toAdd)
		{
			_containerRestrictions.Add(toAdd);
		}

        public virtual AddItemStatus AddItem(Item itemToAdd)
        {
			foreach (var restriction in _containerRestrictions)
			{
				var result = restriction.CheckRule(this, itemToAdd);
				if (result != AddItemStatus.Ok)
				{
					return result;
				}
			}

            Items[CurrentIndex] = itemToAdd;
            CurrentIndex++;
            return AddItemStatus.Ok;
        }

        public virtual Item RemoveItem()
        {
            if (CurrentIndex == 0)
                return null;
            else
            {
                CurrentIndex--;
                Item itemToReturn = Items[CurrentIndex];
                Items[CurrentIndex] = null;
                return itemToReturn;
            }
        }
    }
}
