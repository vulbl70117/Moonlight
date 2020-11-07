using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_change : MonoBehaviour
{
    public GameObject Dead_Panel;
    public Player _Player;
    public GameObject GOAL_Panel;

    void Start()
    {
        
    }

    void Update()
    {
        if(_Player._Renderer._Now_HP <= 0)
        {
            GoodGame();
        }
        if (Input.GetKeyDown(KeyCode.A) && Dead_Panel.activeSelf == true)
        {
            Btn_Restart();
        }
        if(GOAL_Panel.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("HighScore_Panel");
        }
    }

    public void GoodGame()//打開死亡後畫面
    {
        Dead_Panel.SetActive(true);
    }

    public void Btn_Restart()
    {
        SceneManager.LoadScene(0);
        time_count.time_mini = 10;
        time_count.time_sec = 10;
        Weapon.score_weapon_bonus = 8;
    }
}
