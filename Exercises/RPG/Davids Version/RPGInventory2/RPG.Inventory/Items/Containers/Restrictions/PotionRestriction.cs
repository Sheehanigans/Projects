using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
	public class PotionRestriction : ItemTypeRestriction
	{
		public PotionRestriction() : base(ItemType.Potion)
		{
		}
	}
}
