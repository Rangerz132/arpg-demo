using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rpgStealth 
{
    public class InventoryItemInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemDescription;

        /// <summary>
        /// Set item info data
        /// </summary>
        /// <param name="inventorySlot"></param>
        public void SetInfo(InventorySlot inventorySlot)
        {
            itemName.text = inventorySlot.itemData.itemName;
            itemDescription.text = inventorySlot.itemData.description;
        }

        /// <summary>
        /// Clear item info 
        /// </summary>
        public void ClearInfo()
        {
            itemName.text = "";
            itemDescription.text = "";
        }
    }
}

