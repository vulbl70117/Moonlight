using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Machine"))
            return;
        if (other.CompareTag("Weapon"))
            Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            Player _Player = other.gameObject.GetComponent<Player>();
            if (_Player._Move._EvadeBool_01 == false)
            {   
                _Player._Renderer.BeAttack();
                Destroy(gameObject);
            }
        }
    }
}
