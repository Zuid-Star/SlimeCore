using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mucus1range : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Transform parentTransform = transform.parent;
            parentTransform.gameObject.tag = "Untagged";
        }
    }
}
