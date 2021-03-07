using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody fizik;

    [Range(1,40)]
    public int speed = 30;
    
    void Start()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.transform.gameObject);
    }

    private void Movement()
    {
        fizik = transform.GetComponent<Rigidbody>();
        this.transform.rotation = Player.lookDir;
        fizik.velocity = transform.forward * speed;
    }
}
