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
            //Destroy(other.gameObject);
            Player_HP _player = other.gameObject.GetComponent<Player_HP>();
            if (_player != null)
            {
                _player.BeAttack();
                Destroy(gameObject);
            }
        }
    }
}
