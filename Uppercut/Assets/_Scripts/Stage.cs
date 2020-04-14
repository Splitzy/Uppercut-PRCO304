using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    public Transform p1Respawn, p2Respawn;

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Kera Player 1(Clone)")
        {
            other.transform.position = p1Respawn.position;
        }
        else if (other.gameObject.name == "Kera Player 2(Clone)")
        {
            other.transform.position = p2Respawn.position;
        }
    }
}
