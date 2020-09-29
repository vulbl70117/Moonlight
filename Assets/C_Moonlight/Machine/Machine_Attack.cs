using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Attack : MonoBehaviour
{
    public GameObject _Bullet;
    public Transform Pos;
    public float _Shoot_Speet = 5;
    // Start is called before the first frame update
    void Start()
    {
           Shoot();
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
}
