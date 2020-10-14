using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Renderer : MonoBehaviour
{
    public float _HP = 30f;
    public Animator _Player_AM;
    private Player _Player;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAin();
    }
    public void BeAttack()
    {
        _HP--;
        Debug.Log("剩餘" + _HP);
        if (_HP < 0)
            gameObject.SetActive(false);
    }
    public void RunAin()
    {
        if (_Player._RunBool)
        {
            _Player_AM.SetBool("Run", true);
        }
        else if(_Player._RunBool==false)
        {
            _Player_AM.SetBool("Run", false);
        }
    }
}
