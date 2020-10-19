using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private Weapon_Trigger _Trigger;
    public bool _StrikeBool;
    public Weapon _Weapon;
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
        if (_StrikeBool == true)
            return;
        if (_Weapon._Weapon_TG)
        {
            if (_Weapon._Weapon_TG._Weapon_BadyBool == true)
            {
                _StrikeBool = true;
            }
        }
    }
}
