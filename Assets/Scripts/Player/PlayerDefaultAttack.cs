using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerDefaultAttack : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private string animationCounter = "defaultAttackCounter";
        [field: SerializeField] public List<DefaultAttack_SO> DefaultAttack_SOList { get; private set; }
        private int attackCounter = 0;
        private int maxAttackCounter;
        private Vector3 startingPosition = Vector3.zero;
        private Vector3 targetPosition = Vector3.zero;
        private float movementTimePosition = 0;
        public bool readyToMove = false;

        private void Start()
        {
            maxAttackCounter = DefaultAttack_SOList.Capacity - 1;
        }

        public void StartMoving()
        {
            readyToMove = true;
            movementTimePosition = 0;
            startingPosition = transform.position;
            targetPosition = transform.position + transform.forward * DefaultAttack_SOList[attackCounter].distance;
        }

        /// <summary>
        /// Move transform according to the animation
        /// </summary>
        public void MoveAlongAnimation()
        {
            movementTimePosition += Time.deltaTime;
            if (transform.position != targetPosition)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, DefaultAttack_SOList[attackCounter].animationCurve.Evaluate(movementTimePosition));
            }
            else
            {
                movementTimePosition = 0;
                readyToMove = false;
                startingPosition = transform.position;
            }
        }

        /// <summary>
        /// Check if the maximum amount of attacks has been reached
        /// </summary>
        public void CheckForMaxAttackCounter()
        {
            if (attackCounter >= maxAttackCounter)
            {
                ResetAttackCounter(true);
            }
        }

        /// <summary>
        /// Reset attack counter if it reaches the limit
        /// </summary>
        /// <param name="isLooping"></param>
        public void ResetAttackCounter(bool isLooping)
        {
            attackCounter = isLooping ? -1 : 0;
            player.Animator.SetInteger(animationCounter, attackCounter);
        }

        /// <summary>
        /// Increase attack counter to trigger the next attack animation
        /// </summary>
        public void IncreaseAttackCounter()
        {
            attackCounter++;
            player.Animator.SetInteger(animationCounter, attackCounter);
        }

        /// <summary>
        /// Check if the player click is valid according to a specific range
        /// </summary>
        /// <returns></returns>
        public bool isInRangeForClick()
        {
            var normalizedAnimation = player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            return normalizedAnimation >= 0.1f && normalizedAnimation <= DefaultAttack_SOList[attackCounter].maxClickAnimationRange;
        }

        /// <summary>
        /// Check if the current animation range is done
        /// </summary>
        /// <returns></returns>
        public bool currentAnimationRangeIsDone()
        {
            return player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > DefaultAttack_SOList[attackCounter].normalizedAnimationEnd;
        }

        /// <summary>
        /// Check if the current animation is done
        /// </summary>
        /// <returns></returns>
        public bool currentAnimationIsDone()
        {
            return player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f;
        }
    }
}
