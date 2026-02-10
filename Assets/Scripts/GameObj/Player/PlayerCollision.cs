using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private PlayerController playerController;
    private void Start()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        playerController = GetComponent<PlayerController>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mucus" )
        {
            if(playerController.volum != 0 && playerController.isEat)
            {
                //collision.gameObject.tag = "Untagged";
                playerController.volum += (collision.gameObject.GetComponent<Mucus>()).volum;
                playerController.ChangeVolume();
            }
            else if(playerController.volum == 0)
            {
                //collision.gameObject.tag = "Untagged";
                playerController.volum += (collision.gameObject.GetComponent<Mucus>()).volum;
                playerController.ChangeVolume();
                Destroy(collision.gameObject);
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mucus")
        {
            if (playerController.volum != 0 && playerController.isEat)
            {
                //collision.gameObject.tag = "Untagged";
                playerController.volum += (collision.gameObject.GetComponent<Mucus>()).volum;
                playerController.ChangeVolume();
            }
            else if (playerController.volum == 0)
            {
                //collision.gameObject.tag = "Untagged";
                playerController.volum += (collision.gameObject.GetComponent<Mucus>()).volum;
                playerController.ChangeVolume();
                Destroy(collision.gameObject);
            }
        }
    }
}
