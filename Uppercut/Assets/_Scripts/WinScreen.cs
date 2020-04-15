using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject cd;
    Countdown go;

    // Start is called before the first frame update
    void Start()
    {
        go = cd.GetComponent<Countdown>();
    }

    void slowDown()
    {
        Time.timeScale = 0.5f;
        go.canAttack = false;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}
