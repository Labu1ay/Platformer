using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    public Rigidbody Rigidbody;
    void FixedUpdate()
    {
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0f, 0f, ForceMode.VelocityChange);

        Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
    }
}
