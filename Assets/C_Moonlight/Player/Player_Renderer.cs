using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Player_Animator
{
    Run,
    Attack,
    Jump,
    JumpDown,
    JumpIdle,
    BeAttack,
    Dash
}
public class Player_Renderer : MonoBehaviour
{
    public float _HP = 30f;
    public Animator _Player_AM;
    private Animator _Fist_AM;
    public Weapon _Weapon;
    private Player _Player;
    public float _BeAttack_DelayTime_01;
    public float _BeAttack_DelayTime_02;
    //private float _NowTime;

    public AnimatorOverrideController[] OverrideController;

    void Start()
    {
        _Player = GetComponent<Player>();
        _Fist_AM = _Player_AM;
        _BeAttack_DelayTime_02 = _BeAttack_DelayTime_01;
    }
    void Update()
    {
        Player_Anim(Player_Animator.Run);
        if (_Weapon._NowType == Weapon_Type_enum.Axe)
        {
            _Player_AM.runtimeAnimatorController = OverrideController[0];
        }
        if (_Weapon._NowType == Weapon_Type_enum.Fist)
        {
            _Player_AM = _Fist_AM;
        }
         _BeAttack_DelayTime_02 -= Time.deltaTime;
    }
    public void BeAttack()
    {
        _HP--;
        Debug.Log("剩餘" + _HP);
        Player_Anim(Player_Animator.BeAttack);
        if (_BeAttack_DelayTime_02 ==_BeAttack_DelayTime_01)
        {
            _Player._BeAttackBool = true;
        }
        else if (_BeAttack_DelayTime_02 < 0)
        {
            _Player._BeAttackBool = false;
            _BeAttack_DelayTime_02 = _BeAttack_DelayTime_01;

        }
        if (_HP < 0)
            gameObject.SetActive(false);
    }
    public void Player_Anim(Player_Animator _Animator,bool isTrue = false)
    {
        if (_Player_AM == null)
            return;
        switch (_Animator)
        {
            case Player_Animator.Run:
                {
                    if (_Player._RunBool)
                    {
                        _Player_AM.SetBool("Run", true);
                    }
                    else if (_Player._RunBool == false)
                    {
                        _Player_AM.SetBool("Run", false);
                    }
                    break;
                }
            case Player_Animator.Attack:
                {
                    _Player_AM.SetTrigger("Attack");
                    break;
                }
            case Player_Animator.Jump:
                {
                    _Player_AM.SetBool("Jump", isTrue);
                    break;
                }
            case Player_Animator.JumpDown:
                {
                    _Player_AM.SetBool("JumpDown", isTrue);
                    break;
                }
            case Player_Animator.JumpIdle:
                {
                    _Player_AM.SetTrigger("Jump Trigger");
                    break;
                }
            case Player_Animator.BeAttack:
                {
                    _Player_AM.SetTrigger("BeAttack");
                    break;
                }
            case Player_Animator.Dash:
                {
                    _Player_AM.SetBool("Dash", isTrue);
                    break;
                }
        }
    }
    public bool Ground_Already()
    {
        if (_Player_AM)//check
        {
            return _Player_AM.GetBool("Jump Trigger");
        }
        return false;
    }
}
