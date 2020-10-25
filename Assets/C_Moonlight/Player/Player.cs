using Pixeye.Unity;
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
    
    public Weapon _Weapon;
    public To2D3D _Change = To2D3D.to2D;
    public GameObject _Player_Camera3D;
    [Foldout("Player", true)]
    public PlayerSetting _PlayerSetting;
    private bool _Can_Evade = true;
    public bool _RunBool = false;
    public bool _JumpBool = false;
    public bool _DashBool = false;
    public bool _Player_GroundAttacking = false;
    public float _Move_Speed = 5;
    [Foldout("Script", true)]
    public Player_Move _Move;
    public Player_Trigger _Trigger;
    public Player_Renderer _Renderer;
    public Player_Attack _Attack;
    void Start()
    {
        _Attack = GetComponent<Player_Attack>();
        _Move = GetComponent<Player_Move>();
        _Trigger = GetComponent<Player_Trigger>();
        _Renderer = GetComponent<Player_Renderer>();
        _Weapon = GetComponentInChildren<Weapon>();
    }
    void Update()
    {
        Weapon_();
        if (_Move)
        {
            Jump();
        }
        if (_Weapon)
        {
            Attack();
        }
        if ((_Change == To2D3D.to2D || _Trigger._To2D) && _Renderer._BeAttackBool == false)
        {
            Sport_2D();
        }
        if ((_Change == To2D3D.to3D || _Trigger._To3D) && _Renderer._BeAttackBool == false)
        {
            Sport_3D();
        }
        if (!_Renderer._Player_AM.GetBool("GroundAttacking"))
        {
            _Player_GroundAttacking = false;
        }
    }
    private void FixedUpdate()
    {
        if (_Trigger != null)
        {
            if ((_Change == To2D3D.to2D || _Trigger._To2D) && _Renderer._BeAttackBool == false)
            {
                Move_2D();
            }
            if ((_Change == To2D3D.to3D || _Trigger._To3D) && _Renderer._BeAttackBool == false)
            {
                Move_3D();
            }
        }
    }
    public void Move_2D()
    {
        _Change = To2D3D.to2D;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        _RunBool = false;
        if (_Move._IsGround && _Player_GroundAttacking)
            return;
        if (_DashBool == false)
        {
            if (Input.GetKey(KeyCode.D) && _Renderer._BeAttackBool == false)
            {
                _RunBool = true;
                _Move.Move2D(Player_2D.Right, _Move_Speed);
            }
            if (Input.GetKey(KeyCode.A) && _Renderer._BeAttackBool == false)
            {
                _RunBool = true;
                _Move.Move2D(Player_2D.Left, -_Move_Speed);
            }
        }
    }
    public void Sport_2D()
    {
        if (_Move && _Can_Evade && _Renderer._BeAttackBool == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _Move._EvadeBool_01 == false)
            {
                _DashBool = false;
                _Move.UseEvade_Time();
            }
            else if (_Move._EvadeBool_01 == true)
            {
                _DashBool = true;
                _Move.Evade_ToMachine();
            }
        }
    }
    public void Move_3D()
    {
        _RunBool = false;
        _Change = To2D3D.to3D;
        if (Input.GetKey(KeyCode.D))
        {
            _RunBool = true;
            _Move.Move3D(Player_3D.Right, -_Move_Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _RunBool = true;
            _Move.Move3D(Player_3D.Left, _Move_Speed);
        }
    }
    public void Sport_3D()
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
    public void Weapon_()
    {
        if (_Weapon._NowType == Weapon_Type_enum.Fist
            || _Weapon._NowType == Weapon_Type_enum.Sword
            || _Weapon._NowType == Weapon_Type_enum.Axe)
        {
            _Can_Evade = true;
        }
        if (_Weapon._NowType == Weapon_Type_enum.Shield)
        {
            _Can_Evade = false;
        }
    }
    public void Attack()
    {
        if (_Renderer._Player_AM.GetBool("Attacking") && _Weapon._Attack._IsRay)
        {
            _Attack._Machine._Renderer.BeAttack(1);
            _Weapon._WeaponSetting._AttackHit = true;

        }
        else if (_Renderer._Player_AM.GetBool("Attacking") == false && _Weapon._WeaponSetting._AttackHit && _Weapon._Attack._IsRay)
        {
            _Attack._Machine._Renderer._StrikeBool = false;
            _Weapon._WeaponSetting._AttackHit = false;
        }
        if (Input.GetMouseButtonDown(0) && !_Player_GroundAttacking)
        {
            if (_Move._IsGround)
                _Player_GroundAttacking = true;
            _Renderer.Player_Anim(Player_Animator.Attack);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) 
            && _Renderer._Player_AM.GetBool("Jump Trigger") == false
            && _Move._IsGround == true 
            && _Move._Jump_AinTrigger == false
            && _Player_GroundAttacking == false)
        {
            _JumpBool = true;
            if (_JumpBool)
                _Renderer.Player_Anim(Player_Animator.JumpIdle, true);
            _Renderer.Player_Anim(Player_Animator.Jump, true);
            _Renderer.Player_Anim(Player_Animator.JumpDown, true);
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    _Move.Jump_Continued();
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    _Move._JumpBool = false;
        //}
    }
}
