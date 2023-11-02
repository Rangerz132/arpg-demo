using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace rpgStealth
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;
        private PlayerInput playerInput;

        public bool DefaultAttackInput { get; private set; }
        public List<bool> AbilityInputs { get; private set; }
        public int AbilityAmount { get; private set; }

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInput = GetComponent<PlayerInput>();

            AbilityAmount = 4;
            AbilityInputs = new List<bool>();
            for (var i = 0; i < AbilityAmount; i++)
            {
                AbilityInputs.Add(false);
            }
        }

        private void OnEnable()
        {
            playerInputActions.Player.Enable();
        }

        private void OnDisable()
        {
            playerInputActions.Player.Disable();
        }

        public void OnDefaultAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DefaultAttackInput = true;
            }

            if (context.canceled)
            {
                DefaultAttackInput = false;
            }
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                SwitchActionMap("UI");
                EventManager.TriggerEvent("OnEnableMainMenu", new Dictionary<string, object> { { "key", "inventory" } });
                PauseManager.Instance.Pause();
            }
        }

        public void OnEscape(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                SwitchActionMap("Player");
                EventManager.TriggerEvent("OnDisableMainMenu", null);
                PauseManager.Instance.Resume();
            }
        }

        public void OnAbility1(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AbilityInputs[0] = true;
            }

            if (context.canceled)
            {
                AbilityInputs[0] = false;
            }
        }

        public void OnAbility2(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AbilityInputs[1] = true;
            }

            if (context.canceled)
            {
                AbilityInputs[1] = false;
            }
        }

        public void OnAbility3(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AbilityInputs[2] = true;
            }

            if (context.canceled)
            {
                AbilityInputs[2] = false;
            }
        }

        public void OnAbility4(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AbilityInputs[3] = true;
            }

            if (context.canceled)
            {
                AbilityInputs[3] = false;
            }
        }

        /// <summary>
        /// Return the player inputs normalized
        /// </summary>
        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }

        private void SwitchActionMap(string actionMapName) {
            playerInput.SwitchCurrentActionMap(actionMapName);
        }
    }
}
