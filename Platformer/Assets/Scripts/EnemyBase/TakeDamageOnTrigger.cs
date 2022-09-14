using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (DieOnAnyCollision)
        {
            if (other.isTrigger == false)
            {
                EnemyHealth.TakeDamage(10000);
            }
        }

        if (other.attachedRigidbody.gameObject.GetComponent<Bullet>())
        {
            Destroy(other.gameObject);
            EnemyHealth.TakeDamage(1);
        }

        

    }
}
