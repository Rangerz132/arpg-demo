using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public abstract class AbilityBase : MonoBehaviour
    {
        public float cooldown;
        public float tick;
        public bool available;
        public AbilityBase_SO abilityBaseData;
        public ScriptableObject abilityData;
        public bool readyToMove = false;

        public bool Activated { get; protected set; }

        public void Initialize()
        {
            cooldown = abilityBaseData.cooldown;
            available = abilityBaseData.available;
            tick = cooldown;
        }

        public virtual void Trigger()
        {
            Activated = true;
            available = false;
        }

        public virtual void LogicUpdate()
        {

        }

        public void StartMoving()
        {
            readyToMove = true;
        }

        public virtual void EndAbility()
        {

        }

        public virtual void Move()
        {

        }

        public void HandleCooldown()
        {
            if (available)
                return;

            tick -= Time.deltaTime;

            if (tick <= 0)
            {
                tick = cooldown;
                available = true;
                readyToMove = false;
            }
        }
    }
}