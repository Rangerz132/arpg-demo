using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace rpgStealth
{
    public class EnemyPatrollingState : EnemyState
    {

        public EnemyPatrollingState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController) : base(enemy, enemyStateMachine, agentController)
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
            CheckForTargetInLineOfSight();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public void CheckForTargetInLineOfSight()
        {
            if (agentController.fieldOfView.CanSeeTarget) 
            {
                enemyStateMachine.ChangeState(enemy.EnemyChasingState);
            }
              
        }
    }
}