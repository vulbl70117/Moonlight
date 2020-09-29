using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow2D : MonoBehaviour
{
    public To2D3D _Change_Camera;
    //
    public Transform _Player;
    private Transform _Camera;
    private Vector3 player;
    
    //
    private Vector3 follow;
    public float speed = 5f;
    public float Zero;
    public float deviation2D = 2f;//偏移量
    //
    public Player_Trigger _Trigger_Camera;
    public float time=3f;
    private float nowtime=0f;
    private Rigidbody z;

    // Start is called before the first frame update
    void Start()
    {
        _Camera = GetComponent<Transform>();
        z = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        player = new Vector3(_Player.position.x, _Player.position.y, _Player.position.z);
        
        //Debug.Log(nowtime);
        if (_Camera != null)
        {
            if (_Change_Camera == To2D3D.to2D || _Trigger_Camera._To2D)
            {
                _Change_Camera = To2D3D.to2D;
                
                 nowtime += Time.deltaTime;
                
                //Debug.Log();
                if (Vector3.Distance(_Camera.position, _Player.position) > 20)
                {
                    
                    Follow_To2D();

                }
                //if (z.velocity.z <= 0)
                //{

                //    follow = new Vector3(_Camera.position.x, _Player.position.y - deviation2D, _Player.position.z - deviation2D);
                //    _Camera.position = Vector3.Lerp(_Camera.position, follow, Zero * Time.deltaTime);
                //    nowtime -= Time.deltaTime;
                   


                //}
                
                //Debug.Log(Vector3.Distance(_Camera.position, _Player.position));
            }
        }
    }
    public void Follow_To2D()
    {
        nowtime = 0;
        follow = new Vector3(_Camera.position.x, _Player.position.y - deviation2D, _Player.position.z - deviation2D);
        _Camera.position = Vector3.Lerp(_Camera.position, follow, speed * Time.deltaTime);
        
        //Debug.Log(_Camera.position);

    }
}
