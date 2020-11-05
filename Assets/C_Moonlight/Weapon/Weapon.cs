using Pixeye.Unity;
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
    public WeaponSetting _WeaponSetting;
    public Player _Player;
    //public Weapon_Attack _Attack;
    [Foldout("換武器", true)]
    public Weapon_Type_enum _NowType = Weapon_Type_enum.Fist;//現在手上拿的武器
    public List<Weapon_Type_enum> _TypeList = new List<Weapon_Type_enum>();//武器欄
    public GameObject[] _Weapon_Type;
    public static bool _Pick_Weapon = false;//開啟撿武器的Tag
    public Weapon_UI _Weapon_UI;//武器UI script
    void Start()
    {

    }
    void Update()
    {
        _WeaponSetting.nowWeapon = _NowType;
        Weapon._Pick_Weapon = false;//常駐關閉撿武器的Tag
        if (Input.GetKeyDown(KeyCode.Alpha1) && _Player._Renderer._Player_AM.GetBool("Jump Trigger") == false)
        {
            if (_TypeList[0] != Weapon_Type_enum.Fist && _TypeList[1] != Weapon_Type_enum.Fist)//1，2武器欄都有武器才可交換
            {
                this.Chang_Type(0);
            }
            if (Player_Trigger._Intag)//進入範圍內才可撿武器
            {
                _Pick_Weapon = true;
                Debug.Log(_Pick_Weapon);
                this.SetType(Player_Trigger._NewType, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _Player._Renderer._Player_AM.GetBool("Jump Trigger") == false)
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
        if(_NowType==Weapon_Type_enum.Shield)
            Shield_Block();
    }
    void SetType(Weapon_Type_enum eType, int chWeapon)
    {
        _Weapon_Type[(int)_NowType].SetActive(false);
        _TypeList[chWeapon] = eType;
        _NowType = eType;
        _Weapon_Type[(int)_TypeList[chWeapon]].SetActive(true);
        _Weapon_UI.Chang_weapon(chWeapon);//傳入武器
        _Weapon_UI.Pick_Weapon(eType, chWeapon);//傳入武器圖片
    }
    public void Chang_Type(int open)
    {
        _Weapon_Type[(int)_NowType].SetActive(false);
        _NowType = _TypeList[open];
        _Weapon_Type[(int)_TypeList[open]].SetActive(true);
        _Weapon_UI.Chang_weapon(open);//傳入武器
    }
    public void Shield_Block()
    {
        if (Physics.CheckSphere(_Weapon_Type[(int)_NowType].transform.position, _WeaponSetting._Block_r, 1 << 11))
        {
            _Player._Renderer._Player_AM.SetBool("Shield", true);
        }
        if (Physics.CheckSphere(_Weapon_Type[(int)_NowType].transform.position, _WeaponSetting._Block_r, 1 << 13) && _Player._PlayerSetting._ShieldBool == false)
        {
            _Player._Renderer._Player_AM.SetTrigger("Bulletshield");
        }
        if(!Physics.CheckSphere(_Weapon_Type[(int)_NowType].transform.position, _WeaponSetting._Block_r, 1 << 11 | 1 << 13))
            _Player._Renderer._Player_AM.SetBool("Shield", false);
    }
}
