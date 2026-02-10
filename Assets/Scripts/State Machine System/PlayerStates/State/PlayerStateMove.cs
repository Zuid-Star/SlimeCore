using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Move", fileName = "PlayerStateMove")]
public class PlayerStateMove : PlayerState
{
    [SerializeField] AudioClip shootSFX;
    //public float stopSpeed = 0.5f;
    public override void Enter()
    {
        animator.Play("Move");
        currentSpeed = playerController.CurrentSpeed;
        playerController.VoicePlayer.clip = shootSFX;
        playerController.VoicePlayer.loop = true;
        playerController.VoicePlayer.Play();
        playerController.moveParticle.Play();
    }
    public override void Exit()
    {
        playerController.VoicePlayer.Stop();
        
    }

    public override void LogicUpdate()
    {
        if (!playerInput.IsMove) 
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
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
