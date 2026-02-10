using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //表明当前状态
    IState currentState;

    protected Dictionary<System.Type, IState> stateTable;
    void Update()
    {
        currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        currentState.Exit();
        //currentState = newState;
        //currentState.Enter();
        //可以用switchOn代替
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newStateType)
    {
        currentState.Exit();
        //currentState = newState;
        //currentState.Enter();
        //可以用switchOn代替
        SwitchOn(stateTable[newStateType]);
    }
}
