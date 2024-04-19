using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    Rigidbody rb;
    PowerUpManager ppManager;

    public float jumpForce = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float stompSpeed = 5f;
    private void Start()
    {
        ppManager = GetComponent<PowerUpManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Dash();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Stomp();
        }
    }
    public void Jump()
    {
        if (ppManager.jumps >= 1)
        {
            ResetVelocity();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ppManager.jumps--;
        }
        else
        {
            Debug.Log("No Jumps Available");
        }
    }
    public void Dash()
    {
        if (ppManager.dashes >= 1)
        {
            ResetVelocity();
            rb.velocity += transform.forward * dashSpeed;
            ppManager.dashes--;
        }
        else
        {
            Debug.Log("No Dashes Available");
        }
    }
    public void Stomp()
    {
        if (ppManager.stomps >= 1)
        {
            ResetVelocity();
            rb.velocity += Vector3.down * stompSpeed;
            ppManager.stomps--;
        }
        else
        {
            Debug.Log("No Stomps Available");
        }
    }
    private void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
