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

    public float _EavdeSpeed;
    public float _Camera_Time;
    //
    private Transform _Move_Player_TF;
    public Transform _Move_Player_ModTF;
    private Rigidbody _Move_Player_RD;
    private Collider _Move_Player_CD;
    //
    private Vector3 _Move_Player_VT;
    public Transform _Boos;
    //
    //private Player_Trigger _Trigger;

    void Start()
    {
        _Move_Player_TF = GetComponent<Transform>();
        _Move_Player_RD = GetComponent<Rigidbody>();
        _Move_Player_CD = GetComponent<Collider>();
        //_Trigger = GetComponent<Player_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move2D(Player_2D _2D, float speed, bool isTrue = false)
    {
        _Move_Player_VT = new Vector3(_Move_Player_TF.position.x, _Move_Player_TF.position.y, _Move_Player_TF.position.z + speed * Time.deltaTime );
        if (_Move_Player_RD == null)
            return;
        switch (_2D)
        {
            case Player_2D.Right:
                {
                    _Move_Player_RD.MovePosition(_Move_Player_VT);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, 0, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Left:
                {
                    _Move_Player_RD.MovePosition(_Move_Player_VT);
                    _Move_Player_ModTF.rotation = Quaternion.Euler(0, 180, 0);
                    Camera_Time();
                    break;
                }
            case Player_2D.Evade:
                {
                    _Move_Player_RD.velocity = _Move_Player_TF.forward * _EavdeSpeed;
                    _Move_Player_RD.useGravity = false;
                    _Move_Player_CD.isTrigger = true;
                    Camera_Time();
                    break;
                }
        }
    }
    public void Move3D(Player_3D _3D, float speed, bool isTrue = false)
    {
        if (_Move_Player_RD == null)
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
                    _Move_Player_TF.RotateAround(_Boos.position, _Boos.up, speed * Time.deltaTime);
                    //_Move_Player_ModTF.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    break;
                }
            case Player_3D.Left:
                {
                    _Move_Player_TF.RotateAround(_Boos.position, _Boos.up, speed * Time.deltaTime);
                    //_Move_Player_ModTF.rotation = Quaternion.Euler(0, -90, 0);
                    break;
                }
            case Player_3D.Evade:
                {
                    _Move_Player_TF.RotateAround(_Boos.position, _Boos.up, speed * Time.deltaTime /** _EavdeSpeed*/);
                    _Move_Player_RD.useGravity = false;
                    _Move_Player_CD.isTrigger = true;
                    break;
                }
        }
    }
    public void Camera_Time()
    {
        _Camera_Time = 0;
    }
}
