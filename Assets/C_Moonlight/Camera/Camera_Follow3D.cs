using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow3D : MonoBehaviour
{
    public To2D3D _Change_Camera;
    public Transform _Player_TF;
    //public Transform _Camera_Obj;
    private Transform _Camera;
    //
    private Vector3 _Follow;
    public float speed = 5f;
    public float deviation2D = 2f;
    public float _Camera_Speed = 0.1f;
    //public float deviation3D = 2f;//偏移量    
    public Player_Trigger _Trigger_Camera;
    public GameObject _Player_GO;
    private Player _Player;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = GetComponent<Transform>();
        _Player = _Player_GO.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Camera != null)
        {
            if (_Change_Camera == To2D3D.to3D || _Trigger_Camera._To3D)
            {
                _Change_Camera = To2D3D.to3D;
                //_Follow = new Vector3(_Camera.position.x, _Player_GO.transform.position.y - deviation2D, _Player_GO.transform.position.z - deviation2D);
                //_Camera.position = Vector3.Lerp(_Camera.position, _Follow, _Camera_Speed * Time.deltaTime);
            }
        } 
    }
}
