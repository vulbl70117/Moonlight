using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Type : MonoBehaviour
{
    [System.Serializable]
    public class Factory
    {
        public Weapon_Type_enum _Weapon_enum;
        public Weapon _Weapon;
    }
    public List<Factory> _Factory_list;
    public Weapon_Factory C(Weapon_Type_enum weapon_Type_Enum)
    {
        //Factory p = _Factory_list.Find(x => x._Weapon_enum == weapon_Type_Enum);
        switch (weapon_Type_Enum)
        {
            case Weapon_Type_enum.Fist:
                gameObject.SetActive(true);
                break;
            case Weapon_Type_enum.Sword:
                gameObject.SetActive(true);
                break;
            case Weapon_Type_enum.Axe:
                gameObject.SetActive(true);
                break;
            case Weapon_Type_enum.Shield:
                gameObject.SetActive(true);
                break;

        }
        if (weapon_Type_Enum == Weapon_Type_enum.Shield) { }
        return null;
    }
}
