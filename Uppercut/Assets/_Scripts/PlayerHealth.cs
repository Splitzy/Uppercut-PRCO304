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
    public AudioClip[] hurtClip, deathClip;
    Animator anim;
    AudioSource src;
    PlayerMovement move;
    PlayerAttack attack;
    Rigidbody rb;

    void Start()
    {
        anim = model.GetComponent<Animator>();
        health = maxHealth;
        healthBar.value = health;
        move = gameObject.GetComponent<PlayerMovement>();
        attack = gameObject.GetComponent<PlayerAttack>();
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
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

        src.clip = hurtClip[Random.Range(0, hurtClip.Length)];

        src.Play();

        yield return new WaitForSeconds(0.5f);

        move.enabled = true;

        attack.enabled = true;
    }

    void Die()
    {
        anim.ResetTrigger("Hit");
        health = 0;

        src.clip = deathClip[Random.Range(0, deathClip.Length)];

        src.Play();

        anim.SetInteger("Death", 1);
    }

    public IEnumerator KnockBack(Vector3 dir, float force)
    {
        rb.AddForce(dir * force, ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        dir = Vector3.zero;
    }
}
