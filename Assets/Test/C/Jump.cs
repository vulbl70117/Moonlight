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
    public float _evade_time1=0.2f;
    public float _evade_time2;

    private Collider collider_;
    public Transform mod;
    public bool _JumpBool_01;
    public bool isground;
    public bool _testbool1;
    public bool _testbool2;
    public Transform feet;
    public Vector3 test_v;
    // Start is called before the first frame update
    void Start()
    {
        _evade_time2 = 0;
        collider_ = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        jump();
        if (_testbool1)
            Gravity();
        evade();
        if (_evade_time2>0)
        {
            collider_.isTrigger = true;
            _evade_time2 -= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, test_v, 10 * Time.deltaTime);
        }
        else
        {
            _evade_time2 = 0;
        }
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
            _testbool1 = false;
        }
        else if(isground!=true)
        {
            _testbool1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            _testbool1 = true;
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
            mod.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * Time.deltaTime * -_move);
            mod.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void evade()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            test_v = new Vector3(transform.position.x + (mod.rotation.y == 0 ? 5f : -5), transform.position.y, transform.position.z);
            _evade_time2 = _evade_time1;
        }
    }
    public void Gravity()
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
