//using Pixeye.Unity;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class Machine_Move : MonoBehaviour
//{
//    //public Enemy_Type _Type;
//    ////
//    //public float _Move_AllTime_01 = 3f;
//    //private float _Move_AllTime_02;
//    //public float _Move_Patrol_Time_01 = 1f;
//    //private float _Move_Patrol_Time_02 = 0f;
//    //public float _Move_Speed = 5f;
//    //public float _Attack_Time_01 = 1f;
//    //private float _Attack_Time_02;
//    //private float _Distance;
//    //public float _Stop_Time_01 = 2f;
//    //private float _Stop_Time_02;
//    //public float _Move_Rotat = 5f;
//    ////
//    //private bool _MoveBool = true;
//    //public bool _StopBool = false;
//    //public bool _DetectBool = false;
//    //public bool _MoveAnim;
//    ////
//    //private Quaternion _Machion_QR;
//    ////
//    //public Transform _Player_TF;
//    //private Transform _Machine_TF;
//    ////
//    //private Machine_DrawGizmos _DrawGizmos;
//    ////
//    public Machine_Attack _Attack;
//    ////
//    //public Machine _Machine;
//    ////
//    //public GameObject _Pos;
//    ////
//    //private Rigidbody rd;
//    //public Vector3 _Machine_VT;
//    //public Vector3 _Player_VT;
//    public Enemy_Type _Type;
//    private float _Distance;
//    public bool _MoveAnim;
//    public Machine _Machine;
//    [Foldout("巡邏", true)]
//    public float _Move_AllTime_01 = 3f;
//    private float _Move_AllTime_02;
//    public float _Move_Patrol_Time_01 = 1f;
//    private float _Move_Patrol_Time_02 = 0f;
//    public float _Move_Speed = 5f;
//    public float _Move_Rotat = 5f;
//    private bool _MoveBool = true;
//    [Foldout("攻擊", true)]
//    public float _Attack_DT;
//    public float _Attack_Time_01 = 1f;
//    private float _Attack_Time_02;
//    public float _Stop_Time_01 = 2f;
//    private float _Stop_Time_02;
//    public float _Dive_Speed = 3f;
//    public bool _StopBool = false;
//    public bool _DetectBool = false;
//    [Foldout("Transform", true)]
//    public Transform _Player_TF;
//    public Transform _Machine_TF;
//    public GameObject _Pos;
//    public Vector3 _Machine_VT;
//    public Vector3 _Player_VT;
//    public Vector3 _Head;

//    public Machine_Renderer machine_renderer;
//    void Start()
//    {
//        _Head = transform.position;
//        machine_renderer = GetComponent<Machine_Renderer>();
//        //_Pos = transform.GetChild(0).gameObject;
//        if (_Type == Enemy_Type.Ground)
//        {
//            Move_GroundReset();
//        }
//        if (_Type == Enemy_Type.Fly)
//        {
//            Move_FlyReset();
//        }
//    }

//    void Update()
//    {


//    }
//    public void Move_Patrol()
//    {
//        if (_Move_AllTime_02 >= 0)
//        {
//            _Move_AllTime_02 -= Time.deltaTime;
//            _MoveAnim = false;
//            Move_Time();
//        }
//    }
//    public void Move_Time()
//    {
//        if (_Move_Patrol_Time_02 <= _Move_Patrol_Time_01)
//        {
//            _MoveAnim = true;
//            _Move_Patrol_Time_02 += Time.deltaTime;
//            _Machine_TF.position += _Machine_TF.forward
//                                    * (_MoveBool ? 1 : -1)
//                                    * Time.deltaTime
//                                    * _Move_Speed;
//        }
//        else if (_Move_AllTime_02 <= 0)
//        {
//            _MoveBool = !_MoveBool;
//            Move_Reset();
//            if (_MoveBool)
//                _Machine_TF.rotation = Quaternion.Euler(0, 90, 0);
//            else
//                _Machine_TF.rotation = Quaternion.Euler(0, 270, 0);
//        }
//    }
//    public void Move_Reset()
//    {
//        _Move_AllTime_02 = _Move_AllTime_01;
//        _Move_Patrol_Time_02 = 0f;
//    }
//    public void Ground()
//    {
//        _Distance = Vector3.Distance(transform.position, _Player_TF.position);//距離
//        {
//            //Debug.Log("X");
//            if (_Distance > _Machine._DrawGizmos._Detect_Radius)
//            {
//                Move_Patrol();
//            }
//            else if (_Distance < _Machine._DrawGizmos._Detect_Radius
//                     && _Distance > _Machine._DrawGizmos._Attack_Radius)
//            {
//                _MoveAnim = true;//
//                Machion_Chase();
//            }
//            if (_Distance < _Machine._DrawGizmos._Attack_Radius)
//            {
//                _MoveAnim = false;//
//                Aim();
//            }
//        }

