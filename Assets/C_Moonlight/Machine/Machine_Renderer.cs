using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Renderer : MonoBehaviour
{
    public Weapon_Type_enum _WeaponType;
    public bool _StrikeBool;
    public float _Machine_HP = 3;
    public float _StrikePower = 1;
    private Rigidbody _Machine_RD;
    //
    public Machine _Machine;
    // Start is called before the first frame update
    void Start()
    {
        _Machine_RD = GetComponent<Rigidbody>();
        _Machine = GetComponent<Machine>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BeAttack(float damge)
    {
        if (_StrikeBool)
            return;
        Debug.Log("Target BeAttack!!/HP: " + _Machine_HP);
        if (_Machine_RD != null)
        {
            _Machine_HP -= damge;
            _StrikeBool = true;
            if (_Machine_HP < 0)
            {
                _Machine._Player._Trigger._Evade_ToMachine = false;
                gameObject.SetActive(false);
            }
        }
    }
    
}
