using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Machine_Move : MonoBehaviour
{
    //
    public float _Move_Time_01 = 3f;
    private float _Move_Time_02;
    public float _Move_Idle_Time_01 = 1f;
    private float _Move_Idle_Time_02 = 0f;
    public float _Move_Speed = 5f;
    public float _Shoot_Time_01 = 1f;
    private float _Shoot_Time_02;
    private float _Distance;
    public float _Stop_Time_01 = 2f;
    private float _Stop_Time_02;
    //
    private bool _MoveBool = true;
    public bool _StopBool = false;
    public bool _DetectBool = false;
    //
    private NavMeshAgent _Machion_NMA;
    //
    public Transform _Player_TF;
    private Transform _Machine_TF;
    //
    private Machine_DrawGizmos _DrawGizmos;
    //
    private Machine_Attack _Attack;
    //
    private GameObject _Pos;
    //private Vector3 _MachineOri_TF;
    void Start()
    {
        _Machion_NMA = GetComponent<NavMeshAgent>();
        _DrawGizmos = GetComponent<Machine_DrawGizmos>();
        _Attack = GetComponent<Machine_Attack>();
        _Pos = transform.GetChild(0).gameObject;
        _Machine_TF = GetComponent<Transform>();
        _Move_Time_02 = _Move_Time_01;
        _Stop_Time_02 = _Stop_Time_01;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Machion_Chase()
    {
        _Machion_NMA.SetDestination(_Player_TF.position);
    }
    public void Move_Time()
    {
        if (_Move_Time_02 >= 0)
        {
            _Move_Time_02 -= Time.deltaTime;
            Move_Idle();
        }
    }
    public void Move_Idle()
    {
        if (_Move_Idle_Time_02 <= _Move_Idle_Time_01)
        {
            _Move_Idle_Time_02 += Time.deltaTime;
            _Machine_TF.position += Vector3.forward * (_MoveBool ? 1 : -1) * Time.deltaTime * _Move_Speed;
        }
        else if (_Move_Time_02 <= 0)
        {
            _MoveBool = !_MoveBool;
            _Move_Time_02 = _Move_Time_01;
            if (_MoveBool)
                _Machine_TF.rotation = Quaternion.Euler(0, 360, 0);
            else
                _Machine_TF.rotation = Quaternion.Euler(0, 180, 0);
            _Move_Idle_Time_02 = 0;
        }
    }
    public void Move_Reset()
    {
        _Move_Time_02 = _Move_Time_01;
        _Move_Idle_Time_02 = 0f;
    }
    public void Ground()
    {
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);

        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            Move_Time();
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else if (_Distance < _DrawGizmos._Detect_Radius && _Distance > _DrawGizmos._Attack_Radius)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            Machion_Chase();
        }
        else if (_Distance < _DrawGizmos._Attack_Radius)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Attack();
        }
    }
    public void Attack()
    {
        if (Time.time > _Shoot_Time_02 + _Shoot_Time_01)
        {
            _Pos.transform.LookAt(_Player_TF);
            _Shoot_Time_02 = Time.time;
            _Attack.Shoot();
        }
    }
    public void Fly()
    {
        Stop_Time();
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);
        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            Move_Time();
        }
        else if (_Distance < _DrawGizmos._Detect_Radius && _DetectBool == false)
        {
            Dive();
        }
        else if (_DetectBool)
        {
            Back();
        }
    }
    public void Dive()
    {
        if (_Stop_Time_02 == _Stop_Time_01 && _Attack._DiveBool_02==false)
            transform.position = Vector3.Lerp(transform.position, _Player_TF.position, Time.deltaTime * _Move_Speed);
        transform.LookAt(_Player_TF);
        if (_Attack._DiveBool_01 || _Attack._DiveBool_02)
        {
            _Shoot_Time_02 = _Shoot_Time_01;
            _StopBool = true;
        }
        if (_Stop_Time_02 < 0)
            _DetectBool = true;
    }
    public void Back()
    {
        _Shoot_Time_02 -= Time.deltaTime;
        Vector3 pos = transform.GetChild(0).transform.position;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        if (_Shoot_Time_02 <= 0)
        {
            _Stop_Time_02 = _Stop_Time_01;
            _DetectBool = false;
            _StopBool = false;
        }
    }
    public void Stop_Time()
    {
        if (_StopBool)
            _Stop_Time_02 -= Time.deltaTime;
    }
}
