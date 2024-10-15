using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;
    public int currentHealth;

    public AudioClip audioFX;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        GetComponent<AudioSource>().clip = audioFX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth -= 10;
        GetComponentInChildren<AudioSource>().Play();
    }

    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    public void RemoveEnemy()
    {
        //replace with enemy death animation
        
        GetComponentInChildren<Animator>().SetBool("zombieDead", true);
        GetComponentInChildren<Animator>().SetBool("seesPlayer", false);
        GetComponentInChildren<Animator>().SetBool("playerClose", false);
        StartCoroutine(AnimationWait());
        
    }
}
