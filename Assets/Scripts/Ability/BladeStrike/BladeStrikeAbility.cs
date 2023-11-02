using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class BladeStrikeAbility : AbilityBase
    {
        private BladeStrikeAbility_SO bladeStrikeAbilityData;
        private float movementTimePosition;
        private Vector3 startingPosition;
        private Vector3 targetPosition;

        private void Start()
        {
            bladeStrikeAbilityData = abilityData as BladeStrikeAbility_SO;
            Initialize();
        }

        public void Update()
        {
            HandleCooldown();
        }

        public override void Trigger()
        {
            base.Trigger();
            movementTimePosition = 0;
            startingPosition = transform.position;
            targetPosition = transform.position + transform.forward * bladeStrikeAbilityData.distance;
        }

        public override void Move()
        {
            movementTimePosition += Time.deltaTime;
            if (transform.position != targetPosition)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, bladeStrikeAbilityData.animationCurve.Evaluate(movementTimePosition));
            }
            base.Move();
        }

        public override void EndAbility()
        {
            movementTimePosition = 0;
            startingPosition = transform.position;
            readyToMove = false;
            Activated = false;
        }

        public override void LogicUpdate()
        {

        }
    }
}

