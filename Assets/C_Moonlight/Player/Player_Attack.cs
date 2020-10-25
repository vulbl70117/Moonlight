using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool _StrikeBool;
    public Weapon _Weapon;
    //Machine
    public Machine _Machine;
    private GameObject _Any;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.gameObject.GetComponent<Machine>();
    }
}
