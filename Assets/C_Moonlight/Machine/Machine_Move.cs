using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Move : MonoBehaviour
{
    public float _Move_Time_01;
    private float _Move_Time_02;
    public float _Move_Idle_Time_01 = 1f;
    private float _Move_Idle_Time_02 = 0f;
    private bool _MoveBool=true;
    public float _Move_Speed = 5f;


    private Transform _Machine_TF;
    //private Vector3 _MachineOri_TF;
    void Start()
    {
        _Machine_TF = GetComponent<Transform>();
        _Move_Time_02 = _Move_Time_01;
        
    }

    // Update is called once per frame
    void Update()
    {
        //_Machine_TF.Translate(_Machine_TF.forward* Mathf.Sin(Time.time * 2) * Time.deltaTime);
        //_Machine_TF.position = _MachineOri_TF + new Vector3(0, 0, Mathf.Sin(Time.time*0.5f)*5);
    }
    public void Move_Time()
    {
        //if (_MoveBool)
        //{
        //    if (_Move_Time_02 >= 0)
        //    {
        //        _Move_Time_02 -= Time.deltaTime;
        //        _Machine_TF.rotation = Quaternion.Euler(0, 180, 0);
        //        Move_Idle_Forward();
        //    }
        //}
        //else
        //{
        //    if (_Move_Time_02 <= _Move_Time_01)
        //    {
        //        _Move_Time_02 += Time.deltaTime;
        //        _Machine_TF.rotation = Quaternion.Euler(0, 360, 0);
        //        Move_Idle_Back();
        //    }
        //}
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
            _Machine_TF.position += Vector3.forward * (_MoveBool ? 1:-1) * Time.deltaTime * _Move_Speed;
        }
        else if (_Move_Time_02 <= 0)
        {
            _MoveBool = !_MoveBool;
            _Move_Time_02 = _Move_Time_01;
            if(_MoveBool)
                _Machine_TF.rotation = Quaternion.Euler(0, 360, 0);
            else
                _Machine_TF.rotation = Quaternion.Euler(0, 180, 0);

            _Move_Idle_Time_02 = 0;
        }
    }
    //public void Move_Idle_Forward()
    //{
    //    if (_Move_Idle_Time_02 <= _Move_Idle_Time_01)
    //    {
    //        _Move_Idle_Time_02 += Time.deltaTime;
    //        _Machine_TF.position += Vector3.forward * Time.deltaTime * _Move_Speed;
    //    }
    //    else if (_Move_Time_02 <= 0)
    //    {
    //        _MoveBool = false;
    //    }
    //}
    //public void Move_Idle_Back()
    //{
    //    if (_Move_Idle_Time_02 >= 0)
    //    {
    //        _Move_Idle_Time_02 -= Time.deltaTime;
    //        _Machine_TF.position += Vector3.back * Time.deltaTime * _Move_Speed;
    //    }
    //    else if (_Move_Time_02 >= _Move_Time_01)
    //    {
    //        _MoveBool = true;
    //    }
    //}
    public void Move_Reset()
    {
        _Move_Time_02 = _Move_Time_01;
        _Move_Idle_Time_02 = 0f;
    }
}
