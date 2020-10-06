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
    public Weapon_Type _nowType = Weapon_Type.Fist;
    //public Weapon_Type _Type = Weapon_Type.Fist;
    public GameObject[] _Weapon_Type;
    public Weapon_Trigger _Weapon_TG;
    // Start is called before the first frame update
    void Start()
    {
        _Weapon_TG = transform.GetChild(0).GetComponent<Weapon_Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _Weapon_Type[(int)_nowType].SetActive(false);
            _nowType = Weapon_Type.Fist;
            _Weapon_Type[(int)_nowType].SetActive(true);
            _Weapon_TG = transform.GetChild(0).GetComponent<Weapon_Trigger>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _Weapon_Type[(int)_nowType].SetActive(false);
            _nowType = Weapon_Type.Shield;
            _Weapon_Type[(int)_nowType].SetActive(true);
            _Weapon_TG = transform.GetChild(1).GetComponent<Weapon_Trigger>();
        }
    }
}
