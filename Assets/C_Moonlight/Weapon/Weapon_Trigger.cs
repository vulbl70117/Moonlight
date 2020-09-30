using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Trigger : MonoBehaviour
{
    public bool _Weapon_BadyBool;
    public Player Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Machine"))
        {
            _Weapon_BadyBool = true;
            Player.test_HP(other.gameObject);

            //Machine_HP _HP = other.GetComponent<Machine_HP>();
            //_HP.BeAttack();
            //_HP._StrikeBool = false;
            Debug.Log(_Weapon_BadyBool);
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
