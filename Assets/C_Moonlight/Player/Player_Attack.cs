using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public bool _StrikeBool;
    public Weapon _Weapon;
    public Player player;
    //Machine
    public Machine _Machine;
    private GameObject _Any;
    public Collider[] colliders;
    private Vector3 z;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, 5, 1 << 11);
        foreach(Collider c in colliders)
        {
            z = c.gameObject.transform.position;
        }

        if (Vector3.Dot(player._Move._Move_Player_ModTF.forward, (transform.position - z).normalized) > 0)
        {
            Debug.Log(Vector3.Dot(player._Move._Move_Player_ModTF.forward, (transform.position - z).normalized));
        }
        Debug.Log(z);
    }
    public void Machine(GameObject machine)
    {
        _Any = machine;
        _Machine = _Any.gameObject.GetComponent<Machine>();
    }
}
