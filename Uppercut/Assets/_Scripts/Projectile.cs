using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public GameObject hitParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * 6f;
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.SendMessage("TakeDamage", 10);
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
