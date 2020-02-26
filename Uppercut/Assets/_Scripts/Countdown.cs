using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public bool canAttack, countdownDone = false;

    // Update is called once per frame
    void Update()
    {
        if(countdownDone)
        {
            gameObject.SetActive(false);
        }
    }

    void unlockAttack()
    {
        canAttack = true;
    }

    void endCountdown()
    {
        countdownDone = true;
    }
}
