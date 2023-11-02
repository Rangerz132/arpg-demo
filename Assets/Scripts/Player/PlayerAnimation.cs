using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Player player;

        /// <summary>
        /// Trigger effect on an animation event
        /// </summary>
        private void OnActivateEffect()
        {
            player.PlayerStateMachine.currentState.ActivateEffect();
        }

        /// <summary>
        /// Trigger player movement on an animation event
        /// </summary>
        private void OnStartMove()
        {
            player.PlayerStateMachine.currentState.StartMoving();
        }

        /// <summary>
        /// Trigger the end of the player state
        /// </summary>
        private void OnEndState()
        {
            player.PlayerStateMachine.currentState.EndState();
        }

        /// <summary>
        /// Enable player weapon collider on an animation event
        /// </summary>
        private void OnEnableWeaponCollider()
        {
            player.Weapon.EnableCollider(true);
        }

        /// <summary>
        /// Disable player weapon collider on an animation event
        /// </summary>
        private void OnDisableWeaponCollider()
        {
            player.Weapon.EnableCollider(false);
        }
    }
}

