using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float AttackPeriod = 7f;
    public Animator RabbitAnim;
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > AttackPeriod)
        {
            _timer = 0f;
            RabbitAnim.SetTrigger("Attack");
        }
    }
}
