using Pixeye.Unity;
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
    public Player _Player;
    public Enemy_Type _Type;
    [Foldout("Scirpt", true)]
    public Machine_Attack _Attack;
    public Machine_Renderer _Renderer;
    public Machine_Move _Move;
    public Machine_DrawGizmos _DrawGizmos;
    void Start()
    {
        _Move = GetComponent<Machine_Move>();
        _Attack = GetComponent<Machine_Attack>();
        _Renderer = GetComponent<Machine_Renderer>();
        _DrawGizmos = GetComponent<Machine_DrawGizmos>();
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
