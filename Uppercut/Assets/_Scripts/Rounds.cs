using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    float p1Health, p2Health, time;
    int p1Index, p2Index = 0;
    public Image[] P1Rounds, P2Rounds;
    public GameObject P1, P2, timer;
    public Transform P1Spawn, P2Spawn;



    // Start is called before the first frame update
    void Start()
    {
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        time = timer.GetComponent<Timer>().currentTime;
        p1Health = P1.GetComponent<PlayerHealth>().health;
        p2Health = P2.GetComponent<PlayerHealth>().health;

        if (p1Health == 0 && time != 0f)
        {
            SetRounds(P2Rounds, p2Index, Color.green);
            p2Index++;
            CheckIndex(p2Index);
        }
        else if (p2Health == 0 && time != 0f)
        {
            SetRounds(P1Rounds, p1Index, Color.green);
            p1Index++;
            CheckIndex(p1Index);
        }
        else if (time == 0f)
        {
            TimeRound();
        }
    }

    void StartRound()
    {
        timer.GetComponent<Timer>().currentTime = 60f;
        P1.GetComponent<PlayerHealth>().health = 100f;
        P2.GetComponent<PlayerHealth>().health = 100f;
        P1.transform.position = P1Spawn.position;
        P2.transform.position = P2Spawn.position;
    }

    void SetRounds(Image[] images, int index, Color c)
    {
        images[index].color = c;
    }

    void TimeRound()
    {
        if(p1Health > p2Health)
        {
            SetRounds(P1Rounds, p1Index, Color.blue);
            p1Index++;
            CheckIndex(p1Index);
        }
        else if(p2Health > p1Health)
        {
            SetRounds(P2Rounds, p2Index, Color.blue);
            p2Index++;
            CheckIndex(p2Index);
        }
        else if(p2Health == p1Health)
        {
            Debug.Log("It's a draw...");
            SetRounds(P1Rounds, p1Index, Color.red);
            SetRounds(P2Rounds, p2Index, Color.red);
            StartRound();
        }
    }

    void CheckIndex(int index)
    {
        if (index == 5)
        {
            Debug.Log("Game is over");
        }
        else
        {
            StartRound();
        }
    }
}
