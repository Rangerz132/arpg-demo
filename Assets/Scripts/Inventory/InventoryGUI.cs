using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class InventoryGUI : MainMenuTab
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private GameObject inventorySlot;
        [SerializeField] private Transform itemsPanel;
        public List<InventorySlot> inventorySlots = new List<InventorySlot>();
        public ItemType CurrentItemType { get; private set; }
        [SerializeField] private int inventorySlotsPerPage;
        private int inventorySlotSorted = 0;
        private InventorySlot currentInventorySlot;
        private InventorySlot previousInventorySlot;
        [SerializeField] private InventoryItemInfo inventoryItemInfo;

        private void Awake()
        {
            CreateInventorySlots();
        }

        private void OnEnable()
        {
            DrawInventorySlots();
        }

        /// <summary>
        /// Create list of Inventory Slots
        /// </summary>
        private void CreateInventorySlots()
        {
            for (var i = 0; i < inventorySlotsPerPage; i++)
            {
                CreateInventorySlot();
            }
        }

        /// <summary>
        /// Create single Inventory Slot
        /// </summary>
        public void CreateInventorySlot()
        {
            GameObject newInventoryItemSlotSlot = Instantiate(inventorySlot);
            newInventoryItemSlotSlot.transform.SetParent(itemsPanel);
            newInventoryItemSlotSlot.transform.localScale = new Vector3(1, 1, 1);

            InventorySlot newInventoryItemSlotComponent = newInventoryItemSlotSlot.GetComponent<InventorySlot>();
            newInventoryItemSlotComponent.inventoryGUI = this;
            newInventoryItemSlotComponent.ClearSlot();

            inventorySlots.Add(newInventoryItemSlotComponent);
        }

        /// <summary>
        /// Update inventory slots data
        /// </summary>
        private void DrawInventorySlots()
        {
            ResetCurrentInventorySlot();

            inventorySlotSorted = 0;

            for (var i = 0; i < inventoryManager.inventory.Count; i++)
            {
                if (inventoryManager.inventory[i].itemData.itemType.type.Equals(CurrentItemType))
                {
                    inventorySlots[inventorySlotSorted].DrawSlot(inventoryManager.inventory[i]);

                    inventorySlotSorted++;
                }
            }

            ResortInventorySlots();
        }


        /// <summary>
        /// Remove any item in the inventoryGUI which exceed the inventory item amount
        /// </summary>
        public void ResortInventorySlots()
        {
            for (var i = 0; i < inventorySlots.Count; i++)
            {
                if (i >= inventorySlotSorted)
                {
                    inventorySlots[i].ClearSlot();
                }
            }
        }

        /// <summary>
        /// Remove every items in the inventory
        /// </summary>
        public void ClearInventorySlots()
        {
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                inventorySlot.ClearSlot();
            }
        }

        /// <summary>
        /// Change inventory item tab
        /// </summary>
        /// <param name="itemType"></param>
        public void ChangeTab(ItemType itemType)
        {
            ChangeItemType(itemType);
            ClearInventorySlots();
            DrawInventorySlots();
        }

        /// <summary>
        /// Change item type
        /// </summary>
        /// <param name="itemType"></param>
        public void ChangeItemType(ItemType itemType)
        {
            CurrentItemType = itemType;
        }

        /// <summary>
        /// Showcase the selected inventory slot
        /// </summary>
        /// <param name="targetInventorySlot"></param>
        public void SetCurrentInventorySlot(InventorySlot targetInventorySlot)
        {
            currentInventorySlot = targetInventorySlot;
            currentInventorySlot.ShowSelectSlot();
            currentInventorySlot.isSelected = true;
            inventoryItemInfo.SetInfo(targetInventorySlot);

            if (previousInventorySlot != null)
            {
                previousInventorySlot.HideSelectSlot();
                previousInventorySlot.isSelected = false;
            }

            previousInventorySlot = currentInventorySlot;
        }

        /// <summary>
        /// Reset current inventory slot to null
        /// </summary>
        private void ResetCurrentInventorySlot()
        {
            if (previousInventorySlot != null)
            {
                previousInventorySlot.HideSelectSlot();
                previousInventorySlot.isSelected = false;
            }

            if (currentInventorySlot != null)
            {
                currentInventorySlot.HideSelectSlot();
                currentInventorySlot.isSelected = false;
            }

            previousInventorySlot = null;
            currentInventorySlot = null;

            inventoryItemInfo.ClearInfo();
        }
    }
}
