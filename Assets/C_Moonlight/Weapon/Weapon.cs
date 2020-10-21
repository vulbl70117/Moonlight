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
    public Weapon_Type_enum _NowType = Weapon_Type_enum.Fist;//現在手上拿的武器
    public List<Weapon_Type_enum> _TypeList = new List<Weapon_Type_enum>();//武器欄
    public GameObject[] _Weapon_Type;
    public static bool _Pick_Weapon = false;//開啟撿武器的Tag
    //public Weapon_UI _Weapon_UI;//武器UI script
    public Weapon_Trigger _Weapon_TG;
    public Weapon_Attack _Attack;
    void Start()
    {
    }
    void Update()
    {
        Chang_Weapon_TG();
        _Pick_Weapon = false;//常駐關閉撿武器的Tag

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_TypeList[0] != Weapon_Type_enum.Fist && _TypeList[1] != Weapon_Type_enum.Fist)//1，2武器欄都有武器才可交換
            {
                this.Chang_Type(0);
            }
            if (Player_Trigger._Intag)//進入範圍內才可撿武器
            {
                _Pick_Weapon = true;
                this.SetType(Player_Trigger._NewType, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_TypeList[0] != Weapon_Type_enum.Fist && _TypeList[1] != Weapon_Type_enum.Fist)
            {
                this.Chang_Type(1);
            }
            if (Player_Trigger._Intag)
            {
                _Pick_Weapon = true;
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
        //_Weapon_UI.Chang_weapon(chWeapon);//傳入武器
        //_Weapon_UI.Pick_Weapon(eType, chWeapon);//傳入武器圖片

    }
    public void Chang_Type(int open)
    {
        _Weapon_Type[(int)_NowType].SetActive(false);
        _NowType = _TypeList[open];
        _Weapon_Type[(int)_TypeList[open]].SetActive(true);
        //_Weapon_UI.Chang_weapon(open);//傳入武器
    }

    public void Chang_Weapon_TG()
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
