using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;
    public int currentHealth;

    public CapsuleCollider zombieCollider;
    public AudioSource hitSFX;
    public EnemyMovement enemyMovement;
    public ParticleSystem deathFX;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        zombieCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth -= 10;
        hitSFX.Play();
    }

    IEnumerator AnimationWait()
    {
        deathFX.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    public void RemoveEnemy()
    {
        //replace with enemy death animation
        enemyMovement.seesPlayer = false;
        zombieCollider.enabled = false;
        
        GetComponentInChildren<Animator>().SetBool("zombieDead", true);
        GetComponentInChildren<Animator>().SetBool("seesPlayer", false);
        GetComponentInChildren<Animator>().SetBool("playerClose", false);
        StartCoroutine(AnimationWait());
        
    }
}
