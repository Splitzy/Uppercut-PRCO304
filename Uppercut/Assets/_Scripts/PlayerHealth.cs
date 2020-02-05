using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 100f;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.value = calcHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        healthBar.value = calcHealth();

        if(health <= 0)
        {
            Die();
        }
    }

    float calcHealth()
    {
        return health / maxHealth;
    }

    void Die()
    {
        health = 0;
        Debug.Log("dead");
    }
}