//    }
//    public void Machion_Chase()
//    {       
//        _Machine_VT = Vector3.ProjectOnPlane(_Player_TF.position - transform.position, transform.up);
//        transform.Translate(Vector3.forward * Time.deltaTime * 5);
//        transform.rotation=Quaternion.LookRotation(_Machine_VT);
//    }
//    public void Aim()
//    {
//        _Machine_VT = Vector3.ProjectOnPlane(_Player_TF.position - transform.position, transform.up);
//        _Pos.transform.rotation = Quaternion.LookRotation(_Machine_VT);
//        _Machine._Attack.Fire();
//        transform.rotation = Quaternion.LookRotation(_Machine_VT);

//    }
//    public void Fly()
//    {
//        Stop_Time();
//        _Distance = Vector3.Distance(transform.position, _Player_TF.position);
//        if (_Distance > _Machine._DrawGizmos._Detect_Radius)
//        {
//            _Player_VT = _Player_TF.position;
//            Move_FlyReset();
//            Move_Patrol();
//        }
//        else if (_Distance < _Machine._DrawGizmos._Detect_Radius && _DetectBool == false)
//        {
//            Dive();
//        }
//        if (_DetectBool)
//        {
//            Back();
//        }
//    }
//    public void Dive()
//    {
//        if (_Attack_Time_02 == _Attack_Time_01 && _Machine._Attack._DiveBool_02==false)
//        {
//            transform.position = Vector3.Lerp(transform.position,
//                                              _Player_VT,
//                                              Time.deltaTime * _Move_Speed);
//            machine_renderer.Machine_Anim(Machine_Animator.Attack);
//        }
//        _Machine_TF.LookAt(_Player_VT);
//        _Attack_DT= Vector3.Distance(transform.position, _Player_VT);
//            Debug.Log(_Attack_DT);
//        if (_Machine._Attack._DiveBool_01 || _Machine._Attack._DiveBool_02 || _Attack_DT <=1)
//        {
//            //_Stop_Time_02 = _Stop_Time_01;
//            _StopBool = true;
//            machine_renderer.Machine_Anim(Machine_Animator.Attacking_move);
//            _Machine._Renderer._Machine_AM.SetBool("Attack", false);
//        }
//        if (_Attack_Time_02 < 0)
//        {
//            _DetectBool = true;
//        }
//    }
//    public void Back()
//    {
//        //RaycastHit Fly;

