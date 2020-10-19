using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_UI : MonoBehaviour
{
    public GameObject Weapon1_off;//關武器1顯示
    public GameObject Weapon2_off;//關武器2顯示

    public List<GameObject> weapon1_image = new List<GameObject>();
    public List<GameObject> weapon2_image = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chang_weapon(int weapon_num)
    {
        if(weapon_num == 0)
        {
            Weapon1_off.SetActive(false);
            Weapon2_off.SetActive(true);
        }
        else
        {
            Weapon1_off.SetActive(true);
            Weapon2_off.SetActive(false);
        }
    }
    public void Pick_Weapon(Weapon_Type_enum weapontype, int chWeapon)
    {
        if (weapontype == Weapon_Type_enum.Sword)
        {
            if (chWeapon == 0)
            {
                weapon1_image[0].SetActive(true);
                weapon1_image[1].SetActive(false);
            }
            else
            {
                weapon2_image[0].SetActive(true);
                weapon2_image[1].SetActive(false);
            }
        }
        if (weapontype == Weapon_Type_enum.Axe)
        {
            if (chWeapon == 0)
            {
                weapon1_image[1].SetActive(true);
                weapon1_image[0].SetActive(false);
            }
            else
            {
                weapon2_image[1].SetActive(true);
                weapon2_image[0].SetActive(false);
            }
        }
    }
    
}
