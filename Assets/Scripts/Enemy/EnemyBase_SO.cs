using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    [CreateAssetMenu(fileName = "EnemyBase", menuName = "ScriptableObjects/Enemy/EnemyBase", order = 1)]
    public class EnemyBase_SO : ScriptableObject
    {
        [Header ("Base")]
        public string enemyName;
        public int level;
        public float health;

        [Header("Movement")]
        public float walkingSpeed;
        public float runningSpeed;
        public float rotationSpeed;

        [Header("AI")]
        public float stoppingDistance;
        public float seachingTime;
        public float chasingTime;
        public float detectionZoneDiameter;
    }
}

