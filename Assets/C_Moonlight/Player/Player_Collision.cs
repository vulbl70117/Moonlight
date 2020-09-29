using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    public bool JumpBool_01;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            JumpBool_01 = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            JumpBool_01 = false;
        }
    }
}
