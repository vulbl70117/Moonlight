using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float grounddistance=0.4f;
    public float gravity = -9.81f;
    public float test = 0;
    public float jumptest = 3f;
    public float _JumpTime_01 = 1f;
    public float _JumpTime_02;
    public float jumplong;
    public float speed;
    public float _move = 10f;

    public Transform mod;
    public bool _JumpBool_01;
    public bool isground;
    public bool _testbool;
    public Transform feet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        jump();
        if (_testbool)
            pr();
        evade();
    }
    private void FixedUpdate()
    {
        move();
        
    }
    public void jump()
    {
        isground = Physics.CheckSphere(feet.position, grounddistance , 1 << 10);
        if (isground && speed < 0)
        {
            speed = test;
            _testbool = false;
        }
        else if(isground!=true)
        {
            _testbool = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            _testbool = true;
            speed = 10;
            _JumpBool_01 = true;
            _JumpTime_02 = _JumpTime_01;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (_JumpTime_02 >= 0 && _JumpBool_01 == true)
            {
                _JumpTime_02 -= Time.deltaTime;
                speed = 10;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _JumpBool_01 = false;
        }


    }
    public void move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * Time.deltaTime * _move);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * Time.deltaTime * -_move);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void evade()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Rigidbody _Move_Player_RD = GetComponent<Rigidbody>();
            _Move_Player_RD.velocity = mod.right*100;
        }
    }
    public void pr()
    {
        speed += gravity * Time.deltaTime;
        jumplong = speed * Time.deltaTime;
        transform.Translate(transform.up * jumplong);
        
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Machine"))
        {
            speed = 0;
        }
    }
}
