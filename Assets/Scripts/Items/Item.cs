using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace rpgStealth
{
    public class Item : MonoBehaviour, ICollectable
    {
        public ItemData_SO itemData;
        [SerializeField] private Collider itemCollider;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private bool available;
        [SerializeField] private GameObject canvasContainer;

        private void Start()
        {
            text.text = itemData.itemName;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out Player player))
            {
                canvasContainer.SetActive(true);
                available = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.transform.TryGetComponent(out Player player))
            {
                canvasContainer.SetActive(false);
                available = false;
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (available)
                {
                    Collect();
                    gameObject.SetActive(false);
                }
            }
        }

        void Collect()
        {
            EventManager.TriggerEvent("OnCollectItem", new Dictionary<string, object> { { "itemData", itemData } });
        }
    }

}
