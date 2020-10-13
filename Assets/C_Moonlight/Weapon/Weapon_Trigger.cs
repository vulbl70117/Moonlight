﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Trigger : MonoBehaviour
{
    public Weapon_Type _Type = Weapon_Type.Fist;
    public bool _Weapon_BadyBool;
    public Player Player;
    private GameObject _Anything;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (_Type == Weapon_Type.Fist)
        {
            if(other.gameObject.CompareTag("Machine"))
            {
                _Weapon_BadyBool = true;
                _Anything = other.gameObject;
                Player.Machine(_Anything);
            }
        }
        if (_Type == Weapon_Type.Shield)
        {
            if (other.gameObject.CompareTag("Machine"))
            {
                _Anything = other.gameObject;
                Player.Machine(_Anything);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Machine"))
        {
            _Weapon_BadyBool = false;
        }
    }
}
