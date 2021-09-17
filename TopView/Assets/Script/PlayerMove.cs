using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float Speed = 5;
    Rigidbody2D rigid; 
    float h;
    float v;
    bool isHorizonMove;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {   //move value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        //check button down & up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //check horizontal move
        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;

            //animation
        anim.SetInteger("Haxis", (int)h);
        anim.SetInteger("Vaxis", (int)v);

        
    }

    void FixedUpdate()
    {   
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v); ; 
        rigid.velocity = moveVec * Speed; 
    }

}
