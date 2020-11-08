using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool _IsRay;
    public Weapon _Weapon;
    public Player player;
    //Machine
    public Machine _Machine;
    private GameObject _Any;
    private GameObject _Machine_GOJ;
    public Collider[] _CollidersArray;
    private Vector3 _Machine_Position;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _CollidersArray = Physics.OverlapSphere(transform.position, _Weapon._WeaponSetting._WeaponRay[(int)_Weapon._WeaponSetting.nowWeapon], 1 << 11 | 1 <<14);
        foreach(Collider c in _CollidersArray)
        {
            _Machine_Position = c.gameObject.transform.position;
            _Machine_GOJ = c.gameObject;
            if (Vector3.Dot(player._Move._Move_Player_ModTF.forward, (_Machine_Position - transform.position).normalized) > 0)
            {
                Machine(_Machine_GOJ);
                _IsRay = true;
            }
            else
            {
                _IsRay = false;
                _Machine = null;
            }
        }
        if (_CollidersArray.Length <= 0)
        {
            _IsRay = false;
            _Machine = null;
        }
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.gameObject.GetComponent<Machine>();
    }
}
