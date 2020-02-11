using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text countdownTimer;

    public float currentTime = 0f;
    float startTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownTimer.text = currentTime.ToString("0");
        }
        else
        {
            currentTime = 0;
            countdownTimer.text = "0";
        }
    }
}
