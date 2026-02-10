using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseUiControler : MonoBehaviour
{
    public PlayerInputActions inputActions;
    public GameObject uiCanvas;
    public string mainMenu;
    private ChangeBack changeBack;
    //是否按下暂停标识
    private bool isPaused;

    //主要为了控制角色暂停状态
    public PlayerInput playerInput;



    void Awake()
    {
        inputActions = new PlayerInputActions();
        isPaused = false;
        changeBack = transform.parent.parent.GetComponentInChildren<ChangeBack>();
        
    }

    void OnEnable()
    {
        inputActions.Ui.Enable();
        //绑定暂停事件
        inputActions.Ui.Pause.performed += OnPause;
        //绑定重置事件
        inputActions.Ui.Restart.performed += Restart;
    }

    void OnDisable()
    {
        inputActions.Ui.Pause.performed -= OnPause;
        inputActions.Ui.Restart.performed -= Restart;
        inputActions.Disable();
    }

    //返回主菜单按钮
    public void MainMenuButton()
    {
        changeBack.SetEndPoint(1, 1);
        Time.timeScale = 1;
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence("MainMenu"));
    }

    //继续按钮功能
    public void ContinueButton()
    {
        Continue();
        playerInput.isPaused = false;
        playerInput.playerInputActions.GamePlay.Enable();

    }

    //重置游戏按钮
    public void RestartButton()
    {
        Time.timeScale = 1;
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(SceneManager.GetActiveScene().buildIndex));
    }

    //暂停游戏方法
    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        uiCanvas.SetActive(true);
    }

    //继续游戏方法
    private void Continue()
    {
        isPaused = false;
        Time.timeScale = 1;
        uiCanvas.SetActive(false);
    }

    //暂停按键事件
    private void OnPause(InputAction.CallbackContext context)
    {
        if(!isPaused)
        {
            Pause();
        }
        else if(isPaused)
        {
            Continue();
        }
    }

    //重置按键事件
    private void Restart(InputAction.CallbackContext context)
    {
        if(!isPaused)
        {
            isPaused = true;
            changeBack.SetEndPoint(1, 1);
            StartCoroutine(changeBack.IChangeBack(0, 1));
            StartCoroutine(changeBack.IChanegSence(SceneManager.GetActiveScene().buildIndex));
        }     
    }

    //重置场景函数
    private void ResetScense()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
