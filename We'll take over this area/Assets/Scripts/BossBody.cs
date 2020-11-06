using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            OnDamaged();
            Debug.Log("Boss hit");
        }
    }
    void OnDamaged()
    {
        //피격시 레이어 변경(반투명 스프라이트 및 물리 무시)

        spriteRenderer.color = new Color( 0.5f, 0.5f, 0.5f, 1);


        Invoke("OffDamaged", 1.5f);
    }
    void OffDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
