using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Attack : MonoBehaviour
{
    public GameObject _Bullet;
    public Transform Pos;
    public float _Shoot_Speet = 5;
    public bool _DiveBool_01;
    public bool _DiveBool_02;
    // Start is called before the first frame update
    void Start()
    {
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        GameObject _Attack = Instantiate(_Bullet);
        if (_Bullet)
        {
            _Attack.transform.position = Pos.transform.position;
            _Attack.transform.rotation = Pos.transform.rotation;
            Rigidbody _Bullet_RD = _Attack.GetComponent<Rigidbody>();
            if (_Bullet_RD)
            {
                _Bullet_RD.AddForce(_Attack.transform.forward * _Shoot_Speet);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player _Player = other.GetComponent<Player>();
            _DiveBool_01 = true;
            if (_Player._EvadeBool_01 == false)
                _Player._Renderer.BeAttack();
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
