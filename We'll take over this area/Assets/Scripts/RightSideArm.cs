using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideArm : MonoBehaviour
{
    Transform thisTransform;
    Collider2D thisCollider;
    public bool start;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        thisCollider = GetComponent<Collider2D>();
        start = false;
    }

    void Update()
    {
        //레이케스트
        Debug.DrawRay(transform.position, Vector3.right + Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.right + Vector3.up, 1, LayerMask.GetMask("Boss arm"));

        //레이히트시 시작 알림
        if (rayHit.collider != null && !start)
        {
            start = true;
        }

        //패턴 1 준비
        if (transform.position.x < 20 && start)
        {
            transform.position = new Vector2(transform.position.x + 0.075f, transform.position.y);
        }
        else
        {
            start = false;
        }
    }
}
