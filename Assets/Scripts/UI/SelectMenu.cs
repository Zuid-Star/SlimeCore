using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public string mainMenu;
    private string level;
    private ChangeBack changeBack;

    private void Start()
    {
        level = "Test1";
        changeBack = transform.parent.GetComponentInChildren<ChangeBack>();
    }


    public void ReturnButton()
    {
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(mainMenu));
    }

    public void Level1()
    {
        ChangeLevel("Level1");
    }

    public void Level2()
    {
        ChangeLevel("Level2");
    }

    public void Level3()
    {
        ChangeLevel("Level3");
    }
    public void Level4()
    {
        ChangeLevel("Level4");
    }

    public void Level5()
    {
        ChangeLevel("Level5");
    }

    public void Level6()
    {
        ChangeLevel("Level6");
    }
    //»∑»œ∞¥≈•
    public void ConfirmLevel()
    {
        changeBack.SetEndPoint(1, 1);
        StartCoroutine(changeBack.IChangeBack(0, 1));
        StartCoroutine(changeBack.IChanegSence(level));
    }

    private void ChangeLevel(string level)
    {
        this.level = level;
    }
}
