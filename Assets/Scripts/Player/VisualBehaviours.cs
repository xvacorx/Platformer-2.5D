using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBehaviours : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    PlayerMovement playerMove;
    PowerUpActions ppActions;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
        ppActions = GetComponent<PowerUpActions>();

    }
    private void Update()
    {
        BasicMovements();
    }
    private void BasicMovements()
    {
        {
            if (playerMove.actualMovement != Vector3.zero)
            {
                animator.SetFloat("X Velocity", Math.Abs(playerMove.horizontal));
            }
        } // Running animation
        {
            animator.SetFloat("Y Velocity", rb.velocity.y);

            if (rb.velocity.y >= 1 || rb.velocity.y <= -1)
            {
                animator.SetBool("IsJumping", true);
            }
            else
            {
                animator.SetBool("IsJumping", false);
            }
        } // Jumping and falling animation
    }
}