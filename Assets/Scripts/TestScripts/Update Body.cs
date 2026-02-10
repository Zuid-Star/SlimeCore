using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdateBody : MonoBehaviour
{


    public float scaleFactor = 1.1f;    // 贴图缩放倍数
    private BoxCollider2D boxCollider;  // 碰撞箱组件
    public int mucusCount;          // 粘液数量计数器
    public string targetTag = "mucus";    // 目标预制体标签
    public Transform bodyTransform;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mucusCount--;
            ScaleSub();
            Debug.Log($"粘液数量：{mucusCount}");
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            ScaleAdd();
            Destroy(other.gameObject); // 可选：销毁碰撞物体
            mucusCount++;
            Debug.Log($"粘液数量：{mucusCount}");
        }
    }

    void ScaleAdd()
    {
        // 应用缩放
        Vector3 currentScale = bodyTransform.localScale;
        bodyTransform.localScale = new Vector3(currentScale.x * scaleFactor,currentScale.y * scaleFactor,currentScale.z);
    }
    void ScaleSub()
    {
        // 应用缩放
        Vector3 currentScale = bodyTransform.localScale;
        bodyTransform.localScale = new Vector3(currentScale.x / scaleFactor, currentScale.y / scaleFactor, currentScale.z);
    }

}

