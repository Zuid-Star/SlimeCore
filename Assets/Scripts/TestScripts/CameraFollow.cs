using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 minPosition;
    public Vector2 maxPosition;


    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                // 限制目标位置在设定的范围内
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                // 平滑插值移动相机
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }

    // 可视化检测区域（会自动适配缩放）
    private void OnDrawGizmosSelected()
    {
        // 计算其他两个角点
        Vector3 leftTop = new Vector2(minPosition.x, maxPosition.y);
        Vector3 rightBottom = new Vector2(maxPosition.x, minPosition.y);

        // 绘制四条边
        Gizmos.DrawLine(minPosition, leftTop);
        Gizmos.DrawLine(leftTop, maxPosition);
        Gizmos.DrawLine(maxPosition, rightBottom);
        Gizmos.DrawLine(rightBottom, minPosition);
    }
}