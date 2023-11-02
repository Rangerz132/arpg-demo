using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "WhirlwindAbility", menuName = "ScriptableObjects/Ability/Whirlwind", order = 1)]
    public class WhirlwindAbility_SO : ScriptableObject
    {
        public AbilityBase_SO abilityBaseSO;

        [Header("Movement")]
        public float movementSpeed;
        public int roundAmount;

        [Header("Damage")]
        public int minDamage;
        public int maxDamage;
    }
}

