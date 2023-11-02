using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpgStealth
{
    public class PlayerState
    {
        protected Player player;
        protected PlayerStateMachine playerStateMachine;
        protected string animBoolName;

        public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        {
            this.player = player;
            this.playerStateMachine = playerStateMachine;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            player.Animator.SetBool(animBoolName, true);
        }

        public virtual void Exit()
        {
            player.Animator.SetBool(animBoolName, false);
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