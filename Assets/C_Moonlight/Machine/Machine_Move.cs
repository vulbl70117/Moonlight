using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Machine_Move : MonoBehaviour
{
    public Enemy_Type _Type;
    //
    public float _Move_AllTime_01 = 3f;
    private float _Move_AllTime_02;
    public float _Move_Patrol_Time_01 = 1f;
    private float _Move_Patrol_Time_02 = 0f;
    public float _Move_Speed = 5f;
    public float _Attack_Time_01 = 1f;
    private float _Attack_Time_02;
    private float _Distance;
    public float _Stop_Time_01 = 2f;
    private float _Stop_Time_02;
    public float _Move_Rotat = 5f;
    //
    private bool _MoveBool = true;
    public bool _StopBool = false;
    public bool _DetectBool = false;
    //
    private Quaternion _Machion_QR;
    //
    public Transform _Player_TF;
    private Transform _Machine_TF;
    //
    private Machine_DrawGizmos _DrawGizmos;
    //
    private Machine_Attack _Attack;
    //
    public GameObject _Pos;
    //
    private Rigidbody rd;
    public Vector3 _Machine_VT;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        _DrawGizmos = GetComponent<Machine_DrawGizmos>();
        _Attack = GetComponent<Machine_Attack>();
        //_Pos = transform.GetChild(0).gameObject;
        _Machine_TF = GetComponent<Transform>();
        _Move_AllTime_02 = _Move_AllTime_01;
        if (_Type == Enemy_Type.Ground)
        {
            Move_GroundReset();
        }
        if (_Type == Enemy_Type.Fly)
        {
            Move_FlyReset();
        }
    }

    void Update()
    {
    }
    public void Move_Patrol()
    {
        if (_Move_AllTime_02 >= 0)
        {
            _Move_AllTime_02 -= Time.deltaTime;
            Move_Time();
        }
    }
    public void Move_Time()
    {
        if (_Move_Patrol_Time_02 <= _Move_Patrol_Time_01)
        {
            _Move_Patrol_Time_02 += Time.deltaTime;
            _Machine_TF.position += _Machine_TF.forward
                                    * (_MoveBool ? 1 : 1)
                                    * Time.deltaTime
                                    * _Move_Speed;
        }
        else if (_Move_AllTime_02 <= 0)
        {
            _MoveBool = !_MoveBool;
            Move_Reset();
            if (_MoveBool)
                _Machine_TF.rotation = Quaternion.Euler(0, 90, 0);
            else
                _Machine_TF.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
    public void Move_Reset()
    {
        _Move_AllTime_02 = _Move_AllTime_01;
        _Move_Patrol_Time_02 = 0f;
    }
    public void Ground()
    {
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);//距離

        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            //Move_Patrol();
        }
        else if (_Distance < _DrawGizmos._Detect_Radius
                 && _Distance > _DrawGizmos._Attack_Radius)
        {
            Machion_Chase();
        }
        if (_Distance < _DrawGizmos._Attack_Radius)
        {
            Aim();
        }
    }
    public void Machion_Chase()
    {
        _Machine_VT = Vector3.ProjectOnPlane(_Player_TF.position - transform.position, transform.up);
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
        transform.rotation=Quaternion.LookRotation(_Machine_VT);
    }
    public void Aim()
    {
        _Machine_VT = Vector3.ProjectOnPlane(_Player_TF.position - transform.position, transform.up);
        _Pos.transform.rotation = Quaternion.LookRotation(_Machine_VT);
        _Attack.Fire();
        transform.rotation = Quaternion.LookRotation(_Machine_VT);

    }
    public void Fly()
    {
        Stop_Time();
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);
        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            Move_FlyReset();
            Move_Patrol();
        }
        else if (_Distance < _DrawGizmos._Detect_Radius && _DetectBool == false)
        {
            Dive();
        }
        if (_DetectBool)
        {
            Back();
        }
    }
    public void Dive()
    {
        if (_Attack_Time_02 == _Attack_Time_01 && _Attack._DiveBool_02==false)
            transform.position = Vector3.Lerp(transform.position,
                                              _Player_TF.position,
                                              Time.deltaTime * _Move_Speed);
        transform.LookAt(_Player_TF);
        if (_Attack._DiveBool_01 || _Attack._DiveBool_02)
        {
            _Stop_Time_02 = _Stop_Time_01;
            _StopBool = true;
        }
        if (_Attack_Time_02 < 0)
        {
            _DetectBool = true;

        }
    }
    public void Back()
    {
        _Stop_Time_02 -= Time.deltaTime;
        Vector3 pos = transform.GetChild(0).transform.position;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        if (_Stop_Time_02 <= 0)
        {
            _Attack_Time_02 = _Attack_Time_01;
            _DetectBool = false;
            _StopBool = false;
        }
    }
    public void Stop_Time()
    {
        if (_StopBool)
            _Attack_Time_02 -= Time.deltaTime;
    }
    public void Move_FlyReset()
    {
        _Attack_Time_02 = _Attack_Time_01;
        _Stop_Time_02 = 0;
        _Attack._DiveBool_01 = false;
        _Attack._DiveBool_02 = false;
        _StopBool = false;
    }
    public void Move_GroundReset()
    {
        _Attack._Now_AttackTime = 0;
    }
}
