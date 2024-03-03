using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask WhatIsGround;
    bool grounded;

    public Transform PlayerPos;

    float Hinput;
    float Vinput;

    Vector3 moveDir;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);

        MyInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        SpeedCon();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        Hinput = Input.GetAxisRaw("Horizontal");
        Vinput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = PlayerPos.forward * Vinput + PlayerPos.right * Hinput;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedCon()
    {
        Vector3 flaVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flaVel.magnitude > moveSpeed)
        {
            Vector3 limiteVel = flaVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limiteVel.x, rb.velocity.y, limiteVel.z);
        }
    }
}
