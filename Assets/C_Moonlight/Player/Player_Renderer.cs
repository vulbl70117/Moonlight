﻿using System.Collections;
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
    private float _BeAttack_DelayTime_02;
    public float _Now_HP;
    public bool _BeAttackBool;
    public bool _IsMachine;
    public Animator _Player_AM;
    public AudioSource _Walk_AS;
    public AudioClip[] _AudioClip;///
    public AudioSource _AudioSource;///
    public Weapon _Weapon;
    private Player _Player;
    void Start()
    {
        _Player = GetComponent<Player>();
        _Walk_AS = GetComponent<AudioSource>();///
        _BeAttack_DelayTime_02 = _Player._PlayerSetting._BeAttack_DelayTime_01;
        _Now_HP = _Player._PlayerSetting._HP;
    }
    void Update()
    {
        //if (_Player._PlayerSetting._ShieldBool == true)
        //{

        //}
        Player_Anim(Player_Animator.Run);
        Change_Anim();
        if (_BeAttackBool == true)
            AnimTime_BeAttack();
    }
    public void BeAttack()
    {
        _IsMachine = true;
        if (_Player_AM.GetBool("Jump Trigger"))//beattack re Jump Trigger
        {
            _Player_AM.ResetTrigger("Jump Trigger");
        }
        _BeAttackBool = true;
        Player_Anim(Player_Animator.BeAttack);
        _Now_HP--;
        Debug.Log("剩餘" + _Now_HP);
        _Player._RunBool = false;
        if (_Now_HP <= 0)///
            gameObject.SetActive(false);
        if (_Player_AM && _Player._Move._IsGround ==false)//check
        {
            _Player_AM.GetBool("Jump Trigger");
        }
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
                        if (!_Walk_AS.isPlaying)
                            _Walk_AS.Play();
                    }
                    else if (_Player._RunBool == false)
                    {
                        _Player_AM.SetBool("Run", false);
                            _Walk_AS.Stop();
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
                    _Walk_AS.Stop();
                    break;
                }
            case Player_Animator.JumpDown:
                {
                    _Player_AM.SetBool("JumpDown", isTrue);
                    _Walk_AS.Stop();
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
    public void AnimTime_BeAttack()
    {
        if (_BeAttack_DelayTime_02 <= _Player._PlayerSetting._BeAttack_DelayTime_01)
        {
            _BeAttack_DelayTime_02 -= Time.deltaTime;
        }
        if (_BeAttack_DelayTime_02 <= 0 /*&& _Player_AM.GetCurrentAnimatorStateInfo(0).IsName("BeAttack")*/)
        {
            _BeAttack_DelayTime_02 = _Player._PlayerSetting._BeAttack_DelayTime_01;
            _BeAttackBool = false;
        }
    }
    public void Change_Anim()///
    {
        _Player_AM.runtimeAnimatorController = _Player._PlayerSetting.OverrideController[(int)_Weapon._NowType];
        _Player_AM.SetFloat("Speed", _Player._PlayerSetting._SpeedMultiplier[(int)_Weapon._NowType]);
    }
}
