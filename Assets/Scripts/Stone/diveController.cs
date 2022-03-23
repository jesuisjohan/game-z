using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diveController : MonoBehaviour
{
    public static diveController instance;
    public float speed = 0.0001f;
    public bool useSkill = false;
    float timeSkill;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance) instance = this;
        time = Time.time;
        timeSkill = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time + 1){
            speed += 0.000005f;
        }
        if (useSkill == true && Time.time > timeSkill + 5){
            useSkill = false;
            timeSkill = Time.time;
        }
    }
}
