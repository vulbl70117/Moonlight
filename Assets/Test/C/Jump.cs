using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float grounddistance=0.4f;
    public float gravity = -9.81f;
    public float test = -2f;
    public float jumptest = 3f;
    public float _JumpTime_01 = 1f;
    public float _JumpTime_02;
    public float jumplong = 2f;

    public bool _JumpBool_01;
    public bool isground;
    public Vector3 velocity;
    public CharacterController controller;
    public Transform feet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(feet.position, grounddistance, 1 << 10);
        if(isground && velocity.y < 0)
        {
            velocity.y = test;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            //velocity.y = jumptest;
            velocity.y = Mathf.Sqrt(jumptest * -2 * gravity);
            _JumpBool_01 = true;
            _JumpTime_02 = _JumpTime_01;
            Debug.Log(velocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(_JumpTime_02 >= 0 && _JumpBool_01 == true)
            {
                _JumpTime_02 -= Time.deltaTime;
                velocity.y = Mathf.Sqrt(jumptest * -2 * gravity );
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _JumpBool_01 = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
