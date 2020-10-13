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
    //Player
    public bool _EvadeBool_01;
    private bool _Can_Evade = true;
    public bool _RunBool;
    //
    public float _UseEvadeTime_01 = 0.5f;
    public float _EvadeTime_01 = 0.25f;
    private float _NowEvadeTime_02;
    public float _EvadeTime_02;
    private float _Move_Speed = 5;
    //
    public To2D3D _Change = To2D3D.to2D;
    //    
    public GameObject _Player_Camera3D;
    //
    private Collider _Player_CD;
    //
    private Rigidbody _Player_RD;
    //
    public Player_Move _Move;
    //
    public Player_Trigger _Trigger;
    //
    private Player_Jump _Jump;
    //
    public Player_Renderer _Renderer;
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
        _Player_RD = GetComponent < Rigidbody>();
        _Player_CD = GetComponent<Collider>();
        _Move = GetComponent<Player_Move>();
        _Trigger = GetComponent<Player_Trigger>();
        _Jump = GetComponent<Player_Jump>();
        _Renderer = GetComponent<Player_Renderer>();
        
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
            _RunBool = false;
            Jump();
        }
        if (_Weapon)
        {
            Attack();
        }
        if (_Change == To2D3D.to2D || _Trigger._To2D)
        {
            Sport_2D();
        }
        if(_Change == To2D3D.to3D || _Trigger._To3D)
        {
            Sport_3D();
        }
    }
    private void FixedUpdate()
    {
        _Player_RD.isKinematic = false;
        if (_Trigger != null)
        {
            if (_Change == To2D3D.to2D || _Trigger._To2D)
            {
                Move_2D();
            }
            if (_Change == To2D3D.to3D || _Trigger._To3D)
            {
                Move_3D();
            }
        }
        
    }
    public void Move_2D()
    {
        _RunBool = false;
        _Change = To2D3D.to2D;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (Input.GetKey(KeyCode.D))
        {
            _RunBool = true;
            _Move.Move2D(Player_2D.Right, _Move_Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _RunBool = true;
            _Move.Move2D(Player_2D.Left, -_Move_Speed);
        }
    }
    public void Sport_2D()
    {
        if (_Move && _Can_Evade)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _EvadeBool_01 == false)
            {
                UseEvade_Time();
            }
            if (_EvadeBool_01 == true)
            {
                Evade_ToMachine();
            }
        }
        
    }
    public void Move_3D()
    {
        _Change = To2D3D.to3D;
        if (Input.GetKey(KeyCode.D))
        {
            _Move.Move3D(Player_3D.Right, -_Move_Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _Move.Move3D(Player_3D.Left, _Move_Speed);
        }
    }
    public void Sport_3D()
    {
        if (_Move && _Can_Evade)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _EvadeBool_01 == false)
            {
                UseEvade_Time();
            }
            if (_EvadeBool_01 == true)
            {
                Evade_ToMachine();
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
        if (_Weapon._NowType == Weapon_Type_enum.Fist)
        {
            _Can_Evade = true;
        }
        if(_Weapon._NowType == Weapon_Type_enum.Shield)
        {
            _Can_Evade = false;
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (_Weapon._Weapon_TG._Weapon_BadyBool == true)
            {
                Weapon_Factory weapon_Factory = null;
                float damga = weapon_Factory.Hurt();
                //_Machine._HP.BeAttack();
                _Machine._HP._StrikeBool = false;
            }
        }
    }
    public void Jump()
    {
        _Jump.Jump();
        if (Input.GetKeyDown(KeyCode.Space) && _Jump._IsGrounded == true)
        {
            _Jump.Jump_Up();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _Jump.Jump_Continued();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _Jump._JumpBool_02 = false;
        }
    }
    public void UseEvade_Time()
    {
        if (Time.time > _NowEvadeTime_02 + _UseEvadeTime_01)
        {
            if (_Change == To2D3D.to2D)
            {   
                _Move.Move2D(Player_2D.Evade, 0);
            }
            if (_Change == To2D3D.to3D)
            {
                _Move.Move3D(Player_3D.Evade, 100);
            }
            _NowEvadeTime_02 = Time.time;
            _EvadeTime_02 = _EvadeTime_01;
            _EvadeBool_01 = true;
        }
    }
    public void Evade_ToMachine()
    {
        if (_Player_RD)
        {
            _EvadeTime_02 -= Time.deltaTime;
            if ((_EvadeTime_02 < 0 && _Trigger._Evade_ToMachine == false))
            {
                _EvadeBool_01 = false;
                _Player_RD.useGravity = true;
                _Player_RD.isKinematic = true;
                _Player_CD.isTrigger = false;
            }
        }
    }
}
