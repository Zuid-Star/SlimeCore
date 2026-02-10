using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShootMucus : MonoBehaviour
{

    public float speed;
    public int volum = 1;
    private Rigidbody2D rb2d;
    public float pickupDelay = 0.5f; //  ∞»°—”≥Ÿ ±º‰
    private Mucus mucus;

    void Start()
    {
        mucus = GetComponent<Mucus>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        mucus.volum = volum;
        mucus.ChangeVolume();
        Invoke("ChangeTag", pickupDelay);

    }

    private void ChangeTag()
    {
        this.gameObject.tag = "Mucus";
    }
}
