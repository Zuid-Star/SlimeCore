
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] VoidEventChannel pressurePlateEventChannel;
    [SerializeField] VoidEventChannel outpressurePlateEventChannel;
    private int leftCollisionCount = 0;
    private int rightCollisionCount = 0;
    private Animator Pr_Ani;

    void Start()
    {
        Pr_Ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bool isLeft = IsCollisionFromLeft(other);
        if (other.gameObject.tag == "Player")
        {
         if (isLeft)
        {
            pressurePlateEventChannel.Broadcast();
            Pr_Ani.SetBool("Left", true);
        }
        else
        {
            outpressurePlateEventChannel.Broadcast();
            Pr_Ani.SetBool("Left", false);
        }
        }

    }

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    bool isLeft = IsCollisionFromLeft(other);

    //    if (isLeft)
    //    {
    //        leftCollisionCount = Mathf.Max(0, leftCollisionCount - 1);
    //        UpdatePressurePlateState();
    //    }
    //    else
    //    {
    //        rightCollisionCount = Mathf.Max(0, rightCollisionCount - 1);
    //        UpdatePressurePlateState();
    //    }
    //}

    //private void UpdatePressurePlateState()
    //{
    //    // 优先判断右侧碰撞
    //    if (rightCollisionCount > 0)
    //    {
    //        outpressurePlateEventChannel.Broadcast();
    //        Pr_Ani.SetBool("Left", false);
    //    }
    //    else if (leftCollisionCount > 0)
    //    {
    //        pressurePlateEventChannel.Broadcast();
    //        Pr_Ani.SetBool("Left", true);
    //    }
    //    else
    //    {
    //        outpressurePlateEventChannel.Broadcast();
    //        Pr_Ani.SetBool("Left", false);
    //    }
    //}

    private bool IsCollisionFromLeft(Collision2D collision)
    {
        // 通过比较碰撞体中心位置判断方向
        Vector3 colliderCenter = collision.collider.bounds.center;
        return colliderCenter.x < transform.position.x;
    }

    void Update()
    {
        // 可留空或用于调试
    }
}