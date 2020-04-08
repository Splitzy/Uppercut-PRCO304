using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public string punchString, uppercutString, specialString, searchString;
    public Collider[] attackHitboxes;
    GameObject countdownIMG;
    public GameObject model;
    Animator anim;
    bool attacking;
    PlayerMovement move;
    Countdown go;
    public int specialMeter = 0;
    Slider meterSlider;
    public AudioClip hitClip, meterAttackClip, meterClip;
    AudioSource source;
    

    protected float Timer;
    int delay = 1;

    private void Start()
    {
        meterSlider = GameObject.Find(searchString).GetComponent<Slider>();
        countdownIMG = GameObject.Find("Countdown");
        anim = model.GetComponent<Animator>();
        attacking = false;
        move = gameObject.GetComponent<PlayerMovement>();
        go = countdownIMG.GetComponent<Countdown>();
        meterSlider.value = specialMeter;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(go.canAttack)
        {
            Timer += Time.deltaTime;

            if (Timer >= delay)
            {
                Timer = 0f;
                specialMeter += 2;
                meterSlider.value = specialMeter;
            }

            if (specialMeter >= 100)
            {
                specialMeter = 100;
                source.clip = meterClip;
                source.Play();
            }

            if (Input.GetButtonDown(punchString) && attacking == false)
            {
                move.enabled = false;
                anim.SetTrigger("Punch");
                attacking = true;
                StartCoroutine(Attack(attackHitboxes[0], 8f, 0.2f, 1.5f));
            }

            if (Input.GetButtonDown(uppercutString) && attacking == false)
            {
                move.enabled = false;
                attacking = true;
                anim.SetTrigger("Uppercut");
                StartCoroutine(Attack(attackHitboxes[1], 15f, 0.4f, 3f));
            }

            //if(Input.GetButtonDown(specialString) && attacking == false && specialMeter == 100)
            //{
            //    specialMeter = 0;
            //    move.enabled = false;
            //    attacking = true;
            //    anim.SetTrigger("Kick");
            //    StartCoroutine(Attack(attackHitboxes[2], 30f, 0.5f, 3.5f));  
            //}
        } 
    }

    IEnumerator Attack(Collider col, float dmg, float wait, float force)
    {
        if (anim.GetBool("Kick") == true)
        {
            source.clip = meterAttackClip;
            source.Play();
        }

        yield return new WaitForSeconds(wait);

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));

        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }

            source.clip = hitClip;
            source.Play();

            c.SendMessage("TakeDamage", dmg);

            if(c.gameObject.tag == "Player")
            {
                Vector3 dir = c.transform.position - transform.position;
                StartCoroutine(c.gameObject.GetComponent<PlayerHealth>().KnockBack(dir, force));
            }

            specialMeter += 10;
            meterSlider.value = specialMeter;
        }

        yield return new WaitForSeconds(wait);
        
        attacking = false;
        move.enabled = true;
    }
}
