using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Player_Animator
{
    Run,
    Attack,
    Jump,
    JumpDown
}
public class Player_Renderer : MonoBehaviour
{
    public float _HP = 30f;
    public Animator _Player_AM;
    private Player _Player;
    void Start()
    {
        _Player = GetComponent<Player>();
    }
    void Update()
    {
        Player_Anim(Player_Animator.Run);
    }
    public void BeAttack()
    {
        _HP--;
        Debug.Log("剩餘" + _HP);
        if (_HP < 0)
            gameObject.SetActive(false);
    }
    public void Player_Anim(Player_Animator _Animator,bool isTrue = false)
    {
        if (_Player_AM == null)
            return;
        switch (_Animator)
        {
            case Player_Animator.Run:
                {
                    if (_Player._RunBool)
                    {
                        _Player_AM.SetBool("Run", true);
                    }
                    else if (_Player._RunBool == false)
                    {
                        _Player_AM.SetBool("Run", false);
                    }
                    break;
                }
            case Player_Animator.Attack:
                {
                    break;
                }
            case Player_Animator.Jump:
                {
                    _Player_AM.SetTrigger("Jump");
                    //_Player_AM.SetTrigger("JumpAir");
                    break;
                }
            case Player_Animator.JumpDown:
                {
                    if (_Player._Jump == true && _Player._Move._Acceleration_02 < 0)
                    {
                    _Player_AM.SetBool("JumpDown", isTrue);
                    }
                    break;
                }
        }
    }
}
