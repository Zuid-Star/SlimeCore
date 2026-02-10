using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] VoidEventChannel pressurePlateEventChannel;
    [SerializeField] VoidEventChannel outpressurePlateEventChannel;
    private int collisionCount = 0;
    private Animator Pr_Ani;
    // Start is called before the first frame update
    void Start()
    {
        Pr_Ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        pressurePlateEventChannel.Broadcast();
        Pr_Ani.SetBool("IsOnCollisionEnter", true);
        collisionCount++;

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        collisionCount--;
      
        if (collisionCount <= 0)
        {
            collisionCount = 0; // 防止负数
            Invoke("OnNoCollisionDetected", 0.05f);
            
        }
    }
    private void OnNoCollisionDetected()
    {
        if (collisionCount <= 0)
        {
            collisionCount = 0; // 防止负数
            Pr_Ani.SetBool("IsOnCollisionEnter", false);
            Invoke("Outani", 0.35f);
        }
      
    }

    private void Outani()
    {
        if (collisionCount <= 0)
        {
            outpressurePlateEventChannel.Broadcast();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
