using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool pauseEnabled = false;
    public AudioSource pause_sound;
    public AudioSource start_sound;
    public GameObject pausePanel;
    Panel_change _panel_Change;

    void Start()
    {
        _panel_Change = GetComponent<Panel_change>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseEnabled = !pauseEnabled;
            //check if game is already paused
            if (pauseEnabled == true)
            {
                pause();
                //AudioListener.volume = 1;
                //Screen.showCursor = false;
            }

            //else if game isn't paused, then pause it
            else if (pauseEnabled == false)
            {
                start();
                //AudioListener.volume = 0;                                       
                //Screen.showCursor = true;
            }
        }
        if(pausePanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (pausePanel.activeSelf == true && Input.GetKeyDown(KeyCode.R))
        {
            pauseEnabled = false;
            Time.timeScale = 1;
            _panel_Change.Btn_Restart();
        }
    }

    public void pause()
    {
        pausePanel.SetActive(true);
        pause_sound.Play();
        pauseEnabled = true;
        Time.timeScale = 0;
    }

    public void start()
    {
        pausePanel.SetActive(false);
        start_sound.Play();
        pauseEnabled = false;
        Time.timeScale = 1;     
    }
}