//        _Stop_Time_02 -= Time.deltaTime;
//        Vector3 pos = transform.GetChild(0).transform.position;
//        //if(Physics.Raycast(transform.position,-transform.up,out Fly, 1 << 10))
//        //{
//        //    float y;
//        //    y=Vector3.Distance(Fly.point, _Head);
//        //}
//        //_Machine_TF.rotation = Quaternion.Euler(0, 90, 0);
//        if(transform.position.y<10)
//            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
//        //if (_Stop_Time_02 <= 0)
//        else
//        {
//            _Attack_Time_02 = _Attack_Time_01;
//            _DetectBool = false;
//            _StopBool = false;
//        }
//    }
//    public void Stop_Time()
//    {
//        if (_StopBool)
//            _Attack_Time_02 -= Time.deltaTime;
//    }
//    public void Move_FlyReset()
//    {
//        _Attack_Time_02 = _Attack_Time_01;
//        _Stop_Time_02 = 0;
//        //_Attack._DiveBool_01 = false;
//        //_Attack._DiveBool_02 = false;
//        _StopBool = false;
//    }
//    public void Move_GroundReset()
//    {
//        _Attack._Now_AttackTime = 0;
//    }
//}
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
    public bool z;
    public bool _a;
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
            //Move_GroundReset();
        }
        if (_Type == Enemy_Type.Fly)
        {
            //Move_FlyReset();
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
            transform.position += _Machine_TF.forward
                                    * (_MoveBool ? 1 : 1)
                                    * Time.deltaTime
                                    * _Move_Speed;
        }
        else if (_Move_AllTime_02 <= 0)
        {
            _MoveBool = !_MoveBool;
            Move_Reset();
            if (_MoveBool)
                //_Machine_TF.rotation = Quaternion.Euler(0, 90, 0);
                _Machine_TF.Rotate(_Machine_TF.up * 180);
            else
                //_Machine_TF.rotation = Quaternion.Euler(0, 270, 0);
                _Machine_TF.Rotate(_Machine_TF.up * 180);
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
                Move_Patrol();
            }
            else if (_Distance < _Machine._DrawGizmos._Detect_Radius
                     && _Distance > _Machine._DrawGizmos._Attack_Radius)
            {
                _MoveAnim = true;//
                Move_Reset();
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
        _Machine_TF.rotation = Quaternion.LookRotation(_Machine_VT);
        transform.Translate( -_Machine_TF.right * Time.deltaTime * 5);
    }
    public void Aim()
    {
        _Machine_VT = Vector3.ProjectOnPlane(_Player_TF.position - transform.position, transform.up);
        _Machine_TF.transform.rotation = Quaternion.LookRotation(_Machine_VT);
        _Pos.transform.rotation = Quaternion.LookRotation(_Machine_VT);
        _Machine._Attack.Fire();

    }
    public void Fly()
    {
        x();
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
            z = false;
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
            _Machine._Renderer.Machine_Anim(Machine_Animator.Attack);
            _a = true;
        }
        _Machine_TF.LookAt(_Player_VT);
        float x = Vector3.Distance(transform.position, _Player_VT);
        if (x <= 1  || _Machine._Attack._DiveBool_01 || _Machine._Attack._DiveBool_02)
        //if (_Machine._Attack._DiveBool_01 || _Machine._Attack._DiveBool_02)
        {
            _Machine._Renderer.Machine_Anim(Machine_Animator.Attacking_move);
            _Machine._Renderer._Machine_AM.SetBool("Attack", false);
            _StopBool = true;
            _Stop_Time_02 = _Stop_Time_01;
            _a = false;
        }
        if (_Attack_Time_02 < 0)
        {
            _DetectBool = true;
        }
    }
    public void Back()
    {
        //if (_Stop_Time_02 <= _Stop_Time_01)
        //{
        //    _Stop_Time_02 += Time.deltaTime;
        //}
        //if (transform.position.y < 10)
        //{

        //Vector3 pos = transform.GetChild(0).transform.position;
        //    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime*0.5f);
        //}
        Vector3 machineDir_ = Vector3.ProjectOnPlane(_Machine_TF.forward, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, _Player_TF.position+Vector3.up*8- machineDir_*5f, Time.deltaTime*0.5f);
        _Stop_Time_02 -= Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        _Machine_TF.rotation = Quaternion.Lerp(_Machine_TF.rotation, Quaternion.LookRotation(machineDir_), Time.deltaTime * 2f);/*Quaternion.Euler(0, 90, 0);*/
        if (transform.position.y- _Player_TF.position.y >= 5)
        {
            _Attack_Time_02 = _Attack_Time_01;
            _DetectBool = false;
            _StopBool = false;
            z = true;
        }
    }
    public void Stop_Time()
    {
        if (_StopBool)
            _Attack_Time_02 -= Time.deltaTime;
    }
    public void x()
    {
        if(z)
           _Player_VT = _Player_TF.position;
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

