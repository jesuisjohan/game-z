using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource clickSound;
    public GameObject bullet;
    public Transform firePos;
    public Vector3 mousePos;
    int speed = 2000;
    void Start()
    {
        clickSound = gameObject.GetComponent<AudioSource>();
        clickSound.volume = PlayerPrefs.GetFloat("volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            GameObject b = Instantiate(bullet, firePos.position, firePos.rotation);
            Vector2 direc = (mousePos - transform.position).normalized;
            b.GetComponent<Rigidbody2D>().velocity = direc * speed * Time.deltaTime;

            clickSound.Play();
            // Vector2 lookAt = mousePos - b.GetComponent<Rigidbody2D>()..position;
            // // Calculate the rotation in radian
            // float Angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 180f;

            // b.GetComponent<Rigidbody2D>().rotation = Angle;


        }


    }
}
