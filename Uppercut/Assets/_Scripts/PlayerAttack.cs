using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public string punchString, uppercutString;
    public Collider[] attackHitboxes;
    public GameObject model, countdownIMG;
    Animator anim;
    bool attacking;
    PlayerMovement move;
    Countdown go;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
        attacking = false;
        move = gameObject.GetComponent<PlayerMovement>();
        go = countdownIMG.GetComponent<Countdown>();
    }

    void Update()
    {
        if(go.canAttack)
        {
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
                StartCoroutine(Attack(attackHitboxes[1], 15f, 0.3f, "Uppercut"));
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
        }

        yield return new WaitForSeconds(wait);

        attacking = false;
        move.enabled = true;
    }
}
