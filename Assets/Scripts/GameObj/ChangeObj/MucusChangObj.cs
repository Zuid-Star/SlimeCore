using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucusChangObj : MonoBehaviour
{
    public GameObject mucus;
    public string animatorClip;
    private ChangeLogo changeLogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            changeLogo = collision.gameObject.GetComponentInChildren<ChangeLogo>();
            changeLogo.mucuses.Add(mucus);
            changeLogo.animationClip.Add(animatorClip);
            Destroy(this.gameObject);
        }
    }
}
