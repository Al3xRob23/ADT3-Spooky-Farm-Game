using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public int HealthRestored = 10;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void ConsumeItem()
    {
        //Eats food
        playerHealth.TakeDamage(-HealthRestored);
        Destroy(gameObject);
    }
}
