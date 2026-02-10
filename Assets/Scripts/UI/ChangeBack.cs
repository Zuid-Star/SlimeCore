using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ChangeBack : MonoBehaviour
{
    private Material mat;
    private void Awake()
    {
        mat = GetComponent<Image>().material;
    }
    private void Start()
    {
        SetLineWidth(0);
        SetEndPoint(0, 0);
        StartCoroutine(IChangeBack(1.2f, 0));
    }

    public void SetLineWidth(float x)
    {
        mat.SetFloat("_LineWidth", x);
    }
    public void SetEndPoint(float x,float y)
    {
        Vector2 v = new Vector2(x, y);
        mat.SetVector("_CenterOffset", v);
    }
    public void SetAngle(float x)
    {
        mat.SetFloat("_GridAngle", x);
    }
    public void SetDensity(float x)
    {
        mat.SetFloat("_GridDensity", x);
    }
    public void SetOffset(float x,float y)
    {
        Vector2 v = new Vector2(x, y);
        mat.SetVector("_GridOffset", v);
    }

        //通过协程控制切换动画
    public IEnumerator IChangeBack(float x, float y)
    {
        if (x < y)
        {
            while (x < y)
            {
                SetLineWidth(x);
                x += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (x > y)
            {
                SetLineWidth(x);
                x -= Time.deltaTime;
                yield return null;
            }
        }
    }
    //协程控制场景加载
    public IEnumerator IChanegSence(string sence)
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(sence);
    }
    public IEnumerator IChanegSence(int sence)
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(sence);
    }
}
