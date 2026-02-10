using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBody : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private Vector3 startPos;
    public float pickupDelay = 0.5f; // 拾取延迟时间
    private CircleCollider2D circleCollider;  // 碰撞箱组件
    private GameObject player;
    private int volum;
    private MucusCollsion mucusCollsion;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mucusCollsion = GetComponent<MucusCollsion>();
        player = GameObject.FindWithTag("Player");
        rb2d.velocity = -transform.right * speed;
        startPos = transform.position;
        volum = (player.GetComponent<PlayerController>()).volum;
        ChangeVolume();
        Invoke("ChangeTag", pickupDelay);
    }

    private void ChangeTag()
    {
        this.gameObject.tag = "Mucus";
    }


    //根据可分裂次数改变体积
    public void ChangeVolume()
    {
        transform.localScale = new Vector3(1 + 0.3f * (volum - 1), 1 + 0.3f * (volum - 1), 1f);
    }
}
