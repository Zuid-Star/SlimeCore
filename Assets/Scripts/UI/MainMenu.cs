using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string begainScence;
    public string continueScence;
    public string selectScence;
    private ChangeBack changeBack;
    private void Start()
    {
        changeBack = transform.parent.GetComponentInChildren<ChangeBack>();
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void BegianButton()
    {
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0,1));
        StartCoroutine(changeBack.IChanegSence(begainScence));
    }

    public void ContinueButton()
    {
        //SceneManager.LoadScene(continueScence);
    }

    public void SelectButton()
    {
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(selectScence));
    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
