using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerT;
    private Vector3 lookDir;

    void Start()
    {
        lookDir = transform.position - playerT.position;
    }

    void FixedUpdate()
    {
        Vector3 newPos = playerT.position + lookDir;
        transform.position = Vector3.Slerp(transform.position, newPos, 0.1f);
    }
}
