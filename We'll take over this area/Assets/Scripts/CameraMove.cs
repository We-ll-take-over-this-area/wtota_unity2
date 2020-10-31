using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject Player;
    public float limitX;

    void Awake()
    {
        Player = GameObject.Find("Player");
        Application.targetFrameRate = 100;
    }

    void Update()
    {
        if(Player.transform.position.x > limitX)
            transform.position = new Vector3(limitX, 0, -10);
        else if(Player.transform.position.x < (-1)*limitX)
            transform.position = new Vector3((-1)*limitX, 0, -10);
        else
            transform.position = new Vector3(Player.transform.position.x, 0, -10);
    }

    private void FixedUpdate()
    {

    }
}
