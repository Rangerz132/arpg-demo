using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] public List<InventoryItem> inventory = new List<InventoryItem>();
        public Dictionary<ItemData_SO, InventoryItem> itemDictionary = new Dictionary<ItemData_SO, InventoryItem>();

        public void OnEnable()
        {
            EventManager.StartListening("OnCollectItem", OnAddItem);
        }

        public void OnDisable()
        {
            EventManager.StopListening("OnCollectItem", OnAddItem);
        }

        void OnAddItem(Dictionary<string, object> message)
        {
            ItemData_SO itemData = message["itemData"] as ItemData_SO;
            int amount = itemData.amount;
            Add(itemData, amount);
        }

        /// <summary>
        /// Add new item(s) to the inventory
        /// </summary>
        /// <param name="itemData"></param>
        /// <param name="amount"></param>
        public void Add(ItemData_SO itemData, int amount)
        {
            if (itemDictionary.TryGetValue(itemData, out InventoryItem inventoryItem))
            {
                inventoryItem.AddStack(amount);
            }
            else
            {
                InventoryItem newInventoryItem = new InventoryItem(itemData);
                inventory.Add(newInventoryItem);
                itemDictionary.Add(itemData, newInventoryItem);
            }
        }

        /// <summary>
        /// Remove item(s) to the inventory
        /// </summary>
        /// <param name="itemData"></param>
        /// <param name="amount"></param>
        public void Remove(ItemData_SO itemData, int amount)
        {
            if (itemDictionary.TryGetValue(itemData, out InventoryItem inventoryItem))
            {
                inventoryItem.RemoveStack(amount);

                if (inventoryItem.StackAmount <= 0)
                {
                    inventory.Remove(inventoryItem);
                    itemDictionary.Remove(itemData);
                }
            }
        }
    }
}

