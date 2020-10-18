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
        GetAnglev3();
        //GetAngle(m_target1, m_target2);
    }

    void GetAnglev3()
    {
        //Vector3 relative = target1.InverseTransformPoint(target.position);
        Vector3 relative = target.position - target1.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        target1.rotation = Quaternion.Euler(transform.position.x, angle, transform.position.z);
    }

    void GetAngle(Transform target1, Transform target2)
    {
        Vector3 dir = target1.position - target2.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        m_target1.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
