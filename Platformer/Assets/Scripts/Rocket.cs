using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float SpeedRotation;

    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        transform.rotation = Quaternion.LookRotation(toPlayer());
    }
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer(), Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * SpeedRotation);
    }
    Vector3 toPlayer()
    {
        return _playerTransform.position - transform.position;
    }
    
}
