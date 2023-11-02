using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class InventoryItem
    {
        public ItemData_SO itemData;
        public int StackAmount { get; private set; }

        public InventoryItem(ItemData_SO itemData)
        {
            this.itemData = itemData;
            AddStack(1);
        }

        public void AddStack(int amount)
        {
            StackAmount += amount;
        }

        public void RemoveStack(int amount)
        {
            StackAmount -= amount;
        }
    }
}


