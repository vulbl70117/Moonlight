using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_start : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Scence_3_DreamForestTree");
    }
}
