using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    public Vector3 actualMovement;
    public float horizontal;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        actualMovement = movement; horizontal = moveHorizontal;
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.Euler(0f, moveHorizontal > 0 ? 0f : 180f, 0f);
            rb.MoveRotation(newRotation);
        }
    }
}
