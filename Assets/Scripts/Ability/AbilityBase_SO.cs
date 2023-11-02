using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "AbilityBase", menuName = "ScriptableObjects/Ability/AbilityBase", order = 1)]
    public class AbilityBase_SO : ScriptableObject
    {
        public string abilityName;
        public Sprite icon;
        public float cooldown;
        public string animationName;
        public bool available;
    }
}

