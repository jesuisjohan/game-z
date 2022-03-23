using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TempPlayer")
        {
            // Player take damage
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // Play destroy sound
        //Instantiate(effect, transform.position, Quaternion.identity);
    }
}
