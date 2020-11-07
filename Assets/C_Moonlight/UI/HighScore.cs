using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    //public time_count _time_Count;
    public Text _Score_text;
    int _Score;
    void Start()
    {
        _Score = ((time_count.time_mini * 5 * 60) + (time_count.time_sec * 3)) * Weapon.score_weapon_bonus;
        _Score_text.text = _Score.ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))// R重新開始
        {
            SceneManager.LoadScene(0);
            time_count.time_mini = 10;
            time_count.time_sec = 10;
        }
        if(Input.GetKeyDown(KeyCode.Escape))// Esc離開遊戲
        {
            Application.Quit();
        }
    }
}
