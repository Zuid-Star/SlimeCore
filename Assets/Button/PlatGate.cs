using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatGate : MonoBehaviour
{
    private TilemapCollider2D tc2d;
    private TilemapRenderer tr; // 修改类型为 TilemapRenderer
    [SerializeField] VoidEventChannel buttonEventChannel;
    [SerializeField] VoidEventChannel outpressurePlateEventChannel;

    void Start()
    {
        tc2d = GetComponent<TilemapCollider2D>();
        tr = GetComponent<TilemapRenderer>(); // 获取 TilemapRenderer 组件
    }

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

    void Open()
    {
        tc2d.enabled = false;
        tr.enabled = false; // 操作 TilemapRenderer 的 enabled 属性
    }

    void Close()
    {
        tc2d.enabled = true;
        tr.enabled = true; // 操作 TilemapRenderer 的 enabled 属性
    }
}