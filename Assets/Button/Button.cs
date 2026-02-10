using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] VoidEventChannel buttonEventChannel;
    private Animator Bu_Ani;
    // Start is called before the first frame update
    void Start()
    {
        Bu_Ani=GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        buttonEventChannel.Broadcast();
        Bu_Ani.SetBool("IsOnCollisionEnter",true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
