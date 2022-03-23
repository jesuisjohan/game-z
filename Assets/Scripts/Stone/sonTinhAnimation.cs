using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTinhAnimation : MonoBehaviour
{
    public static sonTinhAnimation instance;
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
        if (time + 0.5f < Time.time) {
            anim.SetBool("throw", false);
        }
    }
    public void throwStone(){
        anim.SetBool("throw", true);
        time = Time.time;
    }
}
