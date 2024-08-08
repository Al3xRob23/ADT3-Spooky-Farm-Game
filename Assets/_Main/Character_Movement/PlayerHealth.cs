using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	public Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.K))
		{
			TakeDamage(20);
		}
			
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            print("Your'e Dead");
            Time.timeScale = 0f;
        }
    }

	void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
			//currentHealth -= 10;
			Debug.Log("Enemy Detected");
			TakeDamage(10);
        }
    }
}
