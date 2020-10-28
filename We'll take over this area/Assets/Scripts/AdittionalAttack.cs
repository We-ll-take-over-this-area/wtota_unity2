using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdittionalAttack : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRenderer, playerSR;
    GameObject Player;
    Transform playerTrans;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

    }

    private void FixedUpdate()
    {
        playerTrans = Player.transform;
        playerSR = Player.GetComponent<SpriteRenderer>();

        if (!playerSR.flipX)
        {
            transform.position = new Vector3(playerTrans.position.x + 1, playerTrans.position.y, 0);
        }
        else if (playerSR.flipX)
        {
            transform.position = new Vector3(playerTrans.position.x - 1, playerTrans.position.y, 0);
        }

        spriteRenderer.flipX = playerSR.flipX;
    }
}
