using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject settings;
    public GameObject MainMenu;

    private void Start()
    {
        settings.SetActive(false);
    }

    public void Settings() 
    {
        settings.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void SettingsOff()
    {
        settings.SetActive(false);
        MainMenu.SetActive(true);

    }

    public void Play() 
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
