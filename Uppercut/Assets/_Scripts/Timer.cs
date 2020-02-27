using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text countdownTimer;

    public GameObject countdownIMG;

    public float currentTime = 0f;
    float startTime = 60f;

    Countdown go;

    // Start is called before the first frame update
    void Start()
    {
        go = countdownIMG.GetComponent<Countdown>();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime > 0 && go.canAttack)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownTimer.text = currentTime.ToString("0");
        }
        else if (currentTime <= 0 && go.canAttack)
        {
            currentTime = 0;
            countdownTimer.text = "0";
        }
    }
}
