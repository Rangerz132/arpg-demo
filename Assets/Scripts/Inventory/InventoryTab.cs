using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class InventoryTab : MonoBehaviour
    {
        [SerializeField] private InventoryGUI inventoryGUI;
        [SerializeField] private List<InventoryTabButton> inventoryTabButtons = new List<InventoryTabButton>();

        private void Start()
        {
            SetInventoryTabAlpha();
        }

        public void SetInventoryTabAlpha()
        {
            foreach (InventoryTabButton inventoryTabButton in inventoryTabButtons)
            {
                Color inventoryTabButtonColor = inventoryTabButton.buttonIcon.color;
                inventoryTabButtonColor.a = inventoryTabButton.itemType.type == inventoryGUI.CurrentItemType ? 1 : 0.2f;
                inventoryTabButton.buttonIcon.color = inventoryTabButtonColor;
            }
        }
    }
}
