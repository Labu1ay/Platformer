using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(DamageValue);
        }
    }
}
