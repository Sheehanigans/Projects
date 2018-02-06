using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    public class AlwaysRestrict : IItemRestriction
    {
        public AddItemStatus CheckRule(Container addTo, Item toAdd)
        {
            return AddItemStatus.ContainerFull;
        }
    }
}
