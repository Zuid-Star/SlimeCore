using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracking : MonoBehaviour
{
    public GameObject mucus;
    public GameObject slimeBody;
    public Transform mouth1;
    public Transform mouth2;
    public float fixedSpeed;
    public float fixedSpeed2;

    public Camera cam;

    private Vector3 mousePos;
    private Vector2 gunDirection;
    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponentInParent<Rigidbody2D>();
        if (playerRigidbody == null)
        {
            Debug.LogError("父对象 Player 未找到 Rigidbody2D 组件！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gunDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void Shoot()
    {
        Instantiate(mucus, mouth1.position, Quaternion.Euler(transform.eulerAngles));

        float radians = -transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction2 = new Vector2(-Mathf.Cos(radians), Mathf.Sin(radians));
        playerRigidbody.velocity = direction2 * fixedSpeed;
    }

    public void CoreShoot()
    {
        Instantiate(slimeBody, mouth2.position, Quaternion.Euler(transform.eulerAngles));

        float radians = -transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction2 = new Vector2(-Mathf.Cos(radians), Mathf.Sin(radians));
        playerRigidbody.velocity = -direction2 * fixedSpeed2;
    }
}
