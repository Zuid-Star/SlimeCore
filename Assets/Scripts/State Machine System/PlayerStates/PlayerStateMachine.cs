using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //该数组用于存储所有的状态
    public PlayerState[] states;

    Animator animator;
    PlayerInput input;
    Rigidbody2D playerRigidbody2D;
    Transform playerTransform;
    PlayerController playerController;

     void Awake()
    {
        //初始化需要的组件
        animator = GameObject.Find("Body/Animation/Slime").GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerController = GetComponent<PlayerController>();


        foreach(PlayerState state in states)
        {
            //初始化状态类
            state.Initialize(animator, this, input, playerRigidbody2D,playerTransform,playerController);
            //将初始化好的状态类存储在stateTable字典中，并通过对应的type建立一一对应关系
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerStateIdle)]);
    }

}
