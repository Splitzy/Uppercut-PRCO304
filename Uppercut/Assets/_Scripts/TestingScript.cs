using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 test = new Vector3(5f, 0f, 0f); 
        gameObject.GetComponent<Rigidbody>().AddForce(test * 0.5f ,ForceMode.Impulse);
    }
}
