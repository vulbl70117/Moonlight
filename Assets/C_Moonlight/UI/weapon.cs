using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject Weapon1_off;//關武器1顯示
    public GameObject Weapon2_off;//關武器2顯示

    public Transform image1;
    public Transform image2;

    public GameObject image_Sword;
    public GameObject image_Axe;


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
            pickweapon();
        }
        else
        {
            Weapon1_off.SetActive(true);
            Weapon2_off.SetActive(false);
        }
    }
    public void pickweapon()
    {
        //GameObject weapon1 = Instantiate(image_Sword);
        //weapon1.transform.position = new Vector3(2f, -4f, 0.0f);
        //Debug.Log("a");
    }
    
}
