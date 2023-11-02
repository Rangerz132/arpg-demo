using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public abstract class Health : MonoBehaviour
    {
        public float currentHealth;
        public float maxHealth;

        /// <summary>
        /// Deal damage to entity
        /// </summary>
        /// <param name="damageAmount"></param>
        public virtual void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
        }

        /// <summary>
        /// Heal entity
        /// </summary>
        /// <param name="healAmount"></param>
        public virtual void Heal(int healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
