using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private Machine _Machine;
    // Start is called before the first frame update
    void Start()
    {
        _Machine = GameObject.FindGameObjectWithTag("Machine").GetComponent<Machine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        if (_Machine != null)
        {
            _Machine._HP.BeAttack();
            _Machine._HP._StrikeBool = false;
        }
    }
}
