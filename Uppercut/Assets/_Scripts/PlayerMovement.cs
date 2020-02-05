using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public string h = "Horizontal_P1";
    Vector2 move;

    void FixedUpdate()
    {
        move.x = Input.GetAxis(h);

        Vector2 m = new Vector2(move.x, 0) * speed * Time.deltaTime;

        transform.Translate(m);
    }
}
