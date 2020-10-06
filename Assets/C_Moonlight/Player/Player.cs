using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum To2D3D
{
    to2D,
    to3D
}

public class Player : MonoBehaviour
{
    private int floor;
    //Player
    private bool _Can_Jump = true;
    //
    public To2D3D _Change = To2D3D.to2D;
    //    
    public Transform _Player_Mod;
    //
    private Rigidbody _Player_RD;
    //
    private Player_Collision _Collision;
    //
    private Player_Move _Move;
    //
    private Player_Trigger _Trigger;
    //
    private Player_Evade _Evade;
    //
    private Player_Jump _Jump;
    //
    //private Player_Attack _Attack;
    //
    //Machine
    private Machine _Machine;
    //
    //Weapon
    private Weapon _Weapon;
    //private GameObject _Weapon_All;
    
    private GameObject _Any;
    void Start()
    {
        //Player
        _Player_RD = GetComponent<Rigidbody>();
        _Collision = GetComponent<Player_Collision>();
        _Move = GetComponent<Player_Move>();
        _Trigger = GetComponent<Player_Trigger>();
        _Evade = GetComponent<Player_Evade>();
        _Jump = GetComponent<Player_Jump>();
        //_Attack = GetComponent<Player_Attack>();
        //Machin
        
        //Weapon
        _Weapon = GetComponentInChildren<Weapon>();
        //_Weapon_All = GetComponentInChildren<GameObject>();
        //
        
        
    }

    void Update()
    {
        Weapon_();
        if (_Jump)
        {
            _Jump.Jump();
        }
        if (_Evade && _Can_Jump)
        {
            _Evade.Evade();
        }
        if (_Weapon)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_Weapon._Weapon_TG._Weapon_BadyBool == true)
                {
                    _Machine._HP.BeAttack();
                    _Machine._HP._StrikeBool = false;
                }
            }
        }
        
        
    }
    private void FixedUpdate()
    {
        _Player_RD.isKinematic = false;
        if (_Trigger != null)
        {
            if (_Change == To2D3D.to2D || _Trigger._To2D)
            {
                _Change = To2D3D.to2D;
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                _Move.Move_2D();
            }
            if (_Change == To2D3D.to3D || _Trigger._To3D)
            {
                _Change = To2D3D.to3D;
            }
        }
        
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.GetComponent<Machine>();
        
    }
    public void Weapon_()
    {
        if (_Weapon._nowType == Weapon_Type.Fist)
        {
            _Can_Jump = true;
        }
        if(_Weapon._nowType == Weapon_Type.Shield)
        {
            _Can_Jump = false;
        }
    }
}
