using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Collider playerCollider;
    private SimpleFPSController fpsController;

    public GameObject deathScreen;

    private Coroutine biteRoutine;
    public bool isGrabbed;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        fpsController = GetComponent<SimpleFPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            print("Your'e Dead");
            Time.timeScale = 0f;
            deathScreen.GetComponent<DeathScreen>().ShowMenu();
        }
    }

    public void HandleAttackerDied()
    {
        if (biteRoutine == null) return;
        StopCoroutine(biteRoutine);
        // Let the player do stuff again.
        fpsController.enabled = true;
    }


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
			//currentHealth -= 10;
			Debug.Log("Enemy Detected");
            if (biteRoutine != null) return;
            biteRoutine = StartCoroutine(enemyAttack(collision.gameObject.GetComponent<Collider>()));
            
        }
    }



    IEnumerator enemyAttack(Collider enemyCollider)
    {
        isGrabbed = true;
        fpsController.enabled = false;
        enemyCollider.enabled = false;
        enemyCollider.GetComponentInParent<NavMeshAgent>().speed = 0;
        yield return new WaitForSeconds(3);


        TakeDamage(10);
        fpsController.enabled = true;
        EnemyInteraction enemyInteraction = enemyCollider.GetComponent<EnemyInteraction>();
        enemyInteraction.PlayerExit();

        yield return new WaitForSeconds(2f);
        enemyCollider.enabled = true;
        enemyCollider.GetComponentInParent<NavMeshAgent>().speed = 1;
        biteRoutine = null;
    }


}
