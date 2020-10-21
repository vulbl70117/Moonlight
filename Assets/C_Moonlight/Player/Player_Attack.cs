using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool _StrikeBool;
    public Weapon _Weapon;
    // Start is called before the first frame update
    void Start()
    {

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
