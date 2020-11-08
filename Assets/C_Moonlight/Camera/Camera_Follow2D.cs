using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow2D : MonoBehaviour
{
    private Vector3 _Camera;
    //
    private Vector3 _Follow;
    public float _Camera_Speed = 0.1f;
    public float _Camera_ZeroTime=1.5f;
    public float deviation2D_x = 2f;//偏移量
    public float deviation2D_y = 2f;//偏移量
    public float deviation2D_z = 2f;//偏移量
    //
    public GameObject _Player_GO;
    private Player _Player;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = transform.position;
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
           
                //_Player._Move._Camera_Time += Time.deltaTime;
                //if (Vector3.Distance(_Camera.position, _Player_GO.transform.position) > 3 )
                //{   
                //    Follow_To2D();
                //}
                //if(_Player._Move._Camera_Time > _Camera_ZeroTime)
                //{
                //    Follow_To2D();
                //}
                Follow_To2D();
        }
    }
    //public void Follow_To2D()
    //{
    //    _Follow = new Vector3(_Player_GO.transform.position.x + deviation2D_x, _Player_GO.transform.position.y + deviation2D_y, _Camera.position.z);
    //    _Camera.position = Vector3.Lerp(_Camera.position, _Follow, _Camera_Speed * Time.deltaTime);
    //}
    private void LateUpdate()
    {
        FollowUp_To2D();
    }
    public void Follow_To2D()
    {
        //_Follow = new Vector3(_Player_GO.transform.position.x + deviation2D_x, _Player_GO.transform.position.y + deviation2D_y, _Camera.position.z);
        _Follow = new Vector3(_Player_GO.transform.position.x + deviation2D_x, transform.position.y, transform.position.z);
        //_Follow = Vector3.ProjectOnPlane(_Follow, _Camera.up);
        transform.position = Vector3.Lerp(transform.position, _Follow, _Camera_Speed * Time.deltaTime);
    }
    public void FollowUp_To2D()
    {
        _Follow = new Vector3(transform.position.x, _Player_GO.transform.position.y + deviation2D_y, _Camera.z);
        Vector3 _FollowUp = new Vector3(transform.position.x, _Player_GO.transform.position.y + deviation2D_y, transform.position.z - deviation2D_z);
        //_Follow = Vector3.ProjectOnPlane(_Follow, _Camera.forward);
        if (_Player._Move._IsGround)
            transform.position = Vector3.Lerp(transform.position, _Follow, _Camera_Speed * Time.deltaTime);
        else if(_Player._Move._IsGround == false)
            transform.position = Vector3.Lerp(transform.position, _FollowUp, _Camera_Speed * 1.5f * Time.deltaTime);
    }
}
