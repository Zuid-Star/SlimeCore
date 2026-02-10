using UnityEngine;

public class BombRange : MonoBehaviour
{
    public float explosionRadius = 5f;    // 爆炸影响范围
    public float explosionForce = 1000f; // 爆炸力强度

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 获取爆炸中心位置
        Vector2 explosionPosition = transform.position;

        // 检测爆炸范围内的所有碰撞体
        Collider2D[] affectedColliders = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);

        foreach (Collider2D collider in affectedColliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 计算物体到爆炸中心的向量
                Vector2 direction = (Vector2)collider.transform.position - explosionPosition;

                // 计算距离并标准化方向
                float distance = direction.magnitude;
                Vector2 normalizedDirection = direction.normalized;

                // 根据距离衰减爆炸力（距离越近力量越大）
                float forceMultiplier = 1 - Mathf.Clamp01(distance / explosionRadius);
                float appliedForce = explosionForce * forceMultiplier;

                // 施加反向的爆炸力
                rb.AddForce(-normalizedDirection * appliedForce, ForceMode2D.Impulse);
            }
        }

        // 销毁炸弹自身
        Destroy(gameObject);
    }

   
}