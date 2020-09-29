using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class player : MonoBehaviour
{
    private enum Player_
    {
        jumpup = 0,
        jumphole,
        right,
        left
    }
    //
    private Rigidbody player_01;
    private Collider player_02;
    //
    private bool jump_01;
    private bool jump_02;
    public int jumppower = 5;
    public float jumptime_01 = 0.5f;
    private float jumptime_02;
    //
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player_01 = GetComponent<Rigidbody>();
        player_02 = GetComponent<Collider>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //JUMP
        if (Input.GetKeyDown(KeyCode.Space)&&jump_01)
        {           
            Move(Player_.jumpup);
        }               
        if (Input.GetKey(KeyCode.Space) &&jump_02)
        {
            Move(Player_.jumphole);
        }     
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump_02 = false;
        }
        
    }
    private void FixedUpdate()
    {
        
        if (Input.GetKey("a"))
        {
            Move(Player_.left);
        }
        if (Input.GetKey("d"))
        {
            Move(Player_.right);
        }
    }


    //JUMP
    private void Move(Player_ a, bool isTrue = false)
    {
        if (player_01 == null)
            return;
        switch (a)
        {
            case Player_.jumpup:
                {
                    jump_02 = true;
                    jumptime_02 = jumptime_01;
                    player_01.velocity = Vector3.up * jumppower;
                    break;
                }
            case Player_.jumphole:
                {
                    if (jumptime_02 > 0)
                    {
                        player_01.velocity = Vector3.up * jumppower;
                        jumptime_02 -= Time.deltaTime;
                    }
                    break;
                }
            case Player_.right:
                {
                    transform.Translate(0, 0, -5 * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
            case Player_.left:
                {
                    transform.Translate(0, 0, -5 * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 360, 0);
                    break;
                }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        jump_01 = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        jump_01 = false;
    }
    
}
