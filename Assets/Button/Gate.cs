using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private SpriteRenderer sr;
    [SerializeField] VoidEventChannel buttonEventChannel;
    [SerializeField] VoidEventChannel outpressurePlateEventChannel;

    void Start()
    {      
        bc2d = GetComponent<BoxCollider2D>();
        sr= GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        if (buttonEventChannel != null)
            buttonEventChannel.AddListener(Open);
        if (outpressurePlateEventChannel != null)
            outpressurePlateEventChannel.AddListener(Close);

    }
    void OnDisable()
    {
        if (buttonEventChannel != null)
            buttonEventChannel.RemoveListener(Open);
        if (outpressurePlateEventChannel != null)
            outpressurePlateEventChannel.RemoveListener(Close);


    }
    // Update is called once per frame
    void Open()
    {
        bc2d.enabled = false;
        sr.enabled = false;
    }
    void Close()
    {
        bc2d.enabled = true;
        sr.enabled = true;
    }
}
