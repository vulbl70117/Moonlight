using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{
    public bool _IsRay;

    public float _FistRay = 0.5f;
    public float _SwordRay = 0.8f;
    public float _AxeRay = 1f;

    public Transform _Ray_TF;

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
        
    }
    public void WeaponRay()
    {
        _IsRay = Physics.Raycast(transform.position, _Ray_TF.forward, out _Attack_Hit
                                 , _Weapon._WeaponSetting._WeaponRay[(int)_Weapon._WeaponSetting.nowWeapon], 1 << 9);
    }
}
