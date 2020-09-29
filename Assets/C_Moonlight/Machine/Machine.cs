using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Machine : MonoBehaviour
{
    private float _Distance;
    //
    public bool _DetectBool=true;
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
    void Start()
    {
        _Player_TF = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _Move = GetComponent<Machine_Move>();
        _DrawGizmos = GetComponent<Machine_DrawGizmos>();
        _AI = GetComponent<Mahine_AI>();
    }

    // Update is called once per frame
    void Update()
    {
        //未偵測到敵人+Bool
        _Distance = Vector3.Distance(transform.position, _Player_TF.position);
        Debug.Log(_DrawGizmos._Detect_Radius);
        Debug.Log(_Distance);
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
        }
    }
   
}
