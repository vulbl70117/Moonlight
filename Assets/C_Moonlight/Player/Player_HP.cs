using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public float _HP = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeAttack()
    {
        _HP--;
        Debug.Log("剩餘" + _HP);
        if (_HP < 0)
            gameObject.SetActive(false);
    }
}
