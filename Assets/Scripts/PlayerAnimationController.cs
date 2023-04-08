using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player.rb.velocity.x != 0) anim.SetBool("isRun", true);
        else anim.SetBool("isRun", false);
    }
}
