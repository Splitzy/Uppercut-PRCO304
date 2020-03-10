using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    public Image[] P1Rounds, P2Rounds;
    public Sprite defaultSprite, winSprite, drawSprite, timeSprite;
    public GameObject P1, P2, timer, countdownIMG, koIMG, fadeOut, P1Model, P2Model;
    public Transform P1Spawn, P2Spawn;

    float p1Health, p2Health, time;
    int p1Index, p2Index = 0;
    bool check = false;
    Countdown go;


    void Start()
    {
        go = countdownIMG.GetComponent<Countdown>();
        StartRound();
    }

    void Update()
    {
        time = timer.GetComponent<Timer>().currentTime;    

        p1Health = P1.GetComponent<PlayerHealth>().health;
        p2Health = P2.GetComponent<PlayerHealth>().health;

        if (p1Health == 0 && time != 0f && !check)
        {
            check = true;
            SetRounds(P2Rounds, p2Index, winSprite);
            p2Index++;
        }
        else if (p2Health == 0 && time != 0f && !check)
        {
            check = true;
            SetRounds(P1Rounds, p1Index, winSprite);
            p1Index++;
        }
        else if (time == 0f && !check)
        {
            check = true;
            if (p1Health > p2Health)
            {
                SetRounds(P1Rounds, p1Index, timeSprite);
                p1Index++;
            }
            else if (p2Health > p1Health)
            {
                SetRounds(P2Rounds, p2Index, timeSprite);
                p2Index++;
            }
            else if (p2Health == p1Health)
            {
                Debug.Log("It's a draw...");
                SetRounds(P1Rounds, p1Index, drawSprite);
                SetRounds(P2Rounds, p2Index, drawSprite);
                p1Index++;
                p2Index++;
            }
                
        }
    }

    public void StartRound()
    {
        go.countdownDone = false;
        go.canAttack = false;
        countdownIMG.SetActive(true);
        check = false;

        P1.GetComponent<PlayerHealth>().health = 100f;
        P2.GetComponent<PlayerHealth>().health = 100f;
        P1.transform.position = P1Spawn.position;
        P2.transform.position = P2Spawn.position;
        P1Model.GetComponent<Animator>().SetInteger("Walk", 0);
        P2Model.GetComponent<Animator>().SetInteger("Walk", 0);

        timer.GetComponent<Timer>().currentTime = 60f;

        fadeOut.SetActive(true);
    }

    void SetRounds(Image[] images, int index, Sprite s)
    {
        if (index == 4)
        {
            images[index].sprite = s;
            GameOver();
        }
        else
        {
            images[index].sprite = s;
            koIMG.SetActive(true);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0.0f;
        if(P1Rounds[4].sprite != defaultSprite)
        {
            Debug.Log("Player 1 wins");
        }
        else if(P2Rounds[4].sprite != defaultSprite)
        {
            Debug.Log("Player 2 wins");
        }
        
    }
}
