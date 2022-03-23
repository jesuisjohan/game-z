using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{   
    AudioSource waterSound;
    public bool destroyed = false; 
    public bool stand = false;
    public GameObject[] skills;

    // bool touch = false;
    float waterHeight = -3f;
    float time;
    float timeSkill;
    Transform[] edge;
    // bool stand = false;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        edge = gameObject.GetComponentsInChildren<Transform>();
        timeSkill = Time.time;
        waterSound = gameObject.GetComponent<AudioSource>();
        waterSound.volume = PlayerPrefs.GetFloat("volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!stand && Time.time > time + 2.5f) {
            gameObject.GetComponent<Rigidbody2D>().mass += 50f;
            // gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            // gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            stand = true;
            time = Time.time;
        }
        if (stand && transform.position.y < waterHeight) {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - diveController.instance.speed);
        }

       
        useSkill();
        
    }

    void useSkill(){
        // if (timeSkill + 5 < Time.time){
            if (!diveController.instance.useSkill && transform.position.y > waterHeight && stand){
                if (Random.Range(0,1f) >  0.7f) {
                    ThuyTinhAnimation.instance.useSkill();
                    int numSkill = Random.Range(0,2);
                    GameObject skill = Instantiate(skills[numSkill]);
                    skill.transform.position = new Vector2( edge[GetHighestEgde()].position.x, edge[GetHighestEgde()].position.y+1);
                    Destroy(skill,1f);
                    diveController.instance.useSkill = true;
                    timeSkill = Time.time;
                }
            }
        // }
    }

    int GetHighestEgde(){
        int index = 0;
        float max = -99;
        for (int i = 0; i< edge.Length; i++)
        {
            if (edge[i].position.y > max) {
                max= edge[i].position.y;
                index = i;
            }
        }
        return index;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "water"){
            // Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
             if (gameObject.GetComponent<Rigidbody2D>().velocity.y < -1){
                // touch = true;
                waterSound.Play();
            }
        }
    }
}
