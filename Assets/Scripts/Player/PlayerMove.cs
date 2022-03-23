using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float dirX;
    private float jump;
    public int speed = 100;
    public int force = 120;
    private Rigidbody2D rig;
    public bool booljump;

    void Start()
    {

        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) booljump = true;
        SetAnimation();

    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.endGame)
        {
            if (dirX < -0.01)
            {
                transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
                transform.localScale = new Vector2(-1, 1);
            }
            else if (dirX > 0.01)
            {

                transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
                transform.localScale = new Vector2(1, 1);


            }
            if (gameObject.GetComponent<Collider2D>().IsTouchingLayers() && booljump)
            {
                Debug.Log("jump");
                rig.velocity = Vector2.up * force * Time.fixedDeltaTime;
                booljump = false;
            }
        }

    }
    void SetAnimation()
    {
        if (rig.velocity.y > 0.2f)
        {
            playerHP.instance.animator.SetFloat("AniPlayer", 0.4f);
        }
        else if (rig.velocity.y < -0.5f)
        {
            playerHP.instance.animator.SetFloat("AniPlayer", 0.6f);
        }
        else if (dirX < -0.2 && gameObject.GetComponent<Collider2D>().IsTouchingLayers())
        {

            playerHP.instance.animator.SetFloat("AniPlayer", 0.67f);


        }
        else if (dirX > 0.2 && gameObject.GetComponent<Collider2D>().IsTouchingLayers())
        {

            playerHP.instance.animator.SetFloat("AniPlayer", 0.67f);


        }
        else
        {
            playerHP.instance.animator.SetFloat("AniPlayer", 1);
        }
    }
}
