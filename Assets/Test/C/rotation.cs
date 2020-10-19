using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform m_target1;
    public Transform m_target2;
    public Transform target;
    public Transform target1;

    void Update()
    {
        Vector3 relative = Vector3.ProjectOnPlane(target.position - transform.position, transform.up);
        Debug.DrawLine(transform.position, transform.position + (target.position - transform.position).normalized * 100f, Color.green);
        Debug.DrawLine(transform.position, transform.position + (relative).normalized * 100f, Color.red);
        Debug.Log(relative);
        transform.rotation = Quaternion.LookRotation(relative);
        //if (relative.x < 0)
        //{
        //    transform.eulerAngles = Vector3.up * -90;
        //}
        //else if (relative.x > 0)
        //{
        //    transform.eulerAngles = Vector3.up * 90;
        //}
        
    }

    void GetAnglev3()
    {
        //Vector3 relative = target1.InverseTransformPoint(target.position);
        //Vector3 relative = Vector3.ProjectOnPlane(target.position - transform.position, transform.up);
        //float angle = Vector3.SignedAngle(relative, transform.up, transform.forward);
        //target1.rotation = Quaternion.Euler(0, angle, 0);
    }

    void GetAngle(Transform target1, Transform target2)
    {
        Vector3 dir = target1.position - target2.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        m_target1.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
