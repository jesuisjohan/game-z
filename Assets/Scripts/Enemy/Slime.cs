using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Creep
{   
    public SlimeController controller;

    private Collider2D m_Collider;

    public GameObject deathEffect;

    public float runSpeed = 2f;

    public Vector2[] startingPositions;

    Vector2 startingPos;

    float horizontalMove = -1f;
   
    bool jump = false;
    
    bool canJump = false;
    
    int calls = 0;

    protected override void Start()
    {
        base.Start();
        m_Collider = GetComponent<Collider2D>();
        int rand = Random.Range(0, startingPositions.Length);
        startingPos = startingPositions[rand];
    }

    private void Update()
    {
        if (!canJump) return;

        if (transform.position.y < SlimeSpawner.instance.transform.position.y)
        {
            Die();
        }

        if (player.transform.position.x < transform.position.x)
        {
            horizontalMove = -1f;
        } else
        {
            horizontalMove = 1f;
        }
    }

    private void FixedUpdate()
    {
        if (Ready())
        {
            canJump = true;
        }

        if (canJump)
        {
            if (!m_Collider.enabled)
            {
                m_Collider.enabled = true;
            }

            if (calls % 25 == 0)
            {
                jump = true;
            }

            controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false, jump);
            jump = false;

            calls++;
        } 
        else
        {
            if (m_Collider.enabled)
            {
                m_Collider.enabled = false;
            }
            GoTo((Vector2)startingPos);
        }
    }

    private bool Ready()
    {
        return (startingPos.x - 0.1f <= transform.position.x 
            && transform.position.x <= startingPos.x + 0.1f)
            && (startingPos.y - 0.1f <= transform.position.y 
            && transform.position.y <= startingPos.y + 0.1f);
    }

    public void Die()
    {
        SlimeSpawner.instance.Spawn();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TempPlayer")
        {
            // Debug.Log("Take slime dmg");
            playerHP.instance.Damage(5);
            //Player takes damage
            Die();
        }
        else if (collision.gameObject.tag == "bullet")
        {
            //Debug.Log("Slime get shot");
            Die();
        } else if (collision.gameObject.tag == "stone")
        {
            if (collision.gameObject.transform.position.y >= transform.position.y)
            {
                Debug.Log("Hit stone");
                Die();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Debug.Log("Hit bullet");
            Die();
        }
    }
}
