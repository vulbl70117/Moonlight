using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_HP : MonoBehaviour
{
    public float _Machine_HP = 3;
    public float _StrikePower = 1;
    //
    public bool _StrikeBool;
    //
    private Rigidbody _Machine_RD;
    //
    private Weapon_Trigger _Weapon_Trigger;
    //
    private Transform _Machine_TF;
    //
    private Player_Trigger _Player_Trigger;
    // Start is called before the first frame update
    void Start()
    {
        _Machine_RD = GetComponent<Rigidbody>();
        _Machine_TF = GetComponent<Transform>();
        _Weapon_Trigger = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon_Trigger>();
        _Player_Trigger = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(_Enable==false) gameObject.SetActive(false);
    }
    public void BeAttack()
    {
        Debug.Log("Target BeAttack!!/HP: " + _Machine_HP);
        if (_Machine_RD != null)
        {
            _Machine_HP--;
            Strike();
            if (_Machine_HP < 0)
            {
                _Player_Trigger._Evade_ToMachine = false;
                gameObject.SetActive(false);
                //transform.position = new Vector3(10.0f,1.5f,-50.0f);
                //_Enable = false;
                //return;
            }
        }
    }
    public void Strike()
    {
        if (_StrikeBool == true)
            return;
        if (_Weapon_Trigger)
        {
            if (_Weapon_Trigger._Weapon_BadyBool == true)
            {
                //瘦瘠動畫
                _StrikeBool = true;
            }
        }
    }
}
