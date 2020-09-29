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
    public Transform _Player_Mod;
    private Transform _Move_Player_TF;
    //
    public Rigidbody _Move_Player_RD;
    //
    public Collider _Move_Player_CD;
    //
    public float _EavdeSpeed;
    
    void Start()
    {
        _Move_Player_TF = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move2D(Player_2D _2D, bool isTrue = false)
    {
        if (_Move_Player_RD == null)
            return;
        switch (_2D)
        {
            case Player_2D.Right:
                {
                    _Move_Player_TF.Translate(0, 0, 5 * Time.deltaTime);
                    _Move_Player_TF.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
            case Player_2D.Left:
                {
                    _Move_Player_TF.Translate(0, 0, 5 * Time.deltaTime);
                    _Move_Player_TF.rotation = Quaternion.Euler(0, 360, 0);
                    break;
                }
            case Player_2D.Evade:
                {

                    _Move_Player_RD.velocity = _Move_Player_TF.forward * _EavdeSpeed;
                    _Move_Player_RD.useGravity = false;
                    _Move_Player_CD.isTrigger = true;
                    break;
                }
        }
    }
    public void Move3D(Player_3D _3D, bool isTrue = false)
    {
        if (_Move_Player_RD == null)
            return;

    }
}
