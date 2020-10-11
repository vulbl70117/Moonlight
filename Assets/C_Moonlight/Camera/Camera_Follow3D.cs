using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow3D : MonoBehaviour
{
    public To2D3D _Change_Camera;
    //public float deviation2D = 2f;//偏移量
    public float _Camera_Speed = 5f;
    private Transform _Camera;
    public Transform _Player_3D;
    public Transform _Boss_TF;
    public Player_Trigger _Trigger_Camera;
    private Vector3 _Follow;
    void Start()
    {
        _Camera = GetComponent<Transform>();
    }
    void Update()
    {
        if (_Camera != null)
        {
            if (_Change_Camera == To2D3D.to3D || _Trigger_Camera._To3D)
            {
                _Change_Camera = To2D3D.to3D;
                _Follow = new Vector3(_Player_3D.position.x, _Camera.position.y, _Player_3D.position.z);
                _Camera.transform.position = Vector3.Lerp(transform.position, _Follow, _Camera_Speed);
                _Camera.transform.LookAt(_Boss_TF.transform);
                //Debug.Log(Vector3.Distance(_Camera.position, _Boss_TF.position));
                Debug.Log(_Follow);
            }
        }
    }
}
