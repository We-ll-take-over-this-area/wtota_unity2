using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    Transform thisTransform;
    public bool start;
    public bool readyAttack;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        start = false;
        readyAttack = true;
    }

    void Update()
    {
        //레이케스트
        Debug.DrawRay(new Vector2(-20, 0), Vector3.right + Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(-20, 0), Vector3.right + Vector3.down, 1, LayerMask.GetMask("Boss Attack Arm"));

        //레이히트시 시작 알림
        if (rayHit.collider != null && !start)
        {
            start = true;
        }
        //패턴 1 준비
        if (transform.position.x > -12.5 && start && readyAttack)
        {
            transform.position = new Vector2(transform.position.x - 0.025f, transform.position.y);
        }
        else
        {
            start = false;
            readyAttack = false;
        }

        //다시 돌아오는 레이케스트 (공용)
        Debug.DrawRay(new Vector2(10, -1), Vector3.up, new Color(2, 0, 0));
        RaycastHit2D combackRay = Physics2D.Raycast(new Vector2(-10, -1), Vector3.up, 1, LayerMask.GetMask("Boss Attack Arm"));

        //아래로 내려감
        if (combackRay.collider != null)
        {
            transform.position = new Vector2(0.27f, -6);
        }

        //위로 서서히 올라옴
        if (transform.position.y < 0.19)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.025f);
        }
        else readyAttack = true;
    }
}
