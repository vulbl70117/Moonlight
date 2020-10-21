using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{
    public float _FistRay = 0.5f;
    public float _SwordRay = 0.8f;
    public float _AxeRay = 1f;

    public Transform _Fist_TF;
    public Transform _Sword_TF;
    public Transform _Axe_TF;

    public bool _IsFist;
    public bool _IsSword;
    public bool _IsAxe;

    public Weapon _Weapon;
    public Weapon_Type_enum _Type;
    public RaycastHit _Attack_Hit;
    void Start()
    {
        _Weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponRay();
    }
    public void WeaponRay()
    {
        if (_Type == Weapon_Type_enum.Fist)
            _IsFist = Physics.Raycast(transform.position, -_Fist_TF.up, out _Attack_Hit, _FistRay, 1 << 9);
        if(_Type==Weapon_Type_enum.Axe)
            _IsAxe = Physics.Raycast(transform.position, -_Axe_TF.up, out _Attack_Hit, _AxeRay, 1 << 9);
        if(_Type==Weapon_Type_enum.Sword)
            _IsSword = Physics.Raycast(transform.position, -_Sword_TF.up, out _Attack_Hit, _SwordRay, 1 << 9);
    }
}
