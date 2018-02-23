using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
	public class ItemTypeRestriction : IItemRestriction
	{
		public ItemType RestrictionType { get; }

		public ItemTypeRestriction(ItemType restrictTo)
		{
			RestrictionType = restrictTo;
		}

		public AddItemStatus CheckRule(Container addTo, Item toAdd)
		{
			AddItemStatus result = AddItemStatus.ItemWrongType;
			if (toAdd.Type == RestrictionType)
			{
				result = AddItemStatus.Ok;
			}
			return result;
		}
	}
}
