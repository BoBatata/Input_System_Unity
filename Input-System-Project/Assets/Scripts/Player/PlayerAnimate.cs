using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{


    void Update()
    {
        AnimationHandler();
    }

    private void AnimationHandler()
    {
        bool isRunningAnimation = PlayerMovement.instance.animator.GetBool("isRunning");
        bool isRunning = PlayerMovement.instance.isRunning;

        bool isJumpingAnimation = PlayerMovement.instance.animator.GetBool("isJumping");
        bool isJumping = PlayerMovement.instance.isJumping;

        if (isRunning && isRunningAnimation == false)
        {
            PlayerMovement.instance.animator.SetBool("isRunning", true);
        }
        else if (!isRunning && isRunningAnimation == true)
        {
            PlayerMovement.instance.animator.SetBool("isRunning", false);
        }

        if (isJumping && isJumpingAnimation == false) 
        {
            PlayerMovement.instance.animator.SetBool("isJumping", true);
        }
        else if(!isJumping && isJumpingAnimation == true)
        {
            PlayerMovement.instance.animator.SetBool("isJumping", false);
        }
    }
}
