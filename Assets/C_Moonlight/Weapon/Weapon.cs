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
    public Weapon_Type_enum _NowType = Weapon_Type_enum.Fist;
    public GameObject[] _Weapon_Type;
    public List<Weapon_Type_enum> _TypeList = new List<Weapon_Type_enum>();//武器欄
    public Weapon_Trigger _Weapon_TG;

    public weapon weapon_UI;//武器UI script
    public static bool pick_weapon = false;//開啟撿武器的Tag
    void Start()
    {
        _Weapon_TG = transform.GetChild(0).GetComponent<Weapon_Trigger>();
    }
    void Update()
    {
        chang_Weapon_TG();
        pick_weapon = false;//常駐關閉撿武器的Tag

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_TypeList[0] != Weapon_Type_enum.Fist && _TypeList[1] != Weapon_Type_enum.Fist)//1，2武器欄都有武器才可交換
            {
                this.changType(0);
            }
            if (Player_Trigger.intag)//進入範圍內才可撿武器
            {
                pick_weapon = true;
                this.SetType(Player_Trigger._NewType, 0);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_TypeList[0] != Weapon_Type_enum.Fist && _TypeList[1] != Weapon_Type_enum.Fist)
            {
                this.changType(1);
            }
            if (Player_Trigger.intag)
            {
                pick_weapon = true;
                this.SetType(Player_Trigger._NewType, 1);
            }
        }
    }
    void SetType(Weapon_Type_enum eType, int chWeapon)
    {
        _Weapon_Type[(int)_NowType].SetActive(false);
        _TypeList[chWeapon] = eType;
        _NowType = eType;
        _Weapon_Type[(int)_TypeList[chWeapon]].SetActive(true);
        weapon_UI.Chang_weapon(chWeapon);//傳入武器

    }
    public void changType(int open)
    {
        _Weapon_Type[(int)_NowType].SetActive(false);
        _NowType = _TypeList[open];
        _Weapon_Type[(int)_TypeList[open]].SetActive(true);
        weapon_UI.Chang_weapon(open);//傳入武器
    }

    public void chang_Weapon_TG()
    {
        if (_NowType == Weapon_Type_enum.Fist)
        {
            _Weapon_TG = _Weapon_Type[0].GetComponent<Weapon_Trigger>();
        }
        if (_NowType == Weapon_Type_enum.Sword)
        {
            _Weapon_TG = _Weapon_Type[1].GetComponent<Weapon_Trigger>();
        }
        if (_NowType == Weapon_Type_enum.Axe)
        {
            _Weapon_TG = _Weapon_Type[2].GetComponent<Weapon_Trigger>();
        }
    }
}
