using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    Rigidbody rb;
    PowerUpManager ppManager;
    VisualBehaviours visual;

    public float jumpForce = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float stompSpeed = 5f;

    public bool isDashing = false;
    public bool isStomping = false;

    public bool stompEnabled = false;

    private void Start()
    {
        visual = GetComponent<VisualBehaviours>();
        ppManager = GetComponent<PowerUpManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Dash();
        }
        if (Input.GetButtonDown("Fire1") && stompEnabled)
        {
            Stomp();
        }
        if (isDashing)
        {
            StartCoroutine(ResetDashingAfterDelay(dashDuration));
        }
        if (isDashing) { rb.useGravity = false; }
        if (isDashing == false) { rb.useGravity = true; }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isStomping) { visual.StompEffect(); }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            stompEnabled = false;
            isStomping = false;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            stompEnabled = true;
        }
    }
    public void Jump()
    {
        if (ppManager.jumps >= 1)
        {
            ResetVelocity();
            stompEnabled = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ppManager.jumps--;
        }
        else
        {
            ppManager.jumps = 0;
            //Debug.Log("No Jumps Available");
        }
    }
    public void Dash()
    {
        if (ppManager.dashes >= 1)
        {
            ResetVelocity();
            stompEnabled = true;
            isDashing = true;
            rb.velocity += transform.right * dashSpeed;
            ppManager.dashes--;
        }
        else
        {
            ppManager.dashes = 0;
            //Debug.Log("No Dashes Available");
        }
    }
    public void Stomp()
    {
        if (ppManager.stomps >= 1)
        {
            ResetVelocity();
            isStomping = true;
            rb.velocity += Vector3.down * stompSpeed;
            ppManager.stomps--;
        }
        else
        {
            ppManager.stomps = 0;
            //Debug.Log("No Stomps Available");
        }
    }
    IEnumerator ResetDashingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDashing = false;
    }

    private void ResetVelocity()
    {
        isDashing = false;
        isStomping = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    } // Sets velocity to 0
    public bool IsDashing()
    {
        return isDashing;
    }

    public bool IsStomping()
    {
        return isStomping;
    }
}