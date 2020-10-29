using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    Transform thisTransform;
    public bool readyAttack;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        readyAttack = true;
    }

    void Update()
    {
        //패턴 1 준비
        if (transform.position.x < 12.5 && readyAttack)
            transform.position = new Vector2(transform.position.x + 0.025f, transform.position.y);
        else readyAttack = false;

        //다시 돌아오는 레이케스트 (공용)
        Debug.DrawRay(new Vector2(20, -1), Vector2.left, new Color(0, 1, 0));
        RaycastHit2D combackRay = Physics2D.Raycast(new Vector2(20, -1), Vector3.left, 1, LayerMask.GetMask("Boss Attack Arm"));

        //아래로 내려감
        if (combackRay.collider != null)
        {
            transform.position = new Vector2(4.37f, -6);
        }

        //위로 서서히 올라옴
        if (transform.position.y < 0.16)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.025f);
        } else readyAttack = true;
    }
}
