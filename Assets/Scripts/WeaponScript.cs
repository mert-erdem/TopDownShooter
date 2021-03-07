using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet, muzzle; 

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        }
    }
}
