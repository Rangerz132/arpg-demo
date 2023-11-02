using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace rpgStealth
{
    public class InventorySlot : MonoBehaviour, IPointerDownHandler
    {
        public Image icon;
        public TextMeshProUGUI stackAmountText;
        public Image selectedImage;
        public ItemData_SO itemData;
        public InventoryGUI inventoryGUI;
        public bool isSelected = false;

        /// <summary>
        /// Enable the slot and update its data
        /// </summary>
        /// <param name="inventoryItem"></param>
        public void DrawSlot(InventoryItem inventoryItem)
        {
            itemData = inventoryItem.itemData;
            icon.enabled = true;
            stackAmountText.enabled = true;

            icon.sprite = itemData.icon;
            stackAmountText.text = inventoryItem.StackAmount.ToString();
        }

        /// <summary>
        /// Disable the Inventory Slot
        /// </summary>
        public void ClearSlot()
        {
            icon.enabled = false;
            stackAmountText.enabled = false;
        }

        /// <summary>
        /// Show selected image to visualize the current slot
        /// </summary>
        public void ShowSelectSlot()
        {
            Color color = selectedImage.color;
            color.a = 0.3f;
            selectedImage.color = color;
        }

        /// <summary>
        /// Hide the selected image
        /// </summary>
        public void HideSelectSlot() 
        {
            Color color = selectedImage.color;
            color.a = 0;
            selectedImage.color = color;
        }

        /// <summary>
        /// Check if the inventory slot contains data
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() 
        {
            return itemData == null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsEmpty() && !isSelected) 
            {
                inventoryGUI.SetCurrentInventorySlot(this);
            }         
        }
    }
}

