using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace rpgStealth
{
    public class EnemyIdleState : EnemyPatrollingState
    {
        private float initialWaitingTime;
        private float currentWaitingTime;

        public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController) : base(enemy, enemyStateMachine, agentController)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            SetTimers();
        }

        public override void Exit()
        {
            base.Exit();
            ResetTimer();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (agentController.HasDestinationPoints()) 
            {
                DecreaseTimer();
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        /// <summary>
        /// Define timers
        /// </summary>
        private void SetTimers() 
        {
            initialWaitingTime = enemy.EnemyBase_SO.seachingTime;
            currentWaitingTime = initialWaitingTime;
        }

        /// <summary>
        /// Decrease time and change enemy state once the delay is reached
        /// </summary>
        private void DecreaseTimer()
        {
            currentWaitingTime -= Time.deltaTime;

            if (currentWaitingTime <= 0)
            {         
                enemyStateMachine.ChangeState(enemy.EnemyWalkingState);
            }
        }

        /// <summary>
        /// Reset timer
        /// </summary>
        private void ResetTimer()
        {
            currentWaitingTime = initialWaitingTime;
        }
    }
}