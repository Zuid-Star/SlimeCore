using UnityEngine;

public class PopMucus : MonoBehaviour
{
    public Mucus dieMucus;
    public float topThreshold = 0.1f;    // 上端识别阈值
    public float positionCheckDuration = 0.5f; // 位置检测持续时间

    private Rigidbody2D rb2d;
    private Rigidbody2D playerrb;
    private BoxCollider2D bc2d;
    private PlayerController collisionPlayer;
    private bool enablePositionCheck = true;

    public float fixedSpeed;

    [SerializeField] AudioClip pickUpSFX;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        //GameObject player = GameObject.FindWithTag("Player");
        //if(player != null)
        //{
        //    playerrb = player.GetComponent<Rigidbody2D>();
        //}
        Invoke("DisablePositionCheck", positionCheckDuration);
    }



    private void DisablePositionCheck()
    {
        enablePositionCheck = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionPlayer = collision.gameObject.GetComponent<PlayerController>();
        playerrb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag != "Player") return;

        // 当启用位置检测时进行碰撞点验证
        if (enablePositionCheck == true && collisionPlayer.volum != 0)
        {
            bool isTopCollision = false;
            float topY = bc2d.bounds.max.y;

            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.point.y >= topY - topThreshold)
                {
                    isTopCollision = true;
                    break;
                }
            }
            if (!isTopCollision) return;
        }

        
        if (collisionPlayer != null && !collisionPlayer.isEat)
        {
            collisionPlayer.GetComponent<StateMachine>().SwitchState(typeof(PlayerStateFloat));
            playerrb.velocity = Vector3.up * fixedSpeed;
            rb2d.gravityScale = 1f;
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            Vector3 spawnPosition = playerrb.position;
            spawnPosition.y -= 1.0f;
            if (!(collisionPlayer.volum == 0 && !collisionPlayer.isEat))
            {
                Instantiate(dieMucus, spawnPosition, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }


}