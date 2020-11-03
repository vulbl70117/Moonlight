using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Trigger : MonoBehaviour
{
    public Weapon_Type_enum _Type = Weapon_Type_enum.Fist;
    //public bool _Weapon_BadyBool;
    public Player _Player;
    //private GameObject _Anything;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}
    private void Update()
    {
        if (_Player._PlayerSetting._ShieldBool == true)
            _Player._Renderer._Player_AM.SetBool("Shield1", false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (_Type == Weapon_Type_enum.Shield)
        {
            if (other.gameObject.CompareTag("Machine") || other.gameObject.CompareTag("Bullet"))
            {
                if (_Player._PlayerSetting._ShieldBool == false)
                    _Player._Renderer._Player_AM.SetBool("Shield1",true);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (_Type == Weapon_Type_enum.Shield)
        {
            if (_Player._PlayerSetting._ShieldBool == true)
            {
                
                    _Player._Renderer._Player_AM.SetBool("Shield1", false);
            }
        }
    }
    //public void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Machine"))
    //    {
    //        _Weapon_BadyBool = false;
    //    }
    //}
}
