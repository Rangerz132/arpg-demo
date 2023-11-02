using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rpgStealth
{
    public class EnemyHealth : Health
    {
        [HideInInspector] public Image healthBar;

        /// <summary>
        /// Override health values by an entity ScriptableObject health values
        /// </summary>
        /// <param name="health"></param>
        public void SetHealth(float health)
        {
            currentHealth = health;
            maxHealth = health;
        }

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);
            SetHealthBar();
        }

        public override void Heal(int healAmount)
        {
            base.Heal(healAmount);
            SetHealthBar();
        }

        /// <summary>
        /// Set the health bar visually
        /// </summary>
        private void SetHealthBar()
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
