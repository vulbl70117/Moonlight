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
    public Machine_Renderer _Renderer;
    //
    public Machine_Move _Move;
    //
    public Player _Player;
    void Start()
    {        
        _Move = GetComponent<Machine_Move>();
        _Renderer = GetComponent<Machine_Renderer>();
        _Player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
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
