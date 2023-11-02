using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class AbilityManagerPanel : MonoBehaviour
    {
        [SerializeField] private List<AbilitySlot> abilitySlotList;

        private void OnEnable()
        {
            EventManager.StartListening("OnAbilitiesInitialized", OnAbilitiesInitialized);
            EventManager.StartListening("OnTriggerAbility", OnTriggerAbility);
        }
        private void OnDisable()
        {
            EventManager.StopListening("OnAbilitiesInitialized", OnAbilitiesInitialized);
            EventManager.StopListening("OnTriggerAbility", OnTriggerAbility);
        }

        /// <summary>
        /// Initialize ability slots with the current player abilities
        /// </summary>
        /// <param name="message"></param>
        private void OnAbilitiesInitialized(Dictionary<string, object> message)
        {
            List<AbilityBase> abilities = (List<AbilityBase>)message["abilities"];

            for (var i = 0; i < abilitySlotList.Capacity; i++)
            {
                abilitySlotList[i].setImage(abilities[i].abilityBaseData.icon);
                abilitySlotList[i].setName(abilities[i].abilityBaseData.abilityName);
                abilitySlotList[i].setCooldown(abilities[i].abilityBaseData.cooldown);
                abilitySlotList[i].setAvailable(abilities[i].abilityBaseData.available);
            }
        }

        /// <summary>
        /// Trigger cooldown of a specific ability
        /// </summary>
        /// <param name="abilityIndex"></param>
        private void OnTriggerAbility(Dictionary<string, object> message)
        {
            int abilityIndex = (int)message["abilityIndex"];
            abilitySlotList[abilityIndex].TriggerCooldown();
        }
    }
}
