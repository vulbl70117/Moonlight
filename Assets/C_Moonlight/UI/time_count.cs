using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_count : MonoBehaviour
{
    int time_mini = 10;//倒數_分鐘
    int time_sec = 10;//倒數_秒
    public Text time_UI;//放時間物件

    void Start()
    {
        time_UI.text = time_mini + ":" + time_sec;//顯示初始時間
        InvokeRepeating("timer", 1, 1);//重複呼叫函式:InvokeRepeating("函式名稱", 第一次間隔幾秒呼叫, 每幾秒呼叫一次)
    }
    void timer()
    {
        time_sec -= 1;//-1秒

//"秒"小於10時在顯示前面補"0"
        if(time_sec < 10)
        {
            time_UI.text = time_mini + ":0" + time_sec;
        }
        else
        {
            time_UI.text = time_mini + ":" + time_sec;//顯示時間
        }

//時間結束
        if (time_mini == 0 && time_sec == 0)
        {
            time_UI.text = "00:00!";
            CancelInvoke("timer");//取消重複呼叫:CancelInvoke("函式名稱")
        }

//分鐘-1，重置秒數
        if(time_sec == 0)
        {
            time_mini -= 1;
            time_sec = 60;
        }

        
    }
}
