using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun Pistol;

    public float MaxCharge = 3f;
    private float _currentCharge;
    private bool _isCharged;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Rigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Pistol.Shot();
                _isCharged = false;
                _currentCharge = 0f;
            }
        }
        else
        {
            _currentCharge += Time.deltaTime;
            if(_currentCharge >= MaxCharge)
            {
                _isCharged = true;
            }
        }
    }
}
