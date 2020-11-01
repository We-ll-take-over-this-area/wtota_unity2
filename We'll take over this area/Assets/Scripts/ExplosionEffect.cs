using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    GameObject leftArm;
    Transform armTrans;

    // Start is called before the first frame update
    void Start()
    {
        leftArm = GameObject.Find("Left arm");
        armTrans = leftArm.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(armTrans.position.x - 0.5f, -1.25f);
    }
}
