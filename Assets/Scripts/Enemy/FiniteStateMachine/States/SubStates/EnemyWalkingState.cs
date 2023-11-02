using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace rpgStealth
{
    public class EnemyWalkingState : EnemyPatrollingState
    {
        public EnemyWalkingState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController) : base(enemy, enemyStateMachine, agentController)
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
            agentController.GoToNextDestination();
        }

        public override void Exit()
        {
            base.Exit();
            agentController.fieldOfView.ResetData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (agentController.DestinationReached()) 
            {
                enemyStateMachine.ChangeState(enemy.EnemyIdleState);
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        /// <summary>
        /// Override NavMeshAgent properties
        /// </summary>
        private void SetAgentData() {
            agentController.agent.speed = enemy.EnemyBase_SO.walkingSpeed;
            agentController.agent.stoppingDistance = enemy.EnemyBase_SO.stoppingDistance;
        }
    }
}