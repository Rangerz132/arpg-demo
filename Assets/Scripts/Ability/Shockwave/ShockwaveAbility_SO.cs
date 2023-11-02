using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "ShockwaveAbility", menuName = "ScriptableObjects/Ability/Shockwave", order = 3)]
    public class ShockwaveAbility_SO : ScriptableObject
    {
        public AbilityBase_SO abilityBaseSO;

        [Header("Movement")]
        public AnimationCurve animationCurve;
        public float distance;

        [Header("Damage")]
        public int minDamage;
        public int maxDamage;
    }
}

