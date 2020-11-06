using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    Transform thisTransform, playerOldTransform;
    Animator anim;
    public Animator explosionAnim;
    public GameObject Player;
    public bool readyAttack, comback, playerOldTransformChecked, moved;
    private int pattern;
    public float rotateSpeed;
    private float playerX, playerY;

    void Start()
    {
        Player = GameObject.Find("Player");
        thisTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        readyAttack = true;
        comback = false;
        playerOldTransformChecked = false;
        moved = false;
        pattern = 0;
    }

    void Update()
    {
        if (pattern == 0)
        {
            pattern = Random.Range(1, 3);
            Debug.Log(pattern);
        }

        //패턴 1
        if (pattern == 1){
            //패턴 1 준비
            if (transform.position.x < 12.3 && readyAttack)
                transform.position = new Vector2(transform.position.x + 0.025f, transform.position.y);
            else readyAttack = false;

            //다시 돌아오는 레이케스트 (공용)
            Debug.DrawRay(new Vector2(10, -1), Vector3.up, new Color(2, 0, 0));
            RaycastHit2D combackRay = Physics2D.Raycast(new Vector2(10, -1), Vector3.up, 1, LayerMask.GetMask("Boss Attack Arm Left"));

            //아래로 내려감
            if (combackRay.collider != null)
            {
                transform.position = new Vector2(4.37f, -6);
            }

            Debug.DrawRay(new Vector2(20, -1), Vector3.left, new Color (2, 1, 2));
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
                pattern = 0;
            }

        }
        if (pattern == 2) // 패턴 2
        {
            anim.SetBool("Pattern2", true);
            //왼팔 야무지게 들어 올리는 모션
            if (transform.rotation.z > -0.8660254 && readyAttack)
            {
                transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.015f);
            }
            else
            {
                readyAttack = false;
            }
            
            /*실시간으로 내려찍는 모션
            if (transform.position.y > -1.3)
            {
                transform.position = new Vector2(transform.position.x + ((Player.transform.position.x - transform.position.x) / 50), transform.position.y + (-1.3f / 500));
            }*/
            //플레이어 순간 위치 저장
            if (!playerOldTransformChecked && !readyAttack && !moved)
            {
                playerOldTransform = Player.transform;
                playerX = playerOldTransform.position.x;
                playerY = playerOldTransform.position.y;
                playerOldTransformChecked = true;
            }

            //X축먼저, Y축 나중 이동 모션
            if (playerOldTransformChecked)
            {
                if (Mathf.Abs(playerX - transform.position.x) > 0.1)
                {
                    transform.position = new Vector2(transform.position.x + ((playerX - transform.position.x) / 50), transform.position.y);
                }
                else if (-1.5 < transform.position.y)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + (-1.3f / 20));
                    if (transform.rotation.z < -0.5150381)
                    {
                        
                        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed * 1.5f, Space.Self);
                    } else explosionAnim.SetBool("Boom", true);
                }
                else if (-1.5 > transform.position.y && transform.position.y > -1.6)
                {
                    explosionAnim.SetBool("Boom", false);
                    transform.position = new Vector2(transform.position.x, transform.position.y + (-1.3f / 2000));                    
                }
                else
                {
                    playerOldTransformChecked = false;
                    moved = true;
                }
            }

            if (!readyAttack && moved)
            {
                if (transform.rotation.z < 0.06391054 || Mathf.Abs(transform.position.x - 4.37f) > 0.01 || Mathf.Abs(transform.position.y - 0.16f) > 0.01)
                {
                    if(transform.rotation.z < 0.06391054)
                        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
                    if (Mathf.Abs(transform.position.x - 4.37f) > 0.01)
                        transform.position = new Vector2(transform.position.x + (4.37f - transform.position.x) / 50, transform.position.y);
                    if (Mathf.Abs(transform.position.y - 0.16f) > 0.01)
                        transform.position = new Vector2(transform.position.x, transform.position.y + (0.16f / 20));
                }
                else
                {
                    anim.SetBool("Pattern2", false);
                    pattern = 0;
                    readyAttack = true;
                    moved = false;
                }
            }
        }
    }
}
