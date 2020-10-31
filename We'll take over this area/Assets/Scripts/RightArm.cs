using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    Transform thisTransform;
    public bool start;
    public bool readyAttack, comback;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        start = false;
        readyAttack = true;
        comback = false;
    }

    void Update()
    {
        //레이케스트
        Debug.DrawRay(new Vector2(-20, 0), Vector3.right + Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(-20, 0), Vector3.right + Vector3.down, 1, LayerMask.GetMask("Boss Attack Arm Left"));

        //레이히트시 시작 알림
        if (rayHit.collider != null && !start)
        {
            Debug.Log("Hit");
            start = true;
        }
        //패턴 1 준비
        if (transform.position.x > -12.5 && start && readyAttack)
        {
            transform.position = new Vector2(transform.position.x - 0.025f, transform.position.y);
        }
        else if(start)
        {
            start = false;
            readyAttack = false;
        }

        //다시 돌아오는 레이케스트 (공용)
        Debug.DrawRay(new Vector2(-10, -1), Vector3.up, new Color(2, 0, 0));
        RaycastHit2D combackRay = Physics2D.Raycast(new Vector2(-10, -1), Vector3.up, 1, LayerMask.GetMask("Boss Attack Arm Right"));

        //아래로 내려감
        if (combackRay.collider != null)
        {
            transform.position = new Vector2(0.27f, -6);
        }


        Debug.DrawRay(new Vector2(20, -1), Vector3.left, new Color(2, 1, 2));
        RaycastHit2D upRay = Physics2D.Raycast(new Vector2(20, -1), Vector3.left, 1, LayerMask.GetMask("Boss Attack Arm Right"));

        if (upRay.collider != null)
        {
            comback = true;
        }

        //위로 서서히 올라옴
        if (transform.position.y < 0.16 && comback)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.025f);
        }
        else if (comback)
        {
            comback = false;
            readyAttack = true;
        }
    }
}
