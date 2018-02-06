using RPG.Inventory.Items.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items
{
	public interface IItemRestriction
	{
		AddItemStatus CheckRule(Container addTo, Item toAdd);
	}
}
