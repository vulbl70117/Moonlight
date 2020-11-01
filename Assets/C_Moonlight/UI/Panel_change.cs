using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_change : MonoBehaviour
{
    public GameObject Dead_Panel;
    public Player _Player;

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
    }

    public void GoodGame()//打開死亡後畫面
    {
        Dead_Panel.SetActive(true);
    }

    public void Btn_Restart()
    {
        SceneManager.LoadScene(0);
    }
}
