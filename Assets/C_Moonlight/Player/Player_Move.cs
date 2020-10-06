﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Player_2D
{
    Right = 0,
    Left,
    Evade
}
public enum Player_3D
{
    Forward,
    Back,
    Right,
    Left,
    Evade
}
public class Player_Move : MonoBehaviour
{
    public float _UseEvadeTime_01 = 0.5f;
    public float _EvadeTime_01 = 0.25f;
    private float _NowEvadeTime_02;
    private float _EvadeTime_02;
    public float _EavdeSpeed;
    //
    public bool _EvadeBool_01;
    //
    private Transform _Move_Player_TF;
    private Rigidbody _Move_Player_RD;
    private Collider _Move_Player_CD;
    //
    private Player_Trigger _Trigger;

    void Start()
    {
        _Move_Player_TF = GetComponent<Transform>();
        _Move_Player_RD = GetComponent<Rigidbody>();
        _Move_Player_CD = GetComponent<Collider>();
        _Trigger = GetComponent<Player_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move2D(Player_2D _2D, bool isTrue = false)
    {
        if (_Move_Player_RD == null)
            return;
        switch (_2D)
        {
            case Player_2D.Right:
                {
                    _Move_Player_TF.Translate(0, 0, 5 * Time.deltaTime);
                    _Move_Player_TF.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
            case Player_2D.Left:
                {
                    _Move_Player_TF.Translate(0, 0, 5 * Time.deltaTime);
                    _Move_Player_TF.rotation = Quaternion.Euler(0, 360, 0);
                    break;
                }
            case Player_2D.Evade:
                {

                    _Move_Player_RD.velocity = _Move_Player_TF.forward * _EavdeSpeed;
                    _Move_Player_RD.useGravity = false;
                    _Move_Player_CD.isTrigger = true;
                    break;
                }
        }
    }
    public void Move3D(Player_3D _3D, bool isTrue = false)
    {
        if (_Move_Player_RD == null)
            return;
    }
    public void Evade_Time()
    {
        if (Time.time > _NowEvadeTime_02 + _UseEvadeTime_01)
        {
            Move2D(Player_2D.Evade);
            _NowEvadeTime_02 = Time.time;
            _EvadeTime_02 = _EvadeTime_01;
            _EvadeBool_01 = true;
        }
    }
    public void Evade_ToMachine()
    {
        if (_Move_Player_RD)
        {
            _EvadeTime_02 -= Time.deltaTime;
            if ((_EvadeTime_02 < 0 && _Trigger._Evade_ToMachine == false))
            {
                _EvadeBool_01 = false;
                _Move_Player_RD.useGravity = true;
                _Move_Player_RD.isKinematic = true;
                _Move_Player_CD.isTrigger = false;
            }
        }
    }
}
