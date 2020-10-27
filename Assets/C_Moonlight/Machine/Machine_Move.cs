using Pixeye.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Machine_Move : MonoBehaviour
{
    public Enemy_Type _Type;
    private float _Distance;
    public bool _MoveAnim;
    public Machine _Machine;
    [Foldout("巡邏", true)]
    public float _Move_AllTime_01 = 3f;
    private float _Move_AllTime_02;
    public float _Move_Patrol_Time_01 = 1f;
    private float _Move_Patrol_Time_02 = 0f;
    public float _Move_Speed = 5f;
    public float _Move_Rotat = 5f;
    private bool _MoveBool = true;
    [Foldout("攻擊", true)]
    public float _Attack_Time_01 = 1f;
    private float _Attack_Time_02;
    public float _Stop_Time_01 = 2f;
    private float _Stop_Time_02;
    public float _Dive_Speed = 3f;
    public bool _StopBool = false;
    public bool _DetectBool = false;
    [Foldout("Transform", true)]
    public Transform _Player_TF;
    public Transform _Machine_TF;
    public GameObject _Pos;
    public Vector3 _Machine_VT;
    public Vector3 _Player_VT;
    void Start()
    {
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
            _MoveAnim = false;
            Move_Time();
        }
    }
    public void Move_Time()
    {
        if (_Move_Patrol_Time_02 <= _Move_Patrol_Time_01)
        {
            _MoveAnim = true;
            _Move_Patrol_Time_02 += Time.deltaTime;
            transform.position += transform.forward
                                    * (_MoveBool ? 1 : -1)
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
        //if (_Machine._Renderer._MaterialBool == false)
        {
            if (_Distance > _Machine._DrawGizmos._Detect_Radius)
                {
                     //Move_Patrol();
                }
            else if (_Distance < _Machine._DrawGizmos._Detect_Radius
                     && _Distance > _Machine._DrawGizmos._Attack_Radius)
                {
                    _MoveAnim = true;//
                    Machion_Chase();
                }
            if (_Distance < _Machine._DrawGizmos._Attack_Radius)
                {
                    _MoveAnim = false;//
                    Aim();
                }
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
        _Machine._Attack.Fire();
        transform.rotation = Quaternion.LookRotation(_Machine_VT);

    }
    public void Fly()
    {
        Stop_Time();
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);
        if (_Distance > _Machine._DrawGizmos._Detect_Radius)
        {
            _Player_VT = _Player_TF.position;
            Move_FlyReset();
            Move_Patrol();
        }
        else if (_Distance < _Machine._DrawGizmos._Detect_Radius && _DetectBool == false)
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
        if (_Attack_Time_02 == _Attack_Time_01 && _Machine._Attack._DiveBool_02 == false)
        {
            transform.position = Vector3.Lerp(transform.position
                                              , _Player_VT
                                              , Time.deltaTime * _Dive_Speed);
        }
        _Machine_TF.LookAt(_Player_VT);
        float x= Vector3.Distance(transform.position, _Player_VT);
            Debug.Log(x);
        if (x<=1)
        //if (_Machine._Attack._DiveBool_01 || _Machine._Attack._DiveBool_02)
        {
            _StopBool = true;
            _Stop_Time_02 = _Stop_Time_01;
        }
        if (_Attack_Time_02 < 0)
        {
            _DetectBool = true;
        }
    }
    public void Back()
    {
        if (_Stop_Time_02 <= _Stop_Time_01)
        {
            _Stop_Time_02 += Time.deltaTime;
        }
        _Stop_Time_02 -= Time.deltaTime;
        Vector3 pos = transform.GetChild(0).transform.position;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        _Machine_TF.rotation = Quaternion.Euler(0,90,0);
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
        //_Machine._Attack._DiveBool_01 = false;
        //_Machine._Attack._DiveBool_02 = false;
        _StopBool = false;
    }
    public void Move_GroundReset()
    {
        _Machine._Attack._Now_AttackTime = 0;
    }
}
