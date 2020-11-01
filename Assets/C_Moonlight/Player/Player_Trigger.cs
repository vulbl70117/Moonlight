using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trigger : MonoBehaviour
{
    public bool _To2D;
    //public bool _IsBullet;
    public bool _Evade_ToMachine = false;

    public GameObject _Camera_2D;
    public GameObject _Camera_3D;
    public Player _Player;

    public static Weapon_Type_enum _NewType = Weapon_Type_enum.Fist;//把偵測到的武器先存起來
    public static bool _Intag = false;//是否在武器感應範圍內
    void Start()
    {
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            _Evade_ToMachine = true;
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            Weapon_Collision weapon_coll = other.gameObject.GetComponent<Weapon_Collision>();
            _Intag = true;

            if (weapon_coll._Type == Weapon_Type_enum.Sword)
            {
                _NewType = Weapon_Type_enum.Sword;
                if (Weapon._Pick_Weapon == true)
                {
                    other.gameObject.SetActive(false);
                    _Intag = false; 
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "To2D")
        {
            _To2D = true;
            Camera_2D();
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            _Player._Renderer._IsMachine = false;
            _Player._Renderer._AudioSource.PlayOneShot(_Player._Renderer._AudioClip[0]);        
        }
        if (other.gameObject.CompareTag("Machine"))
        {
            if (_Player._Renderer._IsMachine)
            {
                _Player._Renderer._IsMachine = false;
                _Player._Renderer._AudioSource.PlayOneShot(_Player._Renderer._AudioClip[1]);
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
}
