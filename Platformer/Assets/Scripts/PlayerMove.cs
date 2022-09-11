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

    public float MaxSpeed;

    public Transform CapsuleTransform;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Grounded == false)
        {
            CapsuleTransform.localScale = Vector3.Lerp(CapsuleTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            CapsuleTransform.localScale = Vector3.Lerp(CapsuleTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }

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
        float speedMultiplier = 1f;//���������� ����� ��� ����������� �������� � ������
        if(Grounded == false)
        {
            speedMultiplier = 0.2f;
        }


        //�.�. �������� ������ � ������� ����� �� ������������ ������ ����������� �� ������������ ��������
        if(Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
        {
            speedMultiplier = 0f;
        } 
        if(Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
        {
            speedMultiplier = 0f;
        }

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);

        if (Grounded)//���� ����� �� ����� -> ��������� ���� �������������
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
        }
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
