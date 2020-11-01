using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Attack : MonoBehaviour
{
    
    public Machine _Machine;
    public GameObject _Bullet;
    public Transform Pos;
    public float _Shoot_Speed = 2000;
    public float _TouchTime = 2;
    public float _Next_AttackTime;
    public float _Now_AttackTime = 0;
    private float _Attack_TouchTime;
    public bool _DiveBool_01;
    public bool _DiveBool_02;
    void Start()
    {
        _Machine = GetComponent<Machine>();
    }
    void Update()
    {
        
    }
    public void Fire()
    {
        if (Time.time > _Now_AttackTime + _Next_AttackTime)
        {
            _Now_AttackTime = Time.time;
            Shoot();
        }
    }
    public void Shoot()
    {
        if(_Machine._Renderer._BeAttack_time>=0)
        {
            return;
        }
        GameObject _Attack = Instantiate(_Bullet);
        if (_Bullet)
        {
            _Machine._Renderer.Machine_Anim(Machine_Animator.Attack);
            _Attack.transform.position = Pos.transform.position;
            _Attack.transform.rotation = Pos.transform.rotation;
            Rigidbody _Bullet_RD = _Attack.GetComponent<Rigidbody>();
            if (_Bullet_RD)
            {
                _Bullet_RD.AddForce(_Attack.transform.forward * _Shoot_Speed);
            }
            Destroy(_Attack, 3);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player _Player = other.GetComponent<Player>();
            _DiveBool_01 = true;
            if (_Player._Move._EvadeBool_01 == false && _Machine._Move._a == true)
            {
                if (Time.time > _Attack_TouchTime + _TouchTime)
                {
                    _Attack_TouchTime = Time.time;
                    _Player._Renderer.BeAttack();
                }
            }
        }
        if (other.CompareTag("Weapon"))
            _DiveBool_02 = true;
    }
    public void OnTriggerExit(Collider other)
    {
        _DiveBool_01 = false;
        _DiveBool_02 = false;
    }
}
