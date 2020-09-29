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
    // Start is called before the first frame update
    void Start()
    {
        _Machine_RD = GetComponent<Rigidbody>();
        _Machine_TF = GetComponent<Transform>();
        _Weapon_Trigger = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeAttack()
    {
        _Machine_HP--;
        Debug.Log("Target BeAttack!!/HP: " + _Machine_HP);
        if (_Machine_RD != null)
        {
            Strike();
            if (_Machine_HP < 0)
            {
                gameObject.SetActive(false);
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
                _Machine_RD.AddForce(_Machine_TF.forward * -1 * _StrikePower, ForceMode.Impulse);
                _StrikeBool = true;
            }
        }
    }
}
