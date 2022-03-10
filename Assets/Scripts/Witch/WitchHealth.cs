using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchHealth : MonoBehaviour
{

    public float startingHealth = 100f;
    public float currentHealth;

    Animator anim;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float amount) 
    {
        if (isDead) {
            return;
        }
        
        print("Witch is taking damage");
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
    }
}
