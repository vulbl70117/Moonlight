using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow3D : MonoBehaviour
{
    public To2D3D _Change_Camera;
    public Transform _Player;
    public Transform _Camera_Obj;
    private Transform _Camera;
    //
    private Vector3 follow;
    public float speed = 5f;
    //public float deviation3D = 2f;//偏移量    
    public Player_Trigger _Trigger_Camera;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Camera != null)
        {
            if (_Change_Camera == To2D3D.to3D || _Trigger_Camera._To3D)
            {
                _Change_Camera = To2D3D.to3D;
                Debug.Log(_Camera.localEulerAngles);
                if ((_Camera.localEulerAngles.y <= 1)
                    || (_Camera.localEulerAngles.x > 270 && Input.GetAxis("Mouse Y") > 0)
                    || (_Camera.localEulerAngles.x < 90 && Input.GetAxis("Mouse Y") < 0))
                {
                    _Camera.RotateAround(_Player.position, _Player.right, (Input.GetAxis("Mouse Y")) * 180 * Time.deltaTime);
                }
                follow = new Vector3(_Player.position.x, _Player.position.y, _Player.position.z);
                _Camera_Obj.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 180 * Time.deltaTime);
                _Camera_Obj.position = follow;
            }
        } 
    }
}
