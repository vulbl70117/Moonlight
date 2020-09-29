﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trigger : MonoBehaviour
{
    public bool _To2D;
    public bool _To3D;
    public bool _Evade_ToMachine;

    public GameObject _Camera_2D;
    public GameObject _Camera_3D;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            Evade_Trigger();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "To2D")
            {
                _To2D = true;
                Camera_2D();
            }
            else if(other.gameObject.tag == "To3D")
            {
                _To3D = true;
                Camera_3D();
            }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            _Evade_ToMachine = false;
        }
    }
    private void Camera_2D()
    {
        _Camera_2D.SetActive(true);
        _Camera_3D.SetActive(false);
    }
    private void Camera_3D()
    {
        _Camera_3D.SetActive(true);
        _Camera_2D.SetActive(false);
    }
    private void Evade_Trigger()
    {
        _Evade_ToMachine = true;
    }
}
