using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, controlsMenu, firstButton, eventSystem;
    GameObject newButton;

    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        firstButton = GameObject.Find("Play Button");
    }

    public void SwitchToSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        firstButton = GameObject.Find("Music Slider");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void SwitchToControls()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
        firstButton = GameObject.Find("Return From Controls Button");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void SwitchToMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        firstButton = GameObject.Find("Play Button");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
