using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMucus : MonoBehaviour
{
    public GameObject bombrange;
    public float bombtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ExplosionRange",bombtime);
    }

    void ExplosionRange()
    {
        Instantiate(bombrange, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
