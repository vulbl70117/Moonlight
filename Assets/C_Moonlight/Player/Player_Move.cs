using System.Collections;
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
    public To2D3D _Move_Change = To2D3D.to2D;
    public float _Camera_Time;
    //
    public bool _EvadeBool_01;
    public bool _IsGround;
    public bool _GravityBool;
    public bool _JumpBool;
    //
    public float _Height_01 = 10f;
    public float _Acceleration_01 = 0f;
    private float _Acceleration_02;
    public float _JumpTime_01 = 1f;
    private float _JumpTime_02;
    //
    private float _Height_02;
    private float _Gravity = -9.81f;
    public float _Grounddistance = 0.4f;
    //
    public float _EavdeSpeed_2D = 5f;
    public float _EavdeSpeed_3D = 5f;
    public float _UseEvadeTime_01 = 0.5f;
    private float _NowEvadeTime_02;
    public float _EvadeTime_01 = 0.6f;
    private float _EvadeTime_02;
    //
    public Transform _Move_Player_ModTF;
    public Transform _Move_Player_Feet;
    public Transform _Boos;
    public Collider _Move_Player_CD;
    public Vector3 _Move_Player_VT;
    //
    public Player_Trigger _Move_Trigger;
    void Start()
    {
        _Move_Player_CD = GetComponent<Collider>();
        _Move_Trigger = GetComponent<Player_Trigger>();
    }
    void Update()
    {
        Gravity();
    }
    public void Move2D(Player_2D _2D, float speed, bool isTrue = false)
    {
        if (_Move_Player_CD == null)
            return;
        switch (_2D)
        {
            case Player_2D.Right:
                {
                    transform.Translate(transform.right * Time.deltaTime * speed);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, 0, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Left:
                {
                    transform.Translate(transform.right * Time.deltaTime * speed);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, 180, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Evade:
                {
                    _Move_Player_VT=new Vector3(transform.position.x + (_Move_Player_ModTF.rotation.y == 0 ? speed : -speed), transform.position.y, transform.position.z);
                    Camera_Time();
                    break;
                }
        }
    }
    public void Move3D(Player_3D _3D, float speed, bool isTrue = false)
    {
        if (_Move_Player_CD == null)
            return;
        switch (_3D)
        {
            case Player_3D.Forward:
                {
                    break;
                }
            case Player_3D.Back:
                {
                    break;
                }
            case Player_3D.Right:
                {
                    transform.RotateAround(_Boos.position, _Boos.up, speed * Time.deltaTime);
                    _Move_Player_ModTF.localRotation = Quaternion.Euler(0, 90, 0);
                    break;
                }
            case Player_3D.Left:
                {
                    transform.RotateAround(_Boos.position, _Boos.up, speed * Time.deltaTime);
                    _Move_Player_ModTF.localRotation = Quaternion.Euler(0, -90, 0);
                    break;
                }
            case Player_3D.Evade:
                {
                    _Move_Player_VT = new Vector3(transform.position.x + (_Move_Player_ModTF.localRotation.y > 0 ? speed : speed), transform.position.y, transform.position.z/* + (_Move_Player_ModTF.localRotation.y == 90 ? -speed : speed)*/);
                    break;
                }
        }
    }
    public void UseEvade_Time()
    {
        if (Time.time > _NowEvadeTime_02 + _UseEvadeTime_01)
        {
            if (_Move_Change == To2D3D.to2D)
            {
                Move2D(Player_2D.Evade, _EavdeSpeed_2D);
            }
            if (_Move_Change == To2D3D.to3D)
            {
                Move3D(Player_3D.Evade, _EavdeSpeed_3D);
            }
            _NowEvadeTime_02 = Time.time;
            _EvadeTime_02 = _EvadeTime_01;
            _EvadeBool_01 = true;
        }
    }
    public void Evade_ToMachine()
    {
        if (_Move_Player_CD)
        {
            if (_EvadeTime_02 > 0)
            {
                _EvadeTime_02 -= Time.deltaTime;
                _Move_Player_CD.isTrigger = true;
                transform.position = Vector3.Lerp(transform.position, _Move_Player_VT, 10 * Time.deltaTime);
            }
            if (_EvadeTime_02 < 0 && _Move_Trigger._Evade_ToMachine == false)
            {
                _EvadeBool_01 = false;
                _Move_Player_CD.isTrigger = false;
            }
        }
    }
    public void Gravity()
    {
        _Acceleration_02 += _Gravity * Time.deltaTime;
        _Height_02 = _Acceleration_02 * Time.deltaTime;
        transform.Translate(transform.up * _Height_02);

    }
    public void Jump()
    {
        _IsGround = Physics.CheckSphere(_Move_Player_Feet.position, _Grounddistance, 1 << 10);
        if(_IsGround && _Acceleration_02 < 0)
        {
            _Acceleration_02 = _Acceleration_01;
            _GravityBool = false;
        }
        else if (_IsGround != true)
        {
            _GravityBool = true;
        }
    }
    public void Jump_Up()
    {
        _GravityBool = true;
        _Acceleration_02 = _Height_01;
        _JumpBool = true;
        _JumpTime_02 = _JumpTime_01;
    }
    public void Jump_Continued()
    {
        if (_JumpTime_02 >= 0 && _JumpBool == true)
        {
            _JumpTime_02 -= Time.deltaTime;
            _Acceleration_02 = _Height_01;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Machine"))
        {
            _Acceleration_02 = 0;
        }
    }
    public void Camera_Time()
    {
        _Camera_Time = 0;
    }
}
