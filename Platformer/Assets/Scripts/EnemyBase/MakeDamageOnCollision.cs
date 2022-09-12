using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int DamageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(DamageValue);
        }
    }
}
