using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow2D : MonoBehaviour
{
    public To2D3D _Change_Camera;
    //
    private Transform _Camera;
    //
    private Vector3 _Follow;
    public float _Camera_Speed = 0.1f;
    public float _Camera_ZeroTime=1.5f;
    public float deviation2D = 2f;//偏移量
    //
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
       
    }
    private void FixedUpdate()
    {
        if (_Camera != null)
        {
            if (_Change_Camera == To2D3D.to2D || _Player._Trigger._To2D)
            {
                _Change_Camera = To2D3D.to2D;
                _Player._Move._Camera_Time += Time.deltaTime;
                if (Vector3.Distance(_Camera.position, _Player_GO.transform.position) > 11 )
                {   
                    Follow_To2D();
                }
                if(_Player._Move._Camera_Time > _Camera_ZeroTime)
                {
                    Follow_To2D();
                }
            }
        }
    }
    public void Follow_To2D()
    {
        _Follow = new Vector3(_Player_GO.transform.position.x + deviation2D, _Player_GO.transform.position.y + deviation2D, _Camera.position.z);
        _Camera.position = Vector3.Lerp(_Camera.position, _Follow, _Camera_Speed * Time.deltaTime);
    }
}
