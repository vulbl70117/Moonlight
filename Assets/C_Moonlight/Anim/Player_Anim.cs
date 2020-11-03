using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : StateMachineBehaviour
{
    public WeaponSetting _WeaponSetting;
    public PlayerSetting _PlayerSetting;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _PlayerSetting._AttackBool = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= _WeaponSetting.WeaponDataList[(int)_WeaponSetting.nowWeapon].AttackStartTime 
            && stateInfo.normalizedTime <= _WeaponSetting.WeaponDataList[(int)_WeaponSetting.nowWeapon].AttackEndTime)
        {
            animator.SetBool("Attacking", true);
        }
        else
            animator.SetBool("Attacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attacking", false);
        _PlayerSetting._AttackBool = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
