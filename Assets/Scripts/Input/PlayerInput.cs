using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public PlayerInputActions playerInputActions;
    //获取方向键轴向数据
    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();
    //是否按下跳跃键标识
    public bool PressJump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool IsPressedJump => playerInputActions.GamePlay.Jump.IsPressed();
    public bool ReleasJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();
    //是否按下射击键标识
    public bool PressShoot => playerInputActions.GamePlay.Shoot.WasPressedThisFrame();
    public bool IsPressedShoot => playerInputActions.GamePlay.Shoot.IsPressed();
    public bool ReleasShoot => playerInputActions.GamePlay.Shoot.WasReleasedThisFrame();
    //是否按下分离键标识
    public bool PressCoreShoot => playerInputActions.GamePlay.CoreShoot.WasPressedThisFrame();
    public bool IsPressedCoreShoot => playerInputActions.GamePlay.CoreShoot.IsPressed();
    public bool ReleasCoreShoot => playerInputActions.GamePlay.CoreShoot.WasReleasedThisFrame();
    //是否按下eat键
    public bool PressEat => playerInputActions.GamePlay.Eat.WasPressedThisFrame();
    public bool IsPressedEat => playerInputActions.GamePlay.Eat.IsPressed();
    public bool ReleasEat => playerInputActions.GamePlay.Eat.WasReleasedThisFrame();
    //是否移动标识
    public bool IsMove => Axisx != 0f;
    //获取横向轴向数据
    public float Axisx => axes.x;
    public float Axisy => axes.y;
    //获取滚轮数据
    Vector2 scoll => playerInputActions.GamePlay.Scroll.ReadValue<Vector2>();
    public float scolly =>scoll.y;

    //是否暂停标识
    public bool isPaused;


    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        isPaused = false;
    }

    public void EnableGamePlayInputs()
    {
        playerInputActions.Enable();
        ////绑定暂停事件
        //playerInputActions.Ui.Pause.performed += OnPause;
    }

    //暂停按钮事件
    public void OnPause(InputAction.CallbackContext context)
    {

        if (isPaused)
        {
            playerInputActions.GamePlay.Enable();
            isPaused = false;
        }
        else if (!isPaused)
        {
            playerInputActions.GamePlay.Disable();
            isPaused = true;
        }
    }

}
