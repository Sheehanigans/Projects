using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    public class CapacityRestriction : IItemRestriction
    {
        public AddItemStatus CheckRule(Container addTo, Item toAdd)
        {
            AddItemStatus result = AddItemStatus.ContainerFull;

            if (addTo.Capacity > addTo.CurrentIndex)
            {
                result = AddItemStatus.Ok;
            }

            return result;
        }
    }
}
