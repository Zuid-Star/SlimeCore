using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/CoreShoot", fileName = "PlayerStateCoreShoot")]
public class PlayerStateCoreShoot : PlayerState
{
    public override void Enter()
    {
        animator.Play("Core");
        playerController.bodyTransform.localScale = new Vector3(0.2f, 0.2f, 1);
        playerController.mouseTracking.CoreShoot();
        playerRigidbody.freezeRotation = false;
    }

    public override void Exit()
    {
        playerTransform.localEulerAngles = Vector3.zero;
        playerRigidbody.freezeRotation = true;
    }

    public override void LogicUpdate()
    {

        if(playerController.volum > 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }

    }

    public override void PhysicUpdate()
    {
        playerController.PlayerFallGravity();
    }
}
