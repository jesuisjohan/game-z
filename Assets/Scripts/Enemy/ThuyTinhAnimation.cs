using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuyTinhAnimation : MonoBehaviour
{
    public static ThuyTinhAnimation instance;
    Animator anim;
    float time;
    // bool skill;
    private void Start() {
        if (!instance) instance = this;
        time = Time.time;
        // skill = false;
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update() {
        if (time + 0.67f < Time.time) {
            anim.SetBool("att1", false);
            anim.SetBool("att2", false);
        }
    }
    public void useSkill(){
        int num = Random.Range(0,2);
        if (num == 0)
            anim.SetBool("att1", true);
        else anim.SetBool("att2", true);
        time = Time.time;
    }
}
