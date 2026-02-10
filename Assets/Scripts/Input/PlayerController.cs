using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D playerRigidbody;
    Transform playerTransform;
    public Transform Animation;
    public Transform bodyTransform;
    public MouseTracking mouseTracking;
    //判断是否在地面上
    private GroundDetector groundDetector;
    public bool IsGrounded => groundDetector.IsGround;

    public AudioSource VoicePlayer { get; private set; }


    //有关运动的可变更参数
    public float moveSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 5f;
    public float jumpHight = 10f;
    public float lowJumpMultiplier = 2f;
    public float fallMultiplier = 4f;

    //记录可分裂粘液次数
    public int volum = 1;

    //判断是否处于吞噬状态
    public bool isEat => playerInput.IsPressedEat;

    private float deltaSpeed;
    private float controlSpeed = 0;
    private Vector2 deltaSpeed1v;
    public float CurrentSpeed => playerRigidbody.velocity.x;

    //粒子相关组件
    public ParticleSystem moveParticle;
    public ParticleSystem jumpParticle;
    public GameObject deathParticle;

    void Awake()
    {
        moveParticle = GameObject.Find("Body/Animation/MoveParticle").GetComponent<ParticleSystem>();
        jumpParticle = GameObject.Find("Body/Animation/JumpParticle").GetComponent<ParticleSystem>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        VoicePlayer= GetComponentInChildren<AudioSource>();
    }

    void Start()
    {
        playerInput.EnableGamePlayInputs();
        //绑定暂停事件
        playerInput.playerInputActions.Ui.Pause.performed += playerInput.OnPause;
        ChangeVolume();
    }

    //控制加速过程
    public float PlayerMoveAceeleration(float currentSpeed)
    {
        controlSpeed = currentSpeed;
        deltaSpeed = currentSpeed - Mathf.MoveTowards(controlSpeed, moveSpeed * playerInput.Axisx, acceleration * Time.deltaTime);
        return currentSpeed -= deltaSpeed;
    }

    //控制减速过程
    public float PlayerMoveDeceleration(float currentSpeed)
    {
        controlSpeed = currentSpeed;
        deltaSpeed = currentSpeed - Mathf.MoveTowards(controlSpeed, 0, acceleration * Time.deltaTime);
        return currentSpeed -= deltaSpeed;

    }

    //通过检测是否输入方向键来判断执行 加速 还是 减速
    public float PlayerHowToMove(float currentSpeed)
    {
        if(playerInput.IsMove)
        {
            return currentSpeed = PlayerMoveAceeleration(currentSpeed);
        }
        else
        {
            return currentSpeed = PlayerMoveDeceleration(currentSpeed);
        }
    }

    //控制双向平台的下落
    public void PlayerDown()
    {
        if (playerInput.Axisy < 0) 
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            Invoke("ChangeLayer", 0.3f);
            
        }
    }
    //用于改变对象layer
    public void ChangeLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    

    //控制移动
    public void PlayerMove(float currentSpeed)
    {   
        deltaSpeed1v = playerRigidbody.velocity - new Vector2(currentSpeed, playerRigidbody.velocity.y);


        playerRigidbody.velocity -= deltaSpeed1v;

        if (playerInput.Axisx < 0)
            Animation.localScale = new Vector3(-1, 1, 1);
        else if (playerInput.Axisx > 0)
            Animation.localScale = new Vector3(1, 1, 1);

        PlayerDown();
    }

    //增加重力，使得上升高度变低
    public void PlayerUpGravity()
    {
        playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
    }

    //控制下落速度
    public void PlayerFallGravity()
    {
        playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    }

    //根据可分裂次数改变体积
    public void ChangeVolume()
    {
        bodyTransform.localScale = new Vector3(1.2f + 0.3f * (volum - 1), 1.2f + 0.3f * (volum - 1), 1f);
    }

    public void Death()
    {
        Instantiate(deathParticle,this.transform.position, Quaternion.Euler(transform.eulerAngles));
        Destroy(this.gameObject);
    }

}
