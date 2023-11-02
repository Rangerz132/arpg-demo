using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace rpgStealth
{
    public class PlayerArmedIdleState : PlayerArmedState
    {
        public PlayerArmedIdleState(Player player, PlayerStateMachine playerStateMachine, string animBoolName) : base(player, playerStateMachine, animBoolName)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            HandleMovement();

            // Default Attack
            if (player.PlayerInputHandler.DefaultAttackInput)
            {
                player.RotatePlayerBasedOnMousePosition();
                playerStateMachine.ChangeState(player.ArmedDefaultAttackState);
            }

            // Abilities
            for (var i = 0; i < player.PlayerInputHandler.AbilityAmount; i++)
            {
                if (player.PlayerInputHandler.AbilityInputs[i])
                {
                    if (player.PlayerAbilities.abilities[i].available)
                    {
                        HandleAbility(i);
                    }
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        /// <summary>
        /// Change player state to Ability State
        /// </summary>
        /// <param name="abilityIndex"></param>
        private void HandleAbility(int abilityIndex)
        {
            EventManager.TriggerEvent("OnTriggerAbility", new Dictionary<string, object> { { "abilityIndex", abilityIndex } });
            player.RotatePlayerBasedOnMousePosition();
            player.PlayerAbilities.currentAbility = player.PlayerAbilities.abilities[abilityIndex];
            playerStateMachine.ChangeState(player.AbilityState);
        }

        /// <summary>
        /// Check if the player is moving based on the input values
        /// </summary>
        private void HandleMovement()
        {
            Vector2 inputVector = player.PlayerInputHandler.GetMovementVectorNormalized();
            Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

            if (moveDirection != Vector3.zero)
            {
                playerStateMachine.ChangeState(player.ArmedWalkingState);
            }
        }
    }
}