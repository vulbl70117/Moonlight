using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Trigger : MonoBehaviour
{
    public bool _Weapon_BadyBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Machine")
        {
            _Weapon_BadyBool = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Machine")
        {
            _Weapon_BadyBool = false;
        }
    }
}
