using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple3DMovement : MonoBehaviour
{
    float Forward, Right;
    public int MoveSpeed, JumpForce;
    Rigidbody rb;
    bool IsOnGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && IsOnGround) // fix smooth and snappy movement in settings, gonna find it and write it down for you
        {
            IsOnGround = false;
            Invoke("OnGround", 0.8f);
            rb.AddForce(Vector3.up * JumpForce);
        }

        Forward = Input.GetAxis("Vertical");
        Right = Input.GetAxis("Horizontal");

        Vector2 norm = new Vector2(Right, Forward).normalized * MoveSpeed; // nothing to see here, move along

        rb.velocity = new Vector3(norm.x, rb.velocity.y, norm.y);
       // rb.AddForce(new Vector3(Right, 0, Forward).normalized * MoveSpeed);
    }

    void OnGround()
    {
        IsOnGround = true;
    }
}
