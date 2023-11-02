using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class Enemy : MonoBehaviour
    {
        // FSM
        public EnemyStateMachine EnemyStateMachine { get; private set; }
        public EnemyIdleState EnemyIdleState { get; private set; }
        public EnemyWalkingState EnemyWalkingState { get; private set; }
        public EnemyChasingState EnemyChasingState { get; private set; }
        public EnemyAttackState EnemyAttackState { get; private set; }
        public EnemyDeadState EnemyDeadState { get; private set; }

        // NavMeshAgent
        private AgentController agentController;

        [field: SerializeField] public EnemyBase_SO EnemyBase_SO { get; private set; }
        [SerializeField] private StatsHolder statsHolder;
        [SerializeField] private EnemyHealth enemyHealth;

        void Start()
        {
            agentController = GetComponent<AgentController>();

            // Set states
            EnemyStateMachine = new EnemyStateMachine();
            EnemyIdleState = new EnemyIdleState(this, EnemyStateMachine, agentController);
            EnemyWalkingState = new EnemyWalkingState(this, EnemyStateMachine, agentController);
            EnemyChasingState = new EnemyChasingState(this, EnemyStateMachine, agentController);
            EnemyAttackState = new EnemyAttackState(this, EnemyStateMachine, agentController);
            EnemyDeadState = new EnemyDeadState(this, EnemyStateMachine, agentController);
            EnemyStateMachine.Initialize(EnemyIdleState);

            statsHolder.SetStats(EnemyBase_SO.enemyName, EnemyBase_SO.level.ToString());
            enemyHealth.SetHealth(EnemyBase_SO.health);
            enemyHealth.healthBar = statsHolder.HealthBarGauge;
        }

        private void Update()
        {
            EnemyStateMachine.currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            EnemyStateMachine.currentState.PhysicsUpdate();
        }
    }
}
