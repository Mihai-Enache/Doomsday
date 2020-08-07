using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour
{
    private Animator anim;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool move = false;

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            move = true;
        }

        anim.SetBool("walking", move);
        
        move = Input.GetKey(KeyCode.C);
        anim.SetBool("claw_attack", move);

        move = Input.GetKey(KeyCode.F);
        anim.SetBool("flame_attack", move);

        move = Input.GetKey(KeyCode.B);
        anim.SetBool("basic_attack", move);

        move = Input.GetKey(KeyCode.Z);
        anim.SetBool("defend", move);

        move = Input.GetKey(KeyCode.Y);
        anim.SetBool("get_hit", move);

        move = Input.GetKey(KeyCode.X);
        anim.SetBool("die", move);
    }
}
