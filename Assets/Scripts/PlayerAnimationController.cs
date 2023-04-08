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
        if (player.isDead && !player.gameOver)
        {
            anim.SetTrigger("die");
            player.gameOver = true;
            return;
        }
        
        if (player.isTelekinetic && !player.isHurt)
        {
            anim.SetBool("isLookUp", true);
            return;
        }
        else anim.SetBool("isLookUp", false);
        
        if(player.rb.velocity.y != 0) anim.SetBool("isJump", true);
        else anim.SetBool("isJump", false);
        
        if (player.rb.velocity.x != 0 && player.isGrounded) anim.SetBool("isRun", true);
        else anim.SetBool("isRun", false);

        if (player.isHurt) anim.SetTrigger("hurt");
    }
}
