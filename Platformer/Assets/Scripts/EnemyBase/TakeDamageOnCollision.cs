using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
    }
}
