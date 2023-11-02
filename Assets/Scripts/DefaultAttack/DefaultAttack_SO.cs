using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "DefaultAttack", menuName = "ScriptableObjects/DefaultAttack/PlayerDefaultAttack", order = 1)]
    public class DefaultAttack_SO : ScriptableObject
    {
        public AnimationCurve animationCurve;
        public float distance;
        public Vector2 damageRange;
        public float maxClickAnimationRange;
        public float normalizedAnimationEnd;
    }
}
