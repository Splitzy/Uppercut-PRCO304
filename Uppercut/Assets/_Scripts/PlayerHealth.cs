using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 100f;
    public Slider healthBar;
    public Image fill;
    public GameObject model;
    Animator anim;
    PlayerMovement move;
    PlayerAttack attack;

    void Start()
    {
        anim = model.GetComponent<Animator>();
        health = maxHealth;
        healthBar.value = health;
        move = gameObject.GetComponent<PlayerMovement>();
        attack = gameObject.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        healthBar.value = health;

        if(health >= 50)
        {
            fill.color = new Color(62f / 255f, 195f / 255f, 0f);
        }
        else if(health < 50 && health >= 25)
        {
            fill.color = new Color(254f / 255f, 78f / 255f, 0f);
        }
        else
        {
            fill.color = new Color(189f/255f, 30f/255f, 30f/255f);
        }

        if(health == maxHealth)
        {
            anim.SetInteger("Death", 0);
        }
    }

    public IEnumerator TakeDamage(float dmg)
    {
        attack.enabled = false;

        health -= dmg;

        healthBar.value = health;

        anim.SetTrigger("Hit");

        if (health <= 0)
        {
            Die();
        }

        move.enabled = false;

        yield return new WaitForSeconds(0.5f);

        move.enabled = true;

        attack.enabled = true;
    }

    void Die()
    {
        anim.ResetTrigger("Hit");
        health = 0;
        anim.SetInteger("Death", 1);
    }
}
