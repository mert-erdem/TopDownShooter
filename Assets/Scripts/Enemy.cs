using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    [Range(1, 10)]
    public int speed = 1;
    private int deltaDistance = 2;
    private bool stop = false; private int explosionDelta = 1;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if ((this.transform.position - player.transform.position).magnitude >= deltaDistance
            && !stop)
        {
            transform.LookAt(player.transform);
            this.transform.position = Vector3.MoveTowards(
            this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        stop = true;//stop movement

        yield return new WaitForSeconds(explosionDelta);

        Collider[] nearbyObjects = Physics.OverlapSphere(this.transform.position, 5f);

        foreach (Collider col in nearbyObjects)
        {
            if (col.gameObject.tag == "player")
            {
                Destroy(col.gameObject);
                break;
            }
        }

        Destroy(this.gameObject);
    }
}
