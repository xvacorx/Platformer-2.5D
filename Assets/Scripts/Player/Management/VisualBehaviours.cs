using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class VisualBehaviours : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    PlayerMovement playerMove;
    PowerUpActions ppActions;

    public Vector3 stompRotation;

    public GameObject collectEffect;

    public GameObject stompEffect;
    public GameObject dashingEffect;
    public GameObject stompingEffect;

    ParticleSystem dashingParticleSystem;
    ParticleSystem stompingParticleSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
        ppActions = GetComponent<PowerUpActions>();

        dashingParticleSystem = dashingEffect.GetComponent<ParticleSystem>();
        stompingParticleSystem = stompingEffect.GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        BasicMovements();
        DashingEffect();
        StompingEffect();
    }
    void DashingEffect()
    {
        var emissionModule = dashingParticleSystem.emission;
        emissionModule.enabled = ppActions.isDashing;
    } // Dash Effect
    void StompingEffect()
    {
        var emissionModule = stompingParticleSystem.emission;
        emissionModule.enabled = ppActions.isStomping;
    } // Stomp Effect
    public void StompEffect()
    {
        Quaternion rotationQuat = Quaternion.Euler(stompRotation);

        GameObject stomp = Instantiate(stompEffect, transform.position - Vector3.up * 0.5f, rotationQuat);
        Destroy(stomp, 2f);
    } // Stomp Explosion
    void BasicMovements()
    {
        {
            if (playerMove.actualMovement != Vector3.zero)
            {
                animator.SetFloat("X Velocity", Math.Abs(playerMove.horizontal));
            }
        } // Running animation
        {
            animator.SetFloat("Y Velocity", rb.velocity.y);

            if (rb.velocity.y >= 1 || rb.velocity.y <= -1) { animator.SetBool("IsJumping", true); }
            else { animator.SetBool("IsJumping", false); }
        } // Jumping and falling animation
    } // Running, Idle and Jumping

    public void CollectableEffect()
    {
        GameObject collect = Instantiate(collectEffect, transform.position, Quaternion.identity);
        Destroy(collect, 3f);
    }
}