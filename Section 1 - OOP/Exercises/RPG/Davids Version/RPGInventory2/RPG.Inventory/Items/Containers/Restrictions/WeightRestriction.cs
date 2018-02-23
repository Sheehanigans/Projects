using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    public class WeightRestriction : IItemRestriction
    {
        public int MaxWeight { get; }

        public WeightRestriction (int maxWeight)
        {
            MaxWeight = maxWeight;
        }

        public AddItemStatus CheckRule(Container addTo, Item toAdd)
        {
            var items = addTo.Items.Where(w => w != null);
            int currentWeight = 0;

            if (items.Any())
            {
                currentWeight = items.Sum(s => s.Weight);
            }

            var proposedWeight = currentWeight + toAdd.Weight;

            AddItemStatus result = AddItemStatus.ContainerOverweight;

            if(proposedWeight <= MaxWeight)
            {
                result = AddItemStatus.Ok;
            }

            return result;
        }
    }
}
