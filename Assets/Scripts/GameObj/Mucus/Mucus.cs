using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mucus : MonoBehaviour
{
    public float fallMultiplier = 4f;
    public float InVolumeX = 0.8f;
    public float InVolumeY = 0.8f;

    private Rigidbody2D rb2d;
    public ParticleSystem deathParticle;
    public int volum;

    void Start()
    {
        //deathParticle = GetComponentInChildren<ParticleSystem>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(rb2d.bodyType != RigidbodyType2D.Static)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }


    //根据可分裂次数改变体积
    public void ChangeVolume()
    {
        transform.localScale = new Vector3(InVolumeX + 0.3f * (volum - 1), InVolumeY + 0.3f * (volum - 1), 1f);
    }

    //死亡相关脚本
    public void Death()
    {
        Instantiate(deathParticle, this.transform.position, Quaternion.Euler(transform.eulerAngles));
        Destroy(this.gameObject);
    }
}
