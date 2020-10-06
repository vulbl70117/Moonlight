using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public float _JumpPower = 5f;
    public float _BufferPower = 0.01f;
    public float _JumpTime_01 = 0.5f;
    public float _JumpTime_02;
    private float _Player_Tall = 1.5f;
    //
    public bool _JumpBool_01;
    public bool _JumpBool_02;
    public bool _Buffer;
    //
    private Rigidbody _Player_RD;
    //
    private Transform _Player_TF;
    //
    public float hitdistance = 2f;
    public bool _IsGrounded;
    public LayerMask layer;
    //
    private RaycastHit hit_Y;
    void Start()
    {
        _Player_RD = GetComponent<Rigidbody>();
        _Player_TF = GetComponent<Transform>();
    }
    public void Jump()
    {
        Jump_Ray();
        if (_Player_RD.velocity.y < 0 && _Buffer && _JumpBool_01)
        {
            _Player_TF.position = new Vector3(_Player_TF.position.x,hit_Y.point.y + _Player_Tall, _Player_TF.position.z);
            _JumpBool_01 = false;
        }
    }
    public void Jump_Ray()
    {
        if (Physics.Raycast(transform.position, -transform.up,out hit_Y, hitdistance, layer))
        {
            _IsGrounded = true;
            _Buffer = true;
        }
        else
        {
            _IsGrounded = false;
            _Buffer = false;
        }
    }
    public void Jump_Up()
    {
        _JumpBool_01 = true;
        _JumpBool_02 = true;
        _JumpTime_02 = _JumpTime_01;
        _Player_RD.velocity = Vector3.up * _JumpPower;
    }
    public void Jump_Continued()
    {
        if (_JumpTime_02 >= 0 && _JumpBool_02 == true)
        {
            _Player_RD.velocity = Vector3.up * _JumpPower;
            _JumpTime_02 -= Time.deltaTime;
        }
    }
}
