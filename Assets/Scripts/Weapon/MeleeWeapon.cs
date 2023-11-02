using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class MeleeWeapon : Weapon
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out EnemyHealth enemyHealth))
            {
                var damage = GetRandomDamageValue();
                enemyHealth.TakeDamage(damage);
                var hitPoint = other.ClosestPoint(transform.position);

                EventManager.TriggerEvent("OnEnemyHit", new Dictionary<string, object> { { "cameraImpusleVelocity", transform.forward }, { "damageDealth", damage }, { "hitPosition", hitPoint } });
            }
        }
    }
}
