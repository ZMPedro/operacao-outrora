using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Jump(bool isjumping)
    {
        anim.SetBool("jump", isjumping);
    }

    public void Move(float move)
    {
        anim.SetFloat("speed", Mathf.Abs(move));
    }
}
