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

    public GameObject deathScreen;

    private Coroutine biteRoutine;
    public float timeRemaining = 3;
    public int qButtonPressed;
    public bool isGrabbed;


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
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (isGrabbed == true)
            {
            qButtonPressed += 1;
            }else
        {
            Debug.Log("Not Grabbed");
        }
        }
        if (isGrabbed == true)
        {
            timeRemaining -= Time.deltaTime;
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
        SimpleFPSController controller = GetComponent<SimpleFPSController>();
        controller.enabled = false;
        enemyCollider.enabled = false;
        enemyCollider.GetComponentInParent<NavMeshAgent>().speed = 0;
        yield return new WaitForSeconds(3);


        TakeDamage(10);
        controller.enabled = true;
        EnemyInteraction enemyInteraction = enemyCollider.GetComponent<EnemyInteraction>();
        enemyInteraction.PlayerExit();

        yield return new WaitForSeconds(2f);
        enemyCollider.enabled = true;
        enemyCollider.GetComponentInParent<NavMeshAgent>().speed = 1;
        biteRoutine = null;
    }


}
