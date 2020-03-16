using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public string h = "Horizontal_P1";
    Animator anim;
    public GameObject model, countdown;
    Countdown go;
    Rigidbody rb;
    Vector3 input;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
        go = countdown.GetComponent<Countdown>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(go.canAttack)
        {
            float moveHorizontal = Input.GetAxis(h);

            input = new Vector3(moveHorizontal, 0, 0);

            if (Input.GetAxis(h) > 0 || Input.GetAxis(h) < 0)
            {
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetAxis(h) == 0)
            {
                anim.SetInteger("Walk", 0);
            }

            rb.MovePosition(transform.position + (input * speed * Time.fixedDeltaTime));

        }
    }
}
