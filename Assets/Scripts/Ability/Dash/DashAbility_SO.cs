using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "DashAbility", menuName = "ScriptableObjects/Ability/Dash", order = 1)]
    public class DashAbility_SO : ScriptableObject
    {
        public AbilityBase_SO abilityBaseSO;

        [Header("Movement")]
        public AnimationCurve animationCurve;
        public float distance;
    }
}

