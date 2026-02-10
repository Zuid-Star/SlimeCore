using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Jump", fileName = "PlayerStateJump")]
public class PlayerStateJump : PlayerState
{
    [SerializeField] AudioClip jumpSFX;

    public override void Enter()
    {
        animator.Play("Jump");
        currentSpeed = playerController.CurrentSpeed;
        playerRigidbody.velocity = new Vector2(currentSpeed, playerController.jumpHight);
        playerController.VoicePlayer.PlayOneShot(jumpSFX);


        playerController.jumpParticle.Play();
        playerController.moveParticle.Stop();
    }

    public override void LogicUpdate()
    {

        if (playerInput.ReleasJump && playerRigidbody.velocity.y > 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateFloat));
        }
        if (playerRigidbody.velocity.y < 0)
        {
            stateMachine.SwitchState(typeof (PlayerStateFall));
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
        //长按增加跳跃高度
        if(playerRigidbody.velocity.y > 0 && !playerInput.IsPressedJump)
        playerController.PlayerUpGravity();

        playerController.PlayerMove(currentSpeed);
    }
}
