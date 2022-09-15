using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.AddHealth(HealthValue);
            Destroy(gameObject);
        }
    }
}
