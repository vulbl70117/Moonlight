using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_DrawGizmos : MonoBehaviour
{
    public float _Detect_Radius;
    public float _Attack_Radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red * 0.4f;
        Gizmos.DrawSphere(transform.position, _Attack_Radius);
        Gizmos.color = Color.blue * 0.4f;
        Gizmos.DrawSphere(transform.position, _Detect_Radius);
    }
}
