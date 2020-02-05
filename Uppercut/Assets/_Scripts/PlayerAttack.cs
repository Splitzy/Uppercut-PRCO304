using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public string punchString, uppercutString;
    public Collider[] attackHitboxes;

    void Update()
    {
        if (Input.GetButtonDown(punchString))
        {
            Attack(attackHitboxes[0], 3f);
            //Debug.Log(punchString);
        }

        if (Input.GetButtonDown(uppercutString))
        {
            Attack(attackHitboxes[1], 1000f);
            //Debug.Log(uppercutString);
        }
    }

    void Attack(Collider col, float dmg)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
            
        foreach(Collider c in cols)
        {
            if(c.transform.root == transform)
            {
                continue;
            }

            c.SendMessage("TakeDamage", dmg);
        }
    }
}


