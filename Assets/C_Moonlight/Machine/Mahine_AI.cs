using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mahine_AI : MonoBehaviour
{
    private NavMeshAgent _Machion_NMA;
    public Transform _Player_TF;
    void Start()
    {
        _Machion_NMA = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        
    }
    public void Machion_Chase()
    {
        _Machion_NMA.SetDestination(_Player_TF.position);
    }
}
