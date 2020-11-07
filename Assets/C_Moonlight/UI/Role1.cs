using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Role1 : MonoBehaviour
{
    public Text curHP;//放當前血量
    public Text maxHP;//放最高血量
    public Slider barHP;//放血條

    public Player_Renderer Player_Renderer; //放角色
    // Start is called before the first frame update
    void Start()
    {
        maxHP.text = Player_Renderer._Now_HP.ToString();//初始最高血量
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Renderer != null)
        {
            curHP.text = Player_Renderer._Now_HP.ToString();//更新當前血量
            setSliderHP();
        }
    }
    public void setSliderHP()//更新血條
    {
        float fcur = (float)Int32.Parse(curHP.text);
        float fmax = (float)Int32.Parse(maxHP.text);
        barHP.value = fcur / fmax;
    }
}
