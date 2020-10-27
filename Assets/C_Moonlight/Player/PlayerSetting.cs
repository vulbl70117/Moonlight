using Pixeye.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObject/PlayerSetting")]
public class PlayerSetting : ScriptableObject
{
    [Foldout("Move",true)]
    public float _Height_01 = 10f;
    public float _EavdeVT_Y = 5f;
    public float _SlideVT_Y = 1f;
    public float _EavdeSpeed_2D = 5f;
    //public float _EavdeSpeed_3D = 5f;
    public float _UseEvadeTime = 0.5f;
    public float _EvadeTime_01 = 0.4f;
    [Foldout("Renderer", true)]
    public bool x;
    public float _HP = 30f;
    public float _BeAttack_DelayTime_01;
    public float[] _SpeedMultiplier;
    public AnimatorOverrideController[] OverrideController;
}
