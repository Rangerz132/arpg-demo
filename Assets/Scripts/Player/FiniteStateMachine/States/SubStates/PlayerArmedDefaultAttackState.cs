using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerArmedDefaultAttackState : PlayerArmedState
    {
        private int clickAmount = 0;
        private int currentState = 0;

        public PlayerArmedDefaultAttackState(Player player, PlayerStateMachine playerStateMachine, string animBoolName) : base(player, playerStateMachine, animBoolName)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.PlayerDefaultAttack.ResetAttackCounter(false);
        }

        public override void Exit()
        {
            base.Exit();
            player.PlayerDefaultAttack.readyToMove = false;
            player.PlayerDefaultAttack.ResetAttackCounter(false);
            currentState = 0;
        }

        public override void StartMoving()
        {
            player.PlayerDefaultAttack.StartMoving();
            base.StartMoving();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (player.PlayerInputHandler.DefaultAttackInput)
            {
                if (player.PlayerDefaultAttack.isInRangeForClick())
                {
                    this.clickAmount++;
                }
            }

            if (player.PlayerDefaultAttack.currentAnimationRangeIsDone())
            {
                if (this.clickAmount != 0)
                {
                    Attack();
                    resetClickAmount();

                    if (currentState >= 3)
                    {
                        currentState = 0;
                        resetClickAmount();
                    }
                }
                else
                {
                    if (player.PlayerDefaultAttack.currentAnimationIsDone())
                    {
                        playerStateMachine.ChangeState(player.ArmedIdleState);
                    }
                }
            }

            if (player.PlayerDefaultAttack.readyToMove)
            {
                player.PlayerDefaultAttack.MoveAlongAnimation();
            }
        }

        /// <summary>
        /// Trigger the player attack
        /// </summary>
        private void Attack()
        {
            player.RotatePlayerBasedOnMousePosition();
            player.PlayerDefaultAttack.CheckForMaxAttackCounter();
            player.PlayerDefaultAttack.IncreaseAttackCounter();
        }

        /// <summary>
        /// Reset click amount
        /// </summary>
        private void resetClickAmount()
        {
            this.clickAmount = 0;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}