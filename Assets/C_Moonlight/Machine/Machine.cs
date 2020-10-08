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
    private float _Distance;
    public  float _Stop_Time = 2f;
    //
    public bool _StopBool=false;
    public bool _DetectBool=false;
    //
    public Machine_Renderer _HP;
    //
    private Machine_Move _Move;
    //
    public Player_Renderer _Player_HP;
    void Start()
    {        
        _Move = GetComponent<Machine_Move>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (_Type == Enemy_Type.Ground)
        {
            _Move.Ground();
        }
        if (_Type == Enemy_Type.Fly)
        {
            _Move.Fly();
        }
    }
}
