using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject punch;
    public float attackSpeed = 1f;
    public float attackCD = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if(punch.SelfActive == true)
        {
            punch.setActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackCD -= Time.deltaTime;

        if(attackCD <= 0f)
        {
            if (Input.KeyCode("E"))
            {
                if (punch.SelfActive == false)
                {
                    punch.setActive(true);
                    attackCD = 1f / attackSpeed;
                }
            }
        }
    }
}

