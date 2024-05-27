using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool inPauseScreen = false;

    /*
    private void Awake()
    {
        pauseScreen.SetActive(false);
    }*/

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inPauseScreen)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            inPauseScreen = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && inPauseScreen)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            inPauseScreen = false;
        }
    }
}
