using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CactusDamage : MonoBehaviour
{
    public int damageAmount = 20; // Amount of damage the cactus deals

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collided
        {
            AlexHealth alexHealth = other.GetComponent<AlexHealth>();
            if (alexHealth != null)
            {
                alexHealth.TakeDamage(damageAmount); // Apply damage to health
            }
        }
    }
}