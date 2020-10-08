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
    private bool _Can_Evade = true;
    //
    private float _Player_Move_Speed = 5;
    //
    public To2D3D _Change = To2D3D.to2D;
    //    
    private Transform _Player_Mod;
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
            if (_Move && _Can_Evade)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && _Move._EvadeBool_01 == false)
                {
                    _Move.Evade_Time();
                }
                if (_Move._EvadeBool_01 == true)
                {
                    _Move.Evade_ToMachine();
                }
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
        _Change = To2D3D.to2D;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (Input.GetKey(KeyCode.D))
        {
            _Move.Move2D(Player_2D.Right, _Player_Move_Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _Move.Move2D(Player_2D.Left, -_Player_Move_Speed);
        }
    }
    public void Move_3D()
    {
        _Change = To2D3D.to3D;
        if (Input.GetKey(KeyCode.D))
        {
            _Move.Move3D(Player_3D.Right, _Player_Move_Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _Move.Move3D(Player_3D.Left, -_Player_Move_Speed);
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
            _Can_Evade = true;
        }
        if(_Weapon._nowType == Weapon_Type.Shield)
        {
            _Can_Evade = false;
        }
    }
}
