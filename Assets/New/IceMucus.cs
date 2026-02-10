using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMucus : MonoBehaviour
{
    public float fallMultiplier = 4f;

    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity -= Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    }


}
