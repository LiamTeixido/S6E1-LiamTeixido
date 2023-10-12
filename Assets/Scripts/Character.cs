using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float moveSpeed;
    protected Rigidbody rb;
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        MoveCharacter();
    }


    protected virtual void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = moveVelocity;
    }
}
