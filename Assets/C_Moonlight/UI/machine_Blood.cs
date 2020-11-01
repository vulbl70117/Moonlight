using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class machine_Blood : MonoBehaviour
{
    public float curHP;//放當前血量
    public float maxHP;//放最高血量
    public Slider barHP;//放血條

    public Player_Renderer Player_Renderer; //放角色
    public Machine_Renderer Machine_Renderer;//放機器

    void Start()
    {
        maxHP = Machine_Renderer._Machine_HP;//初始最高血量
    }
    void Update()
    {
        if (Machine_Renderer != null)
        {
            curHP = Machine_Renderer._Machine_HP;//更新當前血量
            setSliderHP();
        }
    }
    public void setSliderHP()//更新血條
    {
        //float fcur = (float)Int32.Parse(curHP.text);
        //float fmax = (float)Int32.Parse(maxHP.text);
        barHP.value = curHP / maxHP;
    }
}
