using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public float _JumpPower = 5f;
    public float _JumpTime_01 = 0.5f;
    public float _JumpTime_02;
    //
    public bool _JumpBool_02;
    //
    public Rigidbody _Player_RD;
    void Start()
    {

    }
    public void JumpUp()
    {
        _JumpBool_02 = true;
        _JumpTime_02 = _JumpTime_01;
        _Player_RD.velocity = Vector3.up * _JumpPower;
    }
    public void JumpHolp()
    {
        if (_JumpTime_02 > 0 && _JumpBool_02 == true)
        {
            _Player_RD.velocity = Vector3.up * _JumpPower;
            _JumpTime_02 -= Time.deltaTime;
        }
    }
}
