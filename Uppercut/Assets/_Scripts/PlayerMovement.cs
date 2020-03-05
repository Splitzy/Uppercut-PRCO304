using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public string h = "Horizontal_P1";
    Vector2 move;
    Animator anim;
    public GameObject model, countdown;
    Countdown go;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
        go = countdown.GetComponent<Countdown>();
    }

    void FixedUpdate()
    {
        if(go.canAttack)
        {
            Debug.Log(Input.GetAxis("Horizontal_P1"));

            if (Input.GetAxis(h) > 0 || Input.GetAxis(h) < 0)
            {
                anim.SetInteger("Move", 1);
            }

            if (Input.GetAxis(h) == 0)
            {
                anim.SetInteger("Move", 0);
            }

            move.x = Input.GetAxis(h);

            Vector2 m = new Vector2(move.x, 0) * speed * Time.deltaTime;

            transform.Translate(m);
        }
    }
}
