using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    Transform thisTransform;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (transform.position.x < 12.5)
            transform.position = new Vector2(transform.position.x + 0.025f, transform.position.y);

    }
}
