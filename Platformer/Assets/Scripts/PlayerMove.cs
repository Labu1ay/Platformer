using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Rigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
            }
        }
    }
    void FixedUpdate()
    {
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0f, 0f, ForceMode.VelocityChange);

        Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angleToNormal = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angleToNormal < 45f)
            {
                Grounded = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
