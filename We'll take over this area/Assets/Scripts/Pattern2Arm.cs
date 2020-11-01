using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Arm : MonoBehaviour
{
    Animator anim;
    public Animator leftArmAnim;
    bool pattern2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftArmAnim.GetBool("Pattern2") == true)
        {
            anim.SetBool("Pattern2_", true);
        } else if (leftArmAnim.GetBool("Pattern2") == false)
        {
            anim.SetBool("Pattern2_", false);
        }
    }
}
