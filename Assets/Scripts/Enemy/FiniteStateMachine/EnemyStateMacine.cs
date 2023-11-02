using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class EnemyStateMachine
    {
        public EnemyState currentState { get; private set; }
        public EnemyState previousState { get; private set; }

        public void Initialize(EnemyState startingState)
        {
            currentState = startingState;
            previousState = startingState;
            currentState.Enter();
        }

        public void ChangeState(EnemyState newState)
        {
            previousState = currentState;
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
