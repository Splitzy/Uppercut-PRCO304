using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public new string name = "";
    public string h = "Horizontal_P1";
    public string searchString;
    Animator anim;
    public GameObject model;
    Countdown go;
    Rigidbody rb;
    Vector3 i;
    GameObject cd;

    [SerializeField]
    private Text nameTxt;

    private void Start()
    {
        nameTxt = GameObject.Find(searchString).GetComponent<Text>();
        cd = GameObject.Find("Countdown");
        anim = model.GetComponent<Animator>();
        go = cd.GetComponent<Countdown>();
        rb = GetComponent<Rigidbody>();
        nameTxt.text = name;
    }

    void FixedUpdate()
    {
        if(go.canAttack)
        {
            float moveHorizontal = Input.GetAxis(h);

            i = new Vector3(moveHorizontal, 0, 0);

            if (Input.GetAxisRaw(h) > 0 || Input.GetAxisRaw(h) < 0)
            {
                anim.SetBool("Walking", true);
            }
            else if (Input.GetAxisRaw(h) == 0)
            {
                anim.SetBool("Walking", false);
            }

            rb.MovePosition(transform.position + (i * speed * Time.fixedDeltaTime));

        }
    }
}
