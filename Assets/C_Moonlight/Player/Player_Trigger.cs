using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trigger : MonoBehaviour
{
    public Weapon weapon;

    public bool _To2D;
    public bool _To3D;
    public bool _Evade_ToMachine = false;

    public GameObject _Camera_2D;
    public GameObject _Camera_3D;

    public static Weapon_Type_enum _NewType = Weapon_Type_enum.Fist;//把偵測到的武器先存起來
    public static bool _Intag = false;//是否在武器感應範圍內
    void Start()
    {
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            Evade_Trigger();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "To2D")
        {
            _To2D = true;
            Camera_2D();
        }
        else if(other.gameObject.tag == "To3D")
        {
            _To3D = true;
            Camera_3D();
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            Weapon_Collision weapon_coll = other.gameObject.GetComponent<Weapon_Collision>();
            _Intag = true;
            
            if(weapon_coll._Type == Weapon_Type_enum.Sword)
            {
                _NewType = Weapon_Type_enum.Sword;

                if (Weapon._Pick_Weapon == true)
                {
                    _Intag = false;
                    other.gameObject.SetActive(false);
                }
            }
            else if (weapon_coll._Type == Weapon_Type_enum.Axe)
            {
                _NewType = Weapon_Type_enum.Axe;

                if (Weapon._Pick_Weapon == true)
                {
                    _Intag = false;
                    other.gameObject.SetActive(false);
                }
            }
        }    
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            _Evade_ToMachine = false;
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            _Intag = false;
        }
    }
    private void Camera_2D()
    {
        _Camera_2D.SetActive(true);
        _Camera_3D.SetActive(false);
    }
    private void Camera_3D()
    {
        _Camera_3D.SetActive(true);
        _Camera_2D.SetActive(false);
    }
    private void Evade_Trigger()
    {
        _Evade_ToMachine = true;
    }
}
