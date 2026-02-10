using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName="Date/StateMachine/PlayerState/Idel",fileName = "PlayerStateIdle")]
public class PlayerStateIdle : PlayerState
{
    public override void Enter()
    {
        animator.Play("Idle");
        currentSpeed = playerController.CurrentSpeed;

        playerController.moveParticle.Stop();
        playerController.jumpParticle.Play();
    }

    public override void LogicUpdate()
    {
        if(playerInput.IsMove)
        {
            stateMachine.SwitchState(typeof(PlayerStateMove));
        }
        if (playerInput.PressJump)
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }
        if (!playerInput.PressJump && playerRigidbody.velocity.y > 0 && !playerController.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFloat));
        }
        if (playerRigidbody.velocity.y < 0 && !playerController.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }
        if (playerInput.PressShoot && playerController.volum > 1)
        {
            stateMachine.SwitchState(typeof(PlayerStateShoot));
        }
        if (playerInput.PressCoreShoot)
        {
            stateMachine.SwitchState(typeof(PlayerStateCoreShoot));
        }

        //控制移动速度的变化
        currentSpeed = playerController.PlayerHowToMove(currentSpeed);
    }

    public override void PhysicUpdate()
    {
        playerController.PlayerMove(currentSpeed);
    }
}

