using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "BladeStrikeAbility", menuName = "ScriptableObjects/Ability/BladeStrike", order = 1)]
    public class BladeStrikeAbility_SO : ScriptableObject
    {
        public AbilityBase_SO abilityBaseSO;

        [Header("Movement")]
        public AnimationCurve animationCurve;
        public float distance;
    }
}

