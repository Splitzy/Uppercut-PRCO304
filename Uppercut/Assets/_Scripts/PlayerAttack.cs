using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public string punchString, uppercutString;
    public Collider[] attackHitboxes;
    public GameObject model;
    Animator anim;
    bool attacking;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
        attacking = false;
    }

    void Update()
    {
        if (Input.GetButtonDown(punchString) && attacking == false)
        {
            anim.SetBool("Punch", true);
            attacking = true;
            StartCoroutine(Attack(attackHitboxes[0], 8f));
        }

        if (Input.GetButtonDown(uppercutString) && attacking == false)
        {
            attacking = true;
            //Attack(attackHitboxes[1], 15f);
            //Debug.Log(uppercutString);
        }
    }

    IEnumerator Attack(Collider col, float dmg)
    {
        yield return new WaitForSeconds(0.25f);

        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
            
        foreach(Collider c in cols)
        {
            if(c.transform.root == transform)
            {
                continue;
            }

            c.SendMessage("TakeDamage", dmg);
        }

        yield return new WaitForSeconds(0.25f);

        anim.SetBool("Punch", false);
        attacking = false;
    }
}


