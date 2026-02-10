using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Shoot", fileName = "PlayerStateShoot")]
public class PlayerStateShoot : PlayerState
{
    [SerializeField] AudioClip shootSFX;
    public override void Enter()
    {
        playerController.mouseTracking.Shoot();
        playerController.volum--;
        playerController.ChangeVolume();
        playerController.VoicePlayer.PlayOneShot(shootSFX);

    }

    public override void LogicUpdate()
    {
        if (!playerInput.PressJump && playerRigidbody.velocity.y > 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateFloat));
        }
        if (playerRigidbody.velocity.y <= 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }
        if (playerInput.PressShoot)
        {
            stateMachine.SwitchState(typeof(PlayerStateShoot));
        }
    }
}
