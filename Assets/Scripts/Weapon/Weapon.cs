using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected int minDamage;
        [SerializeField] protected int maxDamage;
        protected Collider weaponCollider;

        private void Awake()
        {
            weaponCollider = GetComponent<Collider>();
        }

        public virtual int GetRandomDamageValue()
        {
            return Mathf.FloorToInt(Random.Range(minDamage, maxDamage));
        }

        public virtual void EnableCollider(bool enabled)
        {
            weaponCollider.enabled = enabled;
        }
    }
}