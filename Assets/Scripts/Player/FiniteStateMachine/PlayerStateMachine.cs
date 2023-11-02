using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerStateMachine
    {
        public PlayerState currentState { get; private set; }
        public PlayerState previousState { get; private set; }

        public void Initialize(PlayerState startingState)
        {
            currentState = startingState;
            previousState = startingState;
            currentState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            previousState = currentState;
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
