using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;
    private Transform _playerTransform;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
    }

    
}
