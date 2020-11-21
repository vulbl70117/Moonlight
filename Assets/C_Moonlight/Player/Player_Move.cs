﻿//using Packages.Rider.Editor;
using Pixeye.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Player_2D
{
    Right = 0,
    Left,
    Evade
}
public class Player_Move : MonoBehaviour
{
    private Player _Player;
    public float _Camera_Time;
    public bool _SliedSport;
    [Foldout("重力", true)]
    public bool _GravityBool;
    public float _Gravity = -9.81f;
    public float _Acceleration_01 = 0f;
    public float _Acceleration_02;
    public float _Height_02 ;
    public bool _Jump_AinTrigger;
    [Foldout("迴避", true)]
    public bool _EvadeBool_01;
    private float _NowEvadeTime_02;
    private float _EvadeTime_02;
    [Foldout("射線", true)]
    public bool _IsGround;
    //public bool _IsGround_01;
    public bool _IsWall;
    public bool _IsHeadWall;
    public float _Tall = 1.5f;
    public float _Wall = 1.5f;
    public float _HeadWall = 0.5f;
    public float _Grounddistance = 0.4f;
    public float _Distance;
    public float _Airdistance = 3f;
    public RaycastHit Y_HitDown;
    public RaycastHit Y_HitUp;
    public RaycastHit Y_HitR;
    public RaycastHit Y_HitL;
    public RaycastHit Y_HitWall;
    //public RaycastHit Y_HitWall1;
    //public LayerMask _LayerMask;
    [Foldout("Transform", true)]
    public Transform _Move_Player_ModTF;
    public Transform _Move_Player_Grund;
    public Transform _Move_Player_RFeet;
    public Transform _Move_Player_LFeet;
    public Transform _Move_Player_Head;
    public Transform _Move_Player_Dash;
    private Collider _Move_Player_CD;
    public Vector3 _Move_Player_;
    private Vector3 _Move_Player_VT;
    //public bool _JumpBool;
    //public float _JumpTime_01 = 1f;
    //public float _JumpTime_02;
    //public float _Height_01 = 10f;
    //public float _EavdeSpeed_2D = 5f;
    //public float _EavdeSpeed_3D = 5f;
    //public float _UseEvadeTime_01 = 0.5f;
    //public float _EvadeTime_01 = 0.6f;
    [Foldout("特效", true)]
    public GameObject Dash_smoke;///
    void Start()
    {
        _Move_Player_CD = GetComponent<Collider>();
        _Player = GetComponent<Player>();
    }
    void Update()
    {
        IsGround();
        
        //_IsGround = Physics.Raycast(transform.position
        //                           , -transform.up
        //                           , out Y_HitDown
        //                           , _Grounddistance
        //                           , 1 << 10);
        //if(Physics.Raycast(_Move_Player_Feet.position, -_Move_Player_Feet.up, out Y_HitR, 1 << 10))
        //{
        //    _Distance = Vector3.Distance(_Move_Player_Feet.position, Y_HitR.point);
        //    if (_Distance < 2f)
        //        _IsGround_01 = true;
        //    else
        //        _IsGround_01 = false;
        //}
        Wall();
        Jump();
        if (_GravityBool)
            Gravity();
        if(_Player._DashBool)
            Dash();
        
        //_IsHeadWall = Physics.Raycast(_Move_Player_Head.position, _Move_Player_Head.up, out Y_HitUp, _HeadWall, 1<<10);
        OutPlane();
        TuchGround();
        _IsHeadWall = Physics.CheckSphere(_Move_Player_Head.position, _HeadWall, 1 << 10);
        _Move_Player_ = transform.position;
    }
    private void LateUpdate()
    {
    }
    public void Move2D(Player_2D _2D, float speed, bool isTrue = false)
    {
        if (_Move_Player_CD == null)
            return;
        switch (_2D)
        {
            case Player_2D.Right:
                {

                    if (_IsWall == false && _Player._PlayerSetting._ShieldBool == false)
                        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, 90, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Left:
                {
                    if (_IsWall == false && _Player._PlayerSetting._ShieldBool == false)
                        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, -90, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Evade:
                {
                    GameObject _smoke = Instantiate(Dash_smoke);
                    if (Dash_smoke)
                    {
                        _smoke.transform.position = _Move_Player_Grund.transform.position;
                        _smoke.transform.rotation = _Move_Player_Grund.transform.rotation;
                        Destroy(_smoke, 3);
                    }
                    _Move_Player_VT = new Vector3(transform.position.x + (_Move_Player_ModTF.rotation.y >= 0 ? speed : -speed)
                                                    , transform.position.y
                                                    , transform.position.z);
                    Camera_Time();
                    break;
                }
        }
    }
    public void UseEvade_Time()
    {
        //GameObject _smoke = Instantiate(Dash_smoke);
        //if(Dash_smoke)
        //{
        //    _smoke.transform.position = _Move_Player_Feet.transform.position;
        //    _smoke.transform.rotation = _Move_Player_Feet.transform.rotation;
        //    Destroy(_smoke, 3);
        //}

        if (Time.time > _NowEvadeTime_02 + _Player._PlayerSetting._UseEvadeTime)
        {
             Move2D(Player_2D.Evade, _Player._PlayerSetting._EavdeVT_Y);
            _NowEvadeTime_02 = Time.time;
            _EvadeTime_02 = _Player._PlayerSetting._EvadeTime_01;
            _EvadeBool_01 = true;
        }
        
    }
    public void Evadeing()
    {
        if (_Move_Player_CD)
        {
            if (_EvadeTime_02 > 0)
            {
                _Player._Renderer.Player_Anim(Player_Animator.Dash, true);
                _EvadeTime_02 -= Time.deltaTime;
                _Move_Player_CD.isTrigger = true;
                transform.position = Vector3.Lerp(transform.position
                                                  , _Move_Player_VT
                                                  , _Player._PlayerSetting._EavdeSpeed_2D * Time.deltaTime);
            }
            if (_EvadeTime_02 < 0 && _Player._Trigger._Evade_ToMachine == false)
            {
                _Player._DashBool = false;
                _Player._Renderer.Player_Anim(Player_Animator.Dash, false);
                _EvadeBool_01 = false;
                if (_IsWall == true)
                    _Move_Player_CD.isTrigger = false;
            }
            Slide();
        }
    }
    public void Slide()
    {
        if (_Player._Trigger._Evade_ToMachine == true && _EvadeTime_02 <= 0.2f)
        {
            _Move_Player_VT = new Vector3(transform.position.x
                                          + (_Move_Player_ModTF.rotation.y >= 0
                                             ? _Player._PlayerSetting._SlideVT_Y
                                             : -_Player._PlayerSetting._SlideVT_Y)
                                           , transform.position.y
                                           , transform.position.z);
            transform.position = Vector3.Lerp(transform.position
                                              , _Move_Player_VT
                                              , _Player._PlayerSetting._EavdeSpeed_2D * Time.deltaTime);
        }
    }
    public void Gravity()
    {
        _Acceleration_02 += _Gravity * Time.deltaTime;
        _Height_02 = _Acceleration_02 * Time.deltaTime;
        transform.Translate(transform.up * _Height_02);
    }
    public void IsGround()
    {
        if (Physics.Raycast(_Move_Player_LFeet.position, -_Move_Player_LFeet.up, out Y_HitL, _Distance, 1 << 10)
            || Physics.Raycast(_Move_Player_RFeet.position, -_Move_Player_RFeet.up, out Y_HitR, _Distance, 1 << 10))
        {
            _IsGround = true;
        }
        else
            _IsGround = false;
    }
    public void TuchGround()
    {
        if (_IsGround && _Player._Renderer._Player_AM.GetBool("Jump") == false)
        {
            if (Physics.Raycast(transform.position, -transform.up, out Y_HitDown, _Grounddistance, 1 << 10))
            {
                transform.position = new Vector3(transform.position.x, Y_HitDown.point.y + _Tall, transform.position.z);
            }
            else if (Y_HitR.collider != null && !Physics.Raycast(transform.position, -transform.up, out Y_HitDown, _Grounddistance, 1 << 10))
            {
                transform.position = new Vector3(transform.position.x, Y_HitR.point.y + _Tall, transform.position.z);
            }
            else if (Y_HitL.collider != null && Y_HitR.collider == null && !Physics.Raycast(transform.position, -transform.up, out Y_HitDown, _Grounddistance, 1 << 10))
            {
                Debug.Log("X");
                transform.position = new Vector3(transform.position.x, Y_HitL.point.y + _Tall, transform.position.z);
            }
        }
    }
    public void Jump()
    {
        if (_Acceleration_02 < 0)
        {
            _Player._Renderer.Player_Anim(Player_Animator.Jump, false);
            //if(_IsGround_01==false)
            _Player._Renderer.Player_Anim(Player_Animator.JumpDown, true);
        }
        if (_IsGround && _Acceleration_02 < 0)
        {
            _Player._Renderer.Player_Anim(Player_Animator.JumpDown, false);
            //transform.position = new Vector3(transform.position.x, Y_HitDown.point.y + _Tall, transform.position.z);
            _GravityBool = false;
            _Player._JumpBool = false;
            _Jump_AinTrigger = false;
            _Acceleration_02 = _Acceleration_01;
        }
        else if (_IsGround != true)
            _GravityBool = true;
        if (_Player._JumpBool && _IsHeadWall == false)
        {
            _Height_02 = _Player._PlayerSetting._Height_01 * Time.deltaTime;
            //height_02 raycast length

            // V3 new_up = mathf.min (hit.point, transform.up*_height_02)
            transform.Translate(transform.up * _Height_02);
        }
        if (_IsHeadWall)
        {
            _Player._JumpBool = false;
            _Jump_AinTrigger = false;
                //_Acceleration_02 = _Acceleration_01;
        }
        //if (_Player._JumpBool)
        //{
        //    _Height_02 = _Player._PlayerSetting._Height_01 * Time.deltaTime ;
        //    transform.Translate(transform.up * _Height_02);
        //}
    }
    //public void Jump_Up()
    //{
    //    _Jump_AinTrigger = true;
    //    _GravityBool = true;
    //    _Acceleration_02 = _Height_02;
    //    _JumpBool = true;
    //    _JumpTime_02 = _JumpTime_01;
    //}
    //public void Jump_Continued()
    //{
    //    if (_JumpTime_02 >= 0 && _JumpBool == true)
    //    {
    //        _JumpTime_02 -= Time.deltaTime;
    //        _Acceleration_02 = _Height_01;
    //    }
    //}
    public void Camera_Time()
    {
        _Camera_Time = 0;
    }
    public void OutPlane()
    {
        if (_IsGround == false && _Acceleration_02 < -80)
        {
            if (Physics.Raycast(_Move_Player_ + transform.up
                                , -transform.up
                                , out Y_HitUp, Vector3.Distance(transform.position, _Move_Player_) + 1 +10, 1 << 10))
            {
                transform.position = new Vector3(transform.position.x, Y_HitUp.point.y + _Tall, transform.position.z);
                _Acceleration_02 = _Acceleration_01;
            }
        }
    }
    public void Dash()
    {
        Debug.DrawLine(_Move_Player_ - _Move_Player_Dash.forward, (_Move_Player_ - _Move_Player_Dash.forward) + (_Move_Player_Dash.forward) * (Vector3.Distance(transform.position, _Move_Player_) + 1), Color.red, 1f);
        //if(Physics.Raycast(_Move_Player_Dash.position - _Move_Player_Dash.forward * 5, /*_Move_Player_Dash.position - _Move_Player_Dash.forward * 5 + */_Move_Player_ModTF.forward , out p, z, 1 << 10))
        if (Physics.Raycast(_Move_Player_ - _Move_Player_Dash.forward, _Move_Player_Dash.forward, Vector3.Distance(transform.position,_Move_Player_)+1+ _Wall, 1 << 10))
            {
            transform.position = _Move_Player_;
            _EvadeBool_01 = false;
            _Player._DashBool = false;
            _Player._Renderer.Player_Anim(Player_Animator.Dash, false);
        }
    }
    public void Wall()
    {
        if (_Player._Weapon._NowType != Weapon_Type_enum.Shield)
        {
            if (Physics.Raycast(_Move_Player_ModTF.position + _Move_Player_ModTF.up * 1.3f, _Move_Player_ModTF.forward, out Y_HitWall, _Wall, 1 << 10 | 1 <<11 | 1 <<14)
                || Physics.Raycast(_Move_Player_ModTF.position, _Move_Player_ModTF.forward, out Y_HitWall, _Wall, 1 << 10 | 1 << 11 | 1 << 14))
            {
                _IsWall = true;
            }
            else
                _IsWall = false;
        }
        else
        {
            if (Physics.Raycast(_Move_Player_ModTF.position + _Move_Player_ModTF.up * 1.3f, _Move_Player_ModTF.forward, out Y_HitWall, _Wall, 1 << 10 | 1 << 11)
                || Physics.Raycast(_Move_Player_ModTF.position, _Move_Player_ModTF.forward, out Y_HitWall, _Wall, 1 << 10 | 1 << 11))
            {
                _IsWall = true;
            }
            else
                _IsWall = false;
        }
    }
}
