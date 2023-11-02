using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class WhirlwindAbility : AbilityBase
    {
        // TODO : REFACTOR player movement to avoid using player as singleton
        // but use it as an entity base class instead

        private WhirlwindAbility_SO whirlwindAbilityData;
        private float maxNormalizedTime = 0.95f;
        private enum WhirlwindState
        {
            Start = 0,
            Loop = 1,
            End = 2
        }
        private WhirlwindState whirlwindState = WhirlwindState.Start;

        private void Start()
        {
            whirlwindAbilityData = abilityData as WhirlwindAbility_SO;
            Initialize();
        }

        public void Update()
        {
            HandleCooldown();
        }

        public override void Trigger()
        {
            whirlwindState = WhirlwindState.Start;
            Player.Instance.Animator.SetBool("whirlwindRoundReached", false);
            base.Trigger();
        }

        public override void LogicUpdate()
        {
            switch (whirlwindState)
            {
                case WhirlwindState.Start:
                    if (Player.Instance.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= maxNormalizedTime)
                    {
                        whirlwindState = WhirlwindState.Loop;
                    }
                    break;
                case WhirlwindState.Loop:
                    if (Player.Instance.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= whirlwindAbilityData.roundAmount)
                    {
                        Player.Instance.Animator.SetBool("whirlwindRoundReached", true);
                        whirlwindState = WhirlwindState.End;
                    }
                    break;
                case WhirlwindState.End:
                    if (Player.Instance.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= maxNormalizedTime
                    && Player.Instance.Animator.GetCurrentAnimatorStateInfo(0).IsName("WhirlwindEnd"))
                    {
                        Activated = false;
                    }
                    break;
            }
        }

        public override void Move()
        {
            if (whirlwindState == WhirlwindState.Loop)
            {
                Vector2 inputVector = Player.Instance.PlayerInputHandler.GetMovementVectorNormalized();
                Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

                float moveDistance = whirlwindAbilityData.movementSpeed * Time.deltaTime;
                Player.Instance.transform.position += moveDirection * moveDistance;
                base.Move();
            }
        }
    }
}

