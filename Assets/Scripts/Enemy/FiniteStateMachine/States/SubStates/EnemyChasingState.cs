using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace rpgStealth
{
    public class EnemyChasingState : EnemyAlertState
    {
        public EnemyChasingState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController) : base(enemy, enemyStateMachine, agentController)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            SetAgentData();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            agentController.GoToTarget();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        /// <summary>
        /// Override NavMeshAgent properties
        /// </summary>
        private void SetAgentData()
        {
            agentController.agent.speed = enemy.EnemyBase_SO.runningSpeed;
            agentController.agent.stoppingDistance = enemy.EnemyBase_SO.stoppingDistance;
        }
    }
}