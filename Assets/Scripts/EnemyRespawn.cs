using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private Transform[] resPointS;
    [SerializeField]
    private GameObject enemy;
    private int randomPoint;
    private float respawnDelay = 1.5f;

    void Start()
    {
        resPointS = GetComponentsInChildren<Transform>();
        InvokeRepeating("Spawn", 0, respawnDelay);
    }

    private void Spawn()
    {
        randomPoint = Random.Range(1, resPointS.Length);
        Instantiate(enemy, resPointS[randomPoint].position, Quaternion.identity);
    }
}
