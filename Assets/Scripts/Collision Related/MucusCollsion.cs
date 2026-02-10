using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucusCollsion : MonoBehaviour
{
    private Mucus mucus;
    private Mucus collisionMucus;
    private PlayerController collisionPlayer;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] AudioClip mixSFX;

    private void Start()
    {
        mucus = GetComponent<Mucus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //与玩家相撞
        if (collision.gameObject.tag == "Player" && this.tag == "Mucus" )
        {
            collisionPlayer = collision.gameObject.GetComponent<PlayerController>();
            if(!(collisionPlayer.volum !=0 && !collisionPlayer.isEat))
            {
                Destroy(this.gameObject);
                SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            }
        }

        //与和自己相同的粘液相撞,通过比较速度确认保留和删除对象
        if(collision.gameObject.tag == "Mucus" && this.tag == "Mucus" )
        {
            collisionMucus = collision.gameObject.GetComponent<Mucus>();
            if(collision.rigidbody.velocity.magnitude > collision.otherRigidbody.velocity.magnitude)
            {

                //修改标签，放置重复触发
                collision.gameObject.tag = "Untagged";
                //修改体积
                mucus.volum += collisionMucus.volum;
                mucus.ChangeVolume();
                //修改坐标为中点
                transform.position = (transform.position + collision.gameObject.transform.position) / 2;
                SoundEffectsPlayer.AudioSource.PlayOneShot(mixSFX);
                //删除另一个物体
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //与玩家相撞
        if (collision.gameObject.tag == "Player" && this.tag == "Mucus")
        {
            collisionPlayer = collision.gameObject.GetComponent<PlayerController>();
            if (!(collisionPlayer.volum != 0 && !collisionPlayer.isEat))
            {
                Destroy(this.gameObject);  
                SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);

            }
        }
    }

}
