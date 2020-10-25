using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{
    public bool _IsRay;
    public Transform _Ray_TF;
    private GameObject _Anything;
    public RaycastHit _Attack_Hit;
    public LayerMask _LayerMask;

    public Weapon _Weapon;
    void Start()
    {
        _Weapon = GetComponent<Weapon>();
    }
    private void Awake()
    {
        
    }
    void Update()
    {
        WeaponRay();
        if (_IsRay)
        {
            _Anything = _Attack_Hit.transform.gameObject;
            _Weapon._Player._Attack.Machine(_Anything);
        }
    }
    public void WeaponRay()
    {
        _IsRay = Physics.Raycast(transform.position, _Ray_TF.forward, out _Attack_Hit
                                 , _Weapon._WeaponSetting._WeaponRay[(int)_Weapon._WeaponSetting.nowWeapon], _LayerMask);
    }
}
