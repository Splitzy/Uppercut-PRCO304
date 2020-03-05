using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOScript : MonoBehaviour
{

    public GameObject fadeIn;

    void slowDown()
    {
        Time.timeScale = 0.5f;
    }

    void koFinish()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        fadeIn.SetActive(true);
    }
}
