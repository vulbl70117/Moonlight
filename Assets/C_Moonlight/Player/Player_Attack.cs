using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private Weapon_Trigger _Trigger;
    // Start is called before the first frame update
    void Start()
    {
        _Trigger = GetComponent<Weapon_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        //if (_Trigger != null)
        //{
        //    _Trigger._HP.BeAttack();
        //    _Machine._HP._StrikeBool = false;
        //}
    }
}
