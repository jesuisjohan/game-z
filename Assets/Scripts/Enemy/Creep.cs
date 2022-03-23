using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Transform player => GameObject.FindGameObjectWithTag("TempPlayer").transform;
    public float speed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GoTo(Vector2 newPos)
    {
        Vector2 route = newPos - (Vector2)transform.position;
        rb.MovePosition(rb.position + route * speed * Time.deltaTime);
    }
}
