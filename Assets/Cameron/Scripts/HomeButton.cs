using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeButton : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Home()
    {

        SceneManager.LoadScene("Main Menu");

    }
    public void Reset()
    {

        SceneManager.LoadScene("Main Scene");

    }
}