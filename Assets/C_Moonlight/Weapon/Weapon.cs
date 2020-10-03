using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Weapon_Type
{
    Fist,
    Sword,
    Axe,
    Shield
}
public class Weapon : MonoBehaviour
{
    private bool _FistBool;
    private bool _ShieldBool;
    public Weapon_Type _Type = Weapon_Type.Fist;
    
    public Weapon_Trigger _Weapon_TG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _Type = Weapon_Type.Shield;
        }
    }
    
}
