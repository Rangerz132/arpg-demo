using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace rpgStealth
{
    public class InventoryTabButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private InventoryTab inventoryTab;
        [SerializeField] private InventoryGUI inventoryGUI;
        public ItemType_SO itemType;
        public Image buttonIcon;

        private void Start()
        {
            buttonIcon.sprite = itemType.icon;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            inventoryGUI.ChangeTab(itemType.type);
            inventoryTab.SetInventoryTabAlpha();
        }
    }
}
