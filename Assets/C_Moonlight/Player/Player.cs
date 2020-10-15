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
    public bool _RunBool;
    public bool _Jump=false;
    //
    private float _Move_Speed = 5;
    public float _JumpRay = 0.15f;
    //
    public To2D3D _Change = To2D3D.to2D;
    //    
    public GameObject _Player_Camera3D;
    //
    public Collider _Player_CD;
    //
    public Player_Move _Move;
    public Player_Trigger _Trigger;
    public Player_Renderer _Renderer;
    //Machine
    private Machine _Machine;
    //
    //Weapon
    private Weapon _Weapon;
    private GameObject _Any;

    void Start()
    {
        
        _Player_CD = GetComponent<Collider>();
        _Move = GetComponent<Player_Move>();
        _Trigger = GetComponent<Player_Trigger>();
        _Renderer = GetComponent<Player_Renderer>();

        _Weapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        //Weapon_();
        if (_Move)
        {
            Jump();
        }
        if (_Weapon)
        {
            //Attack();
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
            if (Input.GetKeyDown(KeyCode.LeftShift) && _Move._EvadeBool_01 == false)
            {
                _Move.UseEvade_Time();
            }
            if (_Move._EvadeBool_01 == true)
            {
                _Move.Evade_ToMachine();
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
            //if (Input.GetKeyDown(KeyCode.LeftShift) && _Move._EvadeBool_01 == false)
            //{
            //    _Move.UseEvade_Time();
            //}
            //if (_Move._EvadeBool_01 == true)
            //{
            //    _Move.Evade_ToMachine();
            //}
        }
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.GetComponent<Machine>();
        
    }
    //public void Weapon_()
    //{
    //    if (_Weapon._NowType == Weapon_Type_enum.Fist)
    //    {
    //        _Can_Evade = true;
    //    }
    //    if(_Weapon._NowType == Weapon_Type_enum.Shield)
    //    {
    //        _Can_Evade = false;
    //    }
    //}
    //public void Attack()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //if (_Weapon._Weapon_TG._Weapon_BadyBool == true)
    //        {
    //            Weapon_Factory weapon_Factory = null;
    //            float damga = weapon_Factory.Hurt();
    //            //_Machine._HP.BeAttack();
    //            _Machine._HP._StrikeBool = false;
    //        }
    //    }
    //}
    public void Jump()
    {
        _Move.Jump();
        if (Input.GetKeyDown(KeyCode.Space) && _Move._IsGround == true)
        {
            _Jump = true;
            _Renderer.Player_Anim(Player_Animator.Jump, true);
            _Move.Jump_Up();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _Move.Jump_Continued();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _Move._JumpBool = false;
        }
    }
}
