using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Machine_Animator
{
    Run,
    Attack,
    BeAttack
}
public class Machine_Renderer : MonoBehaviour
{
    public float _Machine_HP = 3;
    public Animator _Machine_AM;
    //
    public bool _StrikeBool;
    //
    private Player _Player;
    //
    public Machine _Machine;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Machine_Anim(Machine_Animator.Run);
    }
    public void BeAttack(float damge)
    {
        if (_StrikeBool)
            return;
        if (_Machine_AM != null)
        {
            Machine_Anim(Machine_Animator.BeAttack);
            _Machine_HP -= damge;
            _StrikeBool = true;
            Debug.Log("Target BeAttack!!/  HP: " + _Machine_HP);
            if (_Machine_HP < 0)
            {
                _Player._Trigger._Evade_ToMachine = false;
                gameObject.SetActive(false);
            }

        }
    }
    public void Machine_Anim(Machine_Animator _Animator, bool isTrue = false)
    {
        if (_Machine_AM == null)
            return;
        switch (_Animator)
        {
            case Machine_Animator.Run:
                {
                    if (_Machine._Move._MoveAnim)
                    {
                        _Machine_AM.SetBool("Run", true);
                    }
                    else if (_Machine._Move._MoveAnim == false)
                    {
                        _Machine_AM.SetBool("Run", false);
                    }
                    break;
                }
            case Machine_Animator.Attack:
                {
                    _Machine_AM.SetTrigger("Attack");
                    break;
                }
            case Machine_Animator.BeAttack:
                {
                    _Machine_AM.SetTrigger("BeAttack");
                    break;
                }
        }
    }
    //public void Machine_Material()
    //{
    //    if(_ChangeMaterial_02 <= _ChangeMaterial_01)
    //    {
    //        _Machine_RD.velocity = Vector3.up;
    //        _ChangeMaterial_02 -= Time.deltaTime;
    //    }
    //    if(_ChangeMaterial_02 <= 0)
    //    {
    //        _MaterialBool = false;
    //        _ChangeMaterial_02 = _ChangeMaterial_01;
    //    }
    //}
}
