using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeLogo : MonoBehaviour
{
    public List<GameObject> mucuses;
    public List<string> animationClip;
    private int index;
    public PlayerInput playerInput;
    public MouseTracking mouseTracking;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        index = 0;
        playerInput.EnableGamePlayInputs();
        playerInput.playerInputActions.GamePlay.Scroll.performed += ChangeMucus;
    }


    private void ChangeMucus(InputAction.CallbackContext context)
    {
        if (playerInput.scolly > 0)
        {
            if (index < mucuses.Count-1)
            {
                index++;
            }
            else if (index >= mucuses.Count-1)
            {
                index = 0;
            }
        }
        else if (playerInput.scolly < 0)
        {
            if (0 < index)
            {
                index--;
            }
            else if (index <= 0)
            {
                index = mucuses.Count - 1;
            }
        }
        //根据索引切换道具和动画
        mouseTracking.mucus = mucuses[index];
        animator.Play(animationClip[index]);

    }

    private void OnDestroy()
    {
        // 防止空引用异常
        if (playerInput != null && playerInput.playerInputActions != null)
        {
            playerInput.playerInputActions.GamePlay.Scroll.performed -= ChangeMucus;
        }
    }
}
