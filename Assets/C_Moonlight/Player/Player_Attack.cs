﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool _IsRay;
    public Weapon _Weapon;
    public Player player;
    //Machine
    public Machine _Machine;
    private GameObject _Any;
    private GameObject _machine;
    public Collider[] _colliders;
    private Vector3 _zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _colliders = Physics.OverlapSphere(transform.position, _Weapon._WeaponSetting._WeaponRay[(int)_Weapon._WeaponSetting.nowWeapon], 1 << 11);
        foreach(Collider c in _colliders)
        {
            _zero = c.gameObject.transform.position;
            _machine = c.gameObject;
            if (Vector3.Dot(player._Move._Move_Player_ModTF.right, (_zero - transform.position).normalized) > 0)
            {
                Machine(_machine);
                _IsRay = true;
            }
            else
                _IsRay = false;
        }
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.gameObject.GetComponent<Machine>();
    }
}
