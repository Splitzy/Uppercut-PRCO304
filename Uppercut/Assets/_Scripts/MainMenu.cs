using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, controlsMenu, cssMenu, levelMenu, firstButton, eventSystem;
    public string[] characterNames, lvlNames;
    public Text p1Name, p2Name, lvlText;
    public Sprite[] playerSprites, levelSprites;
    public Image p1Image, p2Image, lvlImage;

    GameObject newButton;
    int p1Index = 0;
    int p2Index = 0;
    int lvlIndex = 0;

    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        cssMenu.SetActive(false);
        levelMenu.SetActive(false);

        p1Name.text = characterNames[p1Index];
        p2Name.text = characterNames[p2Index];

        p1Image.sprite = playerSprites[p1Index];
        p2Image.sprite = playerSprites[p2Index];

        lvlText.text = lvlNames[lvlIndex];
        lvlImage.sprite = levelSprites[lvlIndex];
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
        cssMenu.SetActive(false);

        firstButton = GameObject.Find("Play Button");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void SwitchToCSS()
    {
        cssMenu.SetActive(true);
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);

        firstButton = GameObject.Find("P1 Left Button");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void SwitchToLevelSelect()
    {
        cssMenu.SetActive(false);
        levelMenu.SetActive(true);

        firstButton = GameObject.Find("Level Left Button");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstButton, null);
    }

    public void P1CycleRight()
    {
        p1Index++;
        if (p1Index >= characterNames.Length)
        {
            p1Index = 0;
        }

        p1Name.text = characterNames[p1Index];
        p1Image.sprite = playerSprites[p1Index];
    }

    public void P1CycleLeft()
    {
        p1Index--;
        if (p1Index < 0)
        {
            p1Index = characterNames.Length - 1;
        }

        p1Name.text = characterNames[p1Index];
        p1Image.sprite = playerSprites[p1Index];
    }

    public void P2CycleRight()
    {
        p2Index++;
        if (p2Index >= characterNames.Length)
        {
            p2Index = 0;
        }

        p2Name.text = characterNames[p2Index];
        p2Image.sprite = playerSprites[p2Index];
    }

    public void P2CycleLeft()
    {
        p2Index--;
        if (p2Index < 0)
        {
            p2Index = characterNames.Length - 1;
        }

        p2Name.text = characterNames[p2Index];
        p2Image.sprite = playerSprites[p2Index];
    }

    public void LevelCycleLeft()
    {
        lvlIndex--;
        if (lvlIndex < 0)
        {
            lvlIndex = lvlNames.Length - 1;
        }

        lvlText.text = lvlNames[lvlIndex];
        lvlImage.sprite = levelSprites[lvlIndex];
    }

    public void LevelCycleRight()
    {
        lvlIndex++;
        if (lvlIndex >= lvlNames.Length)
        {
            lvlIndex = 0;
        }

        lvlText.text = lvlNames[lvlIndex];
        lvlImage.sprite = levelSprites[lvlIndex];
    }



    public void StartGame()
    {
        PlayerPrefs.SetInt("P1", p1Index);
        PlayerPrefs.SetInt("P2", p2Index);
        SceneManager.LoadScene(lvlIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
