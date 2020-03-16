using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public string punchString, uppercutString, specialString;
    public Collider[] attackHitboxes;
    public GameObject model, countdownIMG;
    Animator anim;
    bool attacking;
    PlayerMovement move;
    Countdown go;
    public int specialMeter = 0;
    public Slider meterSlider;

    protected float Timer;
    int delay = 1;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
        attacking = false;
        move = gameObject.GetComponent<PlayerMovement>();
        go = countdownIMG.GetComponent<Countdown>();
        meterSlider.value = specialMeter;
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
            }

            if (Input.GetButtonDown(punchString) && attacking == false)
            {
                move.enabled = false;
                anim.SetTrigger("Punch");
                attacking = true;
                StartCoroutine(Attack(attackHitboxes[0], 8f, 0.2f, "Punch"));
            }

            if (Input.GetButtonDown(uppercutString) && attacking == false)
            {
                move.enabled = false;
                attacking = true;
                anim.SetTrigger("Uppercut");
                StartCoroutine(Attack(attackHitboxes[1], 15f, 0.4f, "Uppercut"));
            }

            if(Input.GetButtonDown(specialString) && attacking == false && specialMeter == 100)
            {
                specialMeter = 0;
                move.enabled = false;
                attacking = true;
                anim.SetTrigger("Kick");
                StartCoroutine(Attack(attackHitboxes[2], 30f, 0.5f, "Kick"));  
            }
        } 
    }

    IEnumerator Attack(Collider col, float dmg, float wait, string animation)
    {
        yield return new WaitForSeconds(wait);

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));

        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }

            c.SendMessage("TakeDamage", dmg);
            specialMeter += 10;
            meterSlider.value = specialMeter;
        }

        yield return new WaitForSeconds(wait);
        
        attacking = false;
        move.enabled = true;
    }
}
