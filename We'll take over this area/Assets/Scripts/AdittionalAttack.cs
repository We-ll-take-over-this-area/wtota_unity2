using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdittionalAttack : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRenderer, playerSR;
    Collider2D thisCollider;
    GameObject Player;
    Transform playerTrans;
    bool isAttacking;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<BoxCollider2D>();
        Player = GameObject.Find("Player");
        isAttacking = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("isAttacking", true);
            isAttacking = true;
            Invoke("doFalse", 0.25f);
        }
        /*else
        {
            anim.SetBool("isAttacking", false);
        }*/

    }

    private void FixedUpdate()
    {
        playerTrans = Player.transform;
        playerSR = Player.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = playerSR.flipX;

        if (isAttacking)
        {
            Invoke("Te", 0.0025f);
        } else
        {
            transform.position = new Vector2(0, 8);
        }

    }

    void Te()
    {
        if (!playerSR.flipX)
        {
            transform.position = new Vector2(playerTrans.position.x + 1, playerTrans.position.y);
            thisCollider.offset = new Vector2(-0.2651251f, -0.07824254f);
        }
        else if (playerSR.flipX)
        {
            transform.position = new Vector2(playerTrans.position.x - 1, playerTrans.position.y);
            thisCollider.offset = new Vector2(0.26f, -0.07824254f);
        }
    }
    
    void doFalse()
    {
        isAttacking = false;
    }
}
