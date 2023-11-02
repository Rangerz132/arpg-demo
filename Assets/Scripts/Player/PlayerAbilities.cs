using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace rpgStealth
{
    public class PlayerAbilities : MonoBehaviour
    {
        public AbilityBase currentAbility;
        public List<AbilityBase> abilities;

        private void Start()
        {
            if (abilities.Capacity != 0)
            {
                EventManager.TriggerEvent("OnAbilitiesInitialized", new Dictionary<string, object> { { "abilities", abilities } });
            }
        }
    }
}
