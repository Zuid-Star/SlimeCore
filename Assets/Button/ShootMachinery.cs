using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootMachinery : MonoBehaviour
{
    [SerializeField] VoidEventChannel buttonEventChannel;
    [SerializeField] VoidEventChannel buttonEventChannels;

    [Header("发射设置")]
    public GameObject projectilePrefab;  // 要发射的预制体
    public Transform firePoint;         // 发射起始点
    public float fireInterval = 1f;     // 发射间隔（秒）
    public int fireCount = 5;           // 发射次数（0表示无限）
    public float fireAngle = 0f;        // 发射角度（度）
    public float projectileSpeed = 10f; // 速度参数
    public int projectilevolum = 1; // 粘液大小参数
    private int count1 = 0;
    private Coroutine fireRoutine;

    private void Start()
    {
        // 启动发射协程
        if (buttonEventChannel == null && buttonEventChannels == null)
        {
            fireRoutine = StartCoroutine(FireRoutine());
        }
    }

    private IEnumerator FireRoutine()
    {
        int count = 0;
        StarShootMucus mucusScript = projectilePrefab.GetComponent<StarShootMucus>();

        // 当fireCount设为0时无限循环
        while (fireCount <= 0 || count < fireCount)
        {
            mucusScript.speed = projectileSpeed;
            mucusScript.volum = projectilevolum;
            // 计算带角度的旋转
            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, fireAngle, 0);
            Instantiate(projectilePrefab, firePoint.position, rotation);
            count++;
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void OnEnable()
    {
        if (buttonEventChannel != null && count1 == 0)
        {
            buttonEventChannel.AddListener(Open);
            count1++;
        }
        if (buttonEventChannels != null)
        {
            buttonEventChannels.AddListener(Open);
        }
    }

    void OnDisable()
    {
        if (buttonEventChannel != null)
        {
            buttonEventChannel.RemoveListener(Open);
        }
        if (buttonEventChannels != null)
        {
            buttonEventChannels.RemoveListener(Open);
        }
        count1 = 0;
        if (fireRoutine != null)
        {
            StopCoroutine(fireRoutine);
            fireRoutine = null;
        }
    }

    void Open()
    {
        StartCoroutine(FireRoutine());
    }
}