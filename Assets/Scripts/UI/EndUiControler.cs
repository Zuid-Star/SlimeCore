using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUiControler : MonoBehaviour
{
    public string nextLevel;
    private ChangeBack changeBack;

    private void Awake()
    {
        changeBack = transform.parent.parent.GetComponentInChildren<ChangeBack>();
    }

    //返回主菜单按钮
    public void MainMenuButton()
    {
        changeBack.SetEndPoint(1, 1);
        Time.timeScale = 1;
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence("MainMenu"));
    }
    //重来按钮
    public void AgainButton()
    {
        Time.timeScale = 1;
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(SceneManager.GetActiveScene().buildIndex));
    }

    //下一关按钮
    public void NextButton()
    {
        Time.timeScale = 1;
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(nextLevel));
    }
    //选择关卡按钮
    public void SelectButton()
    {
        Time.timeScale = 1;
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence("SelectScence"));
    }
}
