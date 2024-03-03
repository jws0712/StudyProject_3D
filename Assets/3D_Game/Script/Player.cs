using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

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
        MyInput();
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
}
