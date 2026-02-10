using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mucus1 : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
        rb2d.velocity = Vector2.zero;            // 停止运动
        rb2d.bodyType = RigidbodyType2D.Static; // 设置为Kinematic以固定位置
        }
    }
}
