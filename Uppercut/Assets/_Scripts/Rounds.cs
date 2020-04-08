using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    public Image[] p1Rounds, p2Rounds;
    public Sprite defaultSprite, winSprite, drawSprite, timeSprite;
    public GameObject timer, countdownIMG, koIMG, fadeOut;
    public Transform p1Spawn, p2Spawn;

    float p1Health, p2Health, time;
    int p1Index, p2Index = 0;
    bool check = false;
    Countdown go;

    public GameObject[] p1Prefabs, p2Prefabs, players, models;

    void InstantiatePlayers()
    {
        int p1PrefabIndex = PlayerPrefs.GetInt("P1");
        int p2PrefabIndex = PlayerPrefs.GetInt("P2");
        Instantiate(p1Prefabs[p1PrefabIndex], p1Spawn.position, Quaternion.identity);
        Instantiate(p2Prefabs[p2PrefabIndex], p2Spawn.position, Quaternion.identity);

        players = GameObject.FindGameObjectsWithTag("Player");
        models = GameObject.FindGameObjectsWithTag("Model");
    }


    void Start()
    {
        InstantiatePlayers();
        go = countdownIMG.GetComponent<Countdown>();
        StartRound();
    }

    void Update()
    {
        time = timer.GetComponent<Timer>().currentTime;

        p1Health = players[0].GetComponent<PlayerHealth>().health;
        p2Health = players[1].GetComponent<PlayerHealth>().health;

        if (p1Health == 0 && time != 0f && !check)
        {
            check = true;
            SetRounds(p2Rounds, p2Index, winSprite);
            p2Index++;
        }
        else if (p2Health == 0 && time != 0f && !check)
        {
            check = true;
            SetRounds(p1Rounds, p1Index, winSprite);
            p1Index++;
        }
        else if (time == 0f && !check)
        {
            check = true;
            if (p1Health > p2Health)
            {
                SetRounds(p1Rounds, p1Index, timeSprite);
                p1Index++;
            }
            else if (p2Health > p1Health)
            {
                SetRounds(p2Rounds, p2Index, timeSprite);
                p2Index++;
            }
            else if (p2Health == p1Health)
            {
                SetRounds(p1Rounds, p1Index, drawSprite);
                SetRounds(p2Rounds, p2Index, drawSprite);
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

        players[0].GetComponent<PlayerHealth>().health = 100f;
        players[1].GetComponent<PlayerHealth>().health = 100f;
        players[0].transform.position = p1Spawn.position;
        players[1].transform.position = p2Spawn.position;
        models[0].GetComponent<Animator>().SetInteger("Walk", 0);
        models[1].GetComponent<Animator>().SetInteger("Walk", 0);

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
        if(p1Rounds[4].sprite != defaultSprite)
        {
            Debug.Log("Player 1 wins");
        }
        else if(p2Rounds[4].sprite != defaultSprite)
        {
            Debug.Log("Player 2 wins");
        }
        
    }
}
