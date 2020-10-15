using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

public class Boss : MonoBehaviour
{
    public Material[] _Boss_MR;
    public GameObject _Player;
    public Transform _Boundary;
    public GameObject _Bullet;
    public Transform _Pos;
    public Transform _Back;
    public Rigidbody _Boss_RD;
    public float _Shoot_Speed = 2000;
    public float _LookTime01 = 3f;
    private float _LookTime02;
    public float _AttackTime01 = 3f;
    private float _AttackTime02;
    public float _Rotation_Speed;
    public float _Rush_Speed = 5;
    private Quaternion _Follow;
    void Start()
    {
        _AttackTime02 = _AttackTime01;
    }
    void Update()
    {
        //Look_Player();
        //Smooth();
        //Boss_Rush();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_Boss_MR[]= _Boss_MR[1];
        }
    }
    public void Look_Player()
    {
        if (Time.time > _LookTime02 + _LookTime01)
        {
            _Follow = Quaternion.LookRotation(_Player.transform.position
                                               - transform.position);
            _LookTime02 = Time.time;
        }
    }
    public void Boss_Rush()
    {
        if (_AttackTime02 == _AttackTime01)
        {
            _Back.position = transform.position;
            _Boss_RD.isKinematic = true;
        }
        if (_AttackTime02 > 0)
        {
            transform.position = Vector3.Lerp(transform.position,
                                            _Boundary.position,
                                            _Rush_Speed * Time.deltaTime);
            _AttackTime02 -= Time.deltaTime;
        }
        else if (_AttackTime02 <= 0)
        {
        Debug.Log("X");
            transform.position = Vector3.Lerp(transform.position,
                                            _Back.position + Vector3.up * 10,
                                            _Rush_Speed * Time.deltaTime);
            _Boss_RD.isKinematic = false;
        }
    }
    public void Happy_Machina_Gun()
    {
        GameObject _Attack = Instantiate(_Bullet);
        if (_Bullet)
        {
            _Attack.transform.position = _Pos.transform.position;
            _Attack.transform.rotation = _Pos.transform.rotation;
            Rigidbody _Bullet_RD = _Attack.GetComponent<Rigidbody>();
            if (_Bullet_RD)
            {
                _Bullet_RD.AddForce(_Attack.transform.forward * _Shoot_Speed);
            }
        }
    }
    public void Smooth()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              _Follow,
                                              _Rotation_Speed * Time.deltaTime);

    }
}
