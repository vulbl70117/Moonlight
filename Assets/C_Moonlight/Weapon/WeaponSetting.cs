using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="WeaponSetting",menuName ="ScriptableObject/WeaponSetting")]
public class WeaponSetting : ScriptableObject
{
    public Weapon_Type_enum nowWeapon = Weapon_Type_enum.Fist;
    public List<WeaponData> WeaponDataList;
    public float[] _WeaponRay;
    public float _Block_r;
    public bool _AttackHit;
}
[Serializable]
public class WeaponData
{
    public float AttackStartTime;
    public float AttackEndTime;
}
