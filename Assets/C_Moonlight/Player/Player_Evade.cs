using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Evade : MonoBehaviour
{
    public float _UseEvadeTime_01 = 0.5f;
    public float _EvadeTime_01 = 0.25f;
    private float _NowEvadeTime_02;
    private float _EvadeTime_02;
    //
    public bool _EvadeBool_01;
    //
    private Rigidbody _Evade_Player_RD;
    private Collider _Evade_Player_CD;
    //
    private Player_Move _Move;
    private Player_Trigger _Trigger;
    // Start is called before the first frame update
    void Start()
    {
        _Evade_Player_RD = GetComponent<Rigidbody>();
        _Evade_Player_CD = GetComponent<Collider>();
        _Move = GetComponent<Player_Move>();
        _Trigger = GetComponent<Player_Trigger>();
    }
    public void Evade_Time()
    {
        if (_Move != null)
        {
            if (Time.time > _NowEvadeTime_02 + _UseEvadeTime_01)
            {
                _Move.Move2D(Player_2D.Evade);
                _NowEvadeTime_02 = Time.time;
                _EvadeTime_02 = _EvadeTime_01;
                _EvadeBool_01 = true;
            }
        }
    }
    public void Evade_ToMachine()
    {
        _EvadeTime_02 -= Time.deltaTime;
        if ((_EvadeTime_02 < 0 && _Trigger._Evade_ToMachine == false))
        {
            _EvadeBool_01 = false;
            _Evade_Player_RD.useGravity = true;
            _Evade_Player_RD.isKinematic = true;
            _Evade_Player_CD.isTrigger = false;
        }
    }
    public void Evade()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _EvadeBool_01 == false)
        {
            Evade_Time();
        }
        if (_EvadeBool_01 == true)
        {
            Evade_ToMachine();
        }
    }
}
