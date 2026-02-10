using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public GameObject deathUi;
    public ChangeBack changeBack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mucus")
        {
            collision.gameObject.GetComponent<Mucus>().Death();
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().Death();
            changeBack.SetEndPoint(1,1);
            StartCoroutine(changeBack.IChangeBack(0, 1));
            StartCoroutine(changeBack.IChanegSence(SceneManager.GetActiveScene().buildIndex));
            //Invoke("DeathUi",1.1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mucus")
        {
            collision.gameObject.GetComponent<Mucus>().Death();
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().Death();
            changeBack.SetEndPoint(1, 1);
            StartCoroutine(changeBack.IChangeBack(0, 1));
            StartCoroutine(changeBack.IChanegSence(SceneManager.GetActiveScene().buildIndex));
            //Invoke("DeathUi", 1.1f);
        }
    }

    private void DeathUi()
    {
        deathUi.SetActive(true);
    }

}
