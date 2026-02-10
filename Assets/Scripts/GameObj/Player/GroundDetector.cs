using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [Header("地面检测参数")]
    [SerializeField] private Vector2 baseAreaSize = new Vector2(0.5f, 0.1f);  // 原始区域大小
    [SerializeField] private Vector2 baseOffset = new Vector2(0f, -0.5f);     // 原始偏移值
    [SerializeField] private LayerMask groundLayer;                           // 检测的地面层

    public bool IsGround { get; private set; }                                // 外部只读

    private Collider2D[] results = new Collider2D[1];                         // 缓存结果数组（1个足够，只判断是否接触）

    void FixedUpdate()
    {
        // 考虑对象世界缩放，计算缩放后的尺寸和偏移
        Vector2 scaledSize = Vector2.Scale(baseAreaSize, transform.lossyScale);
        Vector2 scaledOffset = Vector2.Scale(baseOffset, transform.lossyScale);

        // 中心点 = 对象位置 + 偏移
        Vector2 center = (Vector2)transform.position + scaledOffset;

        // 区域两个角点
        Vector2 halfSize = scaledSize * 0.5f;
        Vector2 pointA = center - halfSize;
        Vector2 pointB = center + halfSize;

        // 非分配式检测（零 GC）
        int count = Physics2D.OverlapAreaNonAlloc(pointA, pointB, results, groundLayer);
        IsGround = count > 0;
    }

    // 可视化检测区域（会自动适配缩放）
    private void OnDrawGizmosSelected()
    {
        Vector2 scaledSize = Vector2.Scale(baseAreaSize, transform.lossyScale);
        Vector2 scaledOffset = Vector2.Scale(baseOffset, transform.lossyScale);
        Vector2 center = (Vector2)transform.position + scaledOffset;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(center, scaledSize);
    }
}
