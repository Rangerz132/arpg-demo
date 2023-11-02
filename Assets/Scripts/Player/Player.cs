using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class Player : MonoBehaviour
    {
        // Player Instance
        public static Player Instance { get; private set; }

        // FSM
        public PlayerStateMachine PlayerStateMachine { get; private set; }
        public PlayerArmedIdleState ArmedIdleState { get; private set; }
        public PlayerArmedWalkingState ArmedWalkingState { get; private set; }
        public PlayerArmedDefaultAttackState ArmedDefaultAttackState { get; private set; }
        public PlayerAbilityState AbilityState { get; private set; }

        // Components
        [field: SerializeField] public PlayerInputHandler PlayerInputHandler { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public PlayerDefaultAttack PlayerDefaultAttack { get; private set; }
        [field: SerializeField] public PlayerAbilities PlayerAbilities { get; private set; }
        [field: SerializeField] public Weapon Weapon { get; private set; }

        [SerializeField] private PlayerDirectionIndicator playerDirectionIndicator;
        private bool isWalking;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one Player instance");
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            // Set states
            PlayerStateMachine = new PlayerStateMachine();
            ArmedIdleState = new PlayerArmedIdleState(this, PlayerStateMachine, "armedIdle");
            ArmedWalkingState = new PlayerArmedWalkingState(this, PlayerStateMachine, "armedWalking");
            ArmedDefaultAttackState = new PlayerArmedDefaultAttackState(this, PlayerStateMachine, "armedDefaultAttack");
            AbilityState = new PlayerAbilityState(this, PlayerStateMachine);
            PlayerStateMachine.Initialize(ArmedIdleState);
        }

        private void Update()
        {
            PlayerStateMachine.currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            PlayerStateMachine.currentState.PhysicsUpdate();
        }

        /// <summary>
        /// Rotate player based on the mouse position
        /// </summary>
        public void RotatePlayerBasedOnMousePosition()
        {
            transform.rotation = playerDirectionIndicator.getCurrentQuaternionRotation();
        }

        public bool IsWalking()
        {
            return isWalking;
        }
    }
}
