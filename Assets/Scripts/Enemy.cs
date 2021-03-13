using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody fizik;
    public int health = 100;
    [Range(1, 10)]
    public int speed = 1;
    private int deltaDistance = 2;
    private bool stop = false; private int explosionDelta = 1, explosionRadius=4;

    //Collectables;
    [SerializeField]
    private GameObject maxAmmo;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        fizik = this.transform.GetComponent<Rigidbody>();
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
            this.transform.LookAt(player.transform);
            this.transform.position = Vector3.MoveTowards(
            this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if((this.transform.position - player.transform.position).magnitude < deltaDistance
            && !stop)
        {
            StartCoroutine(Explode());
        }
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health<=0)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        this.stop = true;//stop movement

        fizik.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(explosionDelta);

        Collider[] nearbyObjects = Physics.OverlapSphere(this.transform.position, this.explosionRadius);

        foreach (Collider col in nearbyObjects)
        {
            if(col.gameObject.tag=="enemy" || col.gameObject.tag=="player")
            {
                Destroy(col.gameObject);
            }           
        }

        RandomDropCollectable();//drop collectables like "MaxAmmo" via a constant range.

        Destroy(this.transform.gameObject);
    }

    private void RandomDropCollectable()
    {
        if(Random.Range(0, 100)>90)
        {
            Instantiate(maxAmmo, this.transform.position, Quaternion.identity);
        }
    }
}
