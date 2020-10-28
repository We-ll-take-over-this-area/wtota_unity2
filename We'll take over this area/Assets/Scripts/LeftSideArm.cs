using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideArm : MonoBehaviour
{
    Transform thisTransform;
    Collider2D thisCollider;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        thisCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left + Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.left + Vector3.up, 1, LayerMask.GetMask("Boss arm"));
        if (rayHit.collider != null)
        {
            Debug.Log("Contact");
            if (transform.position.x > -13.5)
                transform.position = new Vector2(transform.position.x - 0.075f, transform.position.y);
        }
    }
}
