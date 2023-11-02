using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class CollectableManager : MonoBehaviour
    {
        [SerializeField] private GameObject collectableSlot;
        [SerializeField] private List<CollectableSlot> collectableSlotLits;
        private int collectableSlotIndex = 0;

        public void OnEnable()
        {
            EventManager.StartListening("OnCollectItem", OnAddCollectableSlot);
        }

        public void OnDisable()
        {
            EventManager.StopListening("OnCollectItem", OnAddCollectableSlot);
        }

        private void OnAddCollectableSlot(Dictionary<string, object> message)
        {
            MoveCollectacleSlots();
            AddCollectableSlotInfo(message);
        }
        
        /// <summary>
        /// Move all enables collectables higher
        /// </summary>
        private void MoveCollectacleSlots()
        {
            foreach (CollectableSlot collectableSlot in collectableSlotLits)
            {
                if (collectableSlot.enabled)
                {   
                    collectableSlot.SetMovementPosition();
                    collectableSlot.hasToMove = true;
                }
            }
        }
        
        /// <summary>
        /// Set the current collectable slot info 
        /// </summary>
        /// <param name="message"></param>
        private void AddCollectableSlotInfo(Dictionary<string, object> message)
        {
            ItemData_SO itemData = message["itemData"] as ItemData_SO;

            CollectableSlot currentCollectableSlotComponent = collectableSlotLits[collectableSlotIndex];
            currentCollectableSlotComponent.SetInfo(itemData);

            currentCollectableSlotComponent.gameObject.SetActive(true);

            Animator newCollectableSlotAnimator = currentCollectableSlotComponent.gameObject.GetComponent<Animator>();
            newCollectableSlotAnimator.SetTrigger("activate");

            if (collectableSlotIndex < collectableSlotLits.Count - 1)
            {
                collectableSlotIndex++;
            }
            else
            {
                collectableSlotIndex = 0;
            }
        }
    }
}
