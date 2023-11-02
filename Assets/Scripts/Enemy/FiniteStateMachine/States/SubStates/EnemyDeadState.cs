using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace rpgStealth
{
    public class EnemyDeadState : EnemyState
    {
        public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController) : base(enemy, enemyStateMachine, agentController)
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

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}