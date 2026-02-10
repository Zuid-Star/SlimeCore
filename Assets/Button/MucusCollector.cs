using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucusCollector : MonoBehaviour
{
    [SerializeField] VoidEventChannel buttonEventChannels;
    public int target = 0;// 接收目标数
    private int count = 0;//计数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mucus")
        {
            Destroy(collision.gameObject);
            count++;
        }
        if(count==target) 
        {
            count=0;
            buttonEventChannels.Broadcast();
        }
    }
}
