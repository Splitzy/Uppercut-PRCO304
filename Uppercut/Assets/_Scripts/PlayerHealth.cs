using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 100f;
    public Slider healthBar;
    public GameObject model;
    Animator anim;
    PlayerMovement move;
    PlayerAttack attack;

    void Start()
    {
        anim = model.GetComponent<Animator>();
        health = maxHealth;
        healthBar.value = calcHealth();
        move = gameObject.GetComponent<PlayerMovement>();
        attack = gameObject.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        healthBar.value = calcHealth();
        if(health == maxHealth)
        {
            anim.SetInteger("Death", 0);
        }
    }

    public IEnumerator TakeDamage(float dmg)
    {
        attack.enabled = false;

        health -= dmg;

        healthBar.value = calcHealth();

        if(health <= 0)
        {
            Die();
        }

        anim.SetTrigger("Hit");

        move.enabled = false;

        yield return new WaitForSeconds(0.25f);


        move.enabled = true;

        attack.enabled = true;
    }

    float calcHealth()
    {
        return health / maxHealth;
    }

    void Die()
    {
        health = 0;
        anim.SetInteger("Death", 1);
    }
}
