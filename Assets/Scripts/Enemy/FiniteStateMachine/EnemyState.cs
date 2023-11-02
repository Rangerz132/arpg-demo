using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpgStealth
{
    public class EnemyState
    {
        protected Enemy enemy;
        protected EnemyStateMachine enemyStateMachine;
        protected AgentController agentController;

        public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine, AgentController agentController)
        {
            this.enemy = enemy;
            this.enemyStateMachine = enemyStateMachine;
            this.agentController = agentController;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
  
        }

        public virtual void LogicUpdate()
        {
            DoChecks();
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }

        public virtual void ActivateEffect()
        {

        }

        public virtual void StartMoving()
        {

        }

        public virtual void EndState()
        {

        }
    }
}