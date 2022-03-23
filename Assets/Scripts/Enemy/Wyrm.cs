using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wyrm : Creep
{
    public float fireSpeed;
    public GameObject bullet;
    public Transform firePoint;
    public float fireCycle;
    public float waitTime;
    public bool resting;

    public Vector3[] positions;
    private int index;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        resting = true;
        waitTime = Time.time;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look = (Vector2)player.position - (Vector2)firePoint.position;
        if (Time.time > waitTime + fireCycle)
        {
            if (!resting)
            {
                Fire(look, bullet);
            }
            resting = false;
            waitTime = Time.time;
        } else
        {
            Fly();
        }
    }

    public void Fly()
    {
        GoTo((Vector2) positions[index]);
        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            } else
            {
                index++;
            }
        }
    }

    public void Fire(Vector2 look, GameObject bullet)
    {
        Debug.Log("Wyrm shoot");
        GameObject firedBullet = Instantiate(bullet);
        firedBullet.transform.position = firePoint.position;
        firedBullet.GetComponent<Rigidbody2D>().velocity = look * fireSpeed / look.magnitude;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TempPlayerArrow")
        {
            Destroy(gameObject);
        }
    }
}
