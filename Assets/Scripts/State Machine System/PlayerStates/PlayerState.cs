using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput playerInput;
    protected Rigidbody2D playerRigidbody;
    protected Transform playerTransform;
    protected PlayerController playerController;

    protected float currentSpeed;

    //初始化状态，引入stateMachine是为了可以再状态脚本中对状态机进行控制
    public void Initialize(Animator animator,PlayerStateMachine stateMachine,PlayerInput input,Rigidbody2D playerRigidbody,Transform playerTransform, PlayerController playerController)
    {
        this.animator = animator;      
        this.stateMachine = stateMachine;
        this.playerInput = input;
        this.playerRigidbody = playerRigidbody;
        this.playerTransform = playerTransform;
        this.playerController = playerController;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
       
    }
}
