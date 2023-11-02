using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerAbilityState : PlayerArmedState
    {
        private AbilityBase currentAbility;

        public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine, player.PlayerAbilities.currentAbility.abilityBaseData.animationName)
        {
            currentAbility = player.PlayerAbilities.currentAbility;
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            currentAbility = player.PlayerAbilities.currentAbility;
            currentAbility.Trigger();
            animBoolName = currentAbility.abilityBaseData.animationName;
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            currentAbility.LogicUpdate();

            // Move player along animation
            if (currentAbility.readyToMove)
            {
                currentAbility.Move();
            }

            // Change player state when the ability is done
            if (!currentAbility.Activated)
            {
                playerStateMachine.ChangeState(player.ArmedWalkingState);
            }
        }

        public override void StartMoving()
        {
            base.StartMoving();
            currentAbility.StartMoving();
        }

        public override void EndState()
        {
            base.EndState();
            currentAbility.EndAbility();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void ActivateEffect()
        {
            base.ActivateEffect();
        }
    }
}



