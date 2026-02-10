using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBody : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public float pickupDelay = 0.5f; //  ∞»°—”≥Ÿ ±º‰
    private Mucus mucus;
    private GameObject player;

    void Start()
    {

        mucus = GetComponent<Mucus>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        mucus.volum = (player.GetComponent<PlayerController>()).volum;
        mucus.ChangeVolume();
        (player.GetComponent<PlayerController>()).volum = 0;
        rb2d.velocity = -transform.right * speed;
        Invoke("ChangeTag", pickupDelay);
    }

    private void ChangeTag()
    {
        this.gameObject.tag = "Mucus";
    }

}
