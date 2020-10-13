using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Weapon_Type_enum
{
    Fist,
    Sword,
    Axe,
    Shield
}

public class Weapon : MonoBehaviour
{
    
    //private bool _FistBool;
    //private bool _ShieldBool;
    public Weapon_Type_enum _NowType = Weapon_Type_enum.Fist;
    public GameObject[] _Weapon_Type;
    //public Weapon_Trigger _Weapon_TG;
    // Start is called before the first frame update
    void Start()
    {
        //_Weapon_TG = transform.GetChild(0).GetComponent<Weapon_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _Weapon_Type[(int)_NowType].SetActive(false);
            _NowType = Weapon_Type_enum.Sword;
            _Weapon_Type[(int)_NowType].SetActive(true);
            //_Weapon_TG = transform.GetChild(0).GetComponent<Weapon_Trigger>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _Weapon_Type[(int)_NowType].SetActive(false);
            _NowType = Weapon_Type_enum.Axe;
            _Weapon_Type[(int)_NowType].SetActive(true);
            //_Weapon_TG = transform.GetChild(1).GetComponent<Weapon_Trigger>();
        }
    }
    public void SwitchWeapon(string name)
    {
        
    }
}
