using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacke : MonoBehaviour
{
    public Player player;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<Player>();
            player._Renderer.BeAttack();
        }
    }
}
