using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Fall", fileName = "PlayerStateFall")]
public class PlayerStateFall : PlayerState
{
    public override void Enter()
    {
        animator.Play("Fall");
        currentSpeed = playerController.CurrentSpeed;
    }

    public override void LogicUpdate()
    {
        if (playerController.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }
        if (playerInput.PressShoot && playerController.volum > 1)
        {
            stateMachine.SwitchState(typeof(PlayerStateShoot));
        }
        if (playerRigidbody.velocity.y > 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateFloat));
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
        playerController.PlayerFallGravity();
    }
}
