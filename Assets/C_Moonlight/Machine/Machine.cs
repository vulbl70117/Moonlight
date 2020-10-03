using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum Enemy_Type
{
    Ground,
    Fly
}

public class Machine : MonoBehaviour
{
    public Enemy_Type _Type;
    //
    public float _Shoot_Time_01;
    private float _Shoot_Time_02;
    //
    private float _Distance;
    //
    public bool _DetectBool=false;
    //
    private Transform _Player_TF;
    //
    public Machine_HP _HP;
    //
    private Machine_Move _Move;
    //
    private Machine_DrawGizmos _DrawGizmos;
    //
    private Mahine_AI _AI;
    //
    private Machine_Attack _Attack;
    //
    private GameObject _Pos;
    void Start()
    {
        _Player_TF = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _Move = GetComponent<Machine_Move>();
        _DrawGizmos = GetComponent<Machine_DrawGizmos>();
        _AI = GetComponent<Mahine_AI>();
        _Attack = GetComponent<Machine_Attack>();
        _Pos = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (_Type == Enemy_Type.Ground)
        {
            Ground();
        }
        if (_Type == Enemy_Type.Fly)
        {
            Fiy();
        }
    }
    public void Ground()
    {
        //未偵測到敵人+Bool
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);

        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            _Move.Move_Time();
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else if (_Distance < _DrawGizmos._Detect_Radius && _Distance > _DrawGizmos._Attack_Radius)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            _AI.Machion_Chase();
        }
        else if (_Distance < _DrawGizmos._Attack_Radius)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //if (Time.time > _Shoot_Time_02 + _Shoot_Time_01)
            {
                _Pos.transform.LookAt(_Player_TF);
                _Shoot_Time_02 = Time.time;
                _Attack.Shoot();
            }
        }
    }
    public void Fiy()
    {
        //未偵測到敵人+Bool
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);

        if (_Distance > _DrawGizmos._Detect_Radius)
        {
            _Move.Move_Time();
            _DetectBool = false;
        }
        else if (_Distance < _DrawGizmos._Detect_Radius && _Distance > _DrawGizmos._Attack_Radius)
        {

            if (Time.time > _Shoot_Time_02 + _Shoot_Time_01)
            {
                transform.LookAt(_Player_TF);
                transform.position = Vector3.Lerp(transform.position, _Player_TF.position, Time.deltaTime*5);
                _DetectBool = true;
            }
        }
        if (_Distance < _DrawGizmos._Attack_Radius || _DetectBool)
        {
            _Shoot_Time_02 = Time.time;
            Vector3 pos = transform.GetChild(0).transform.position;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5);
        }
    }
}
