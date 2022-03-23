using System;
using UnityEngine;

public class sonTinh : MonoBehaviour
{
    public GameObject[] stoneObject;
    public Transform hand;
    float vMax = 9f;
    float vMin = 0.3f;
    float time;
    float delay = 2f;
    static float vPre = -2f;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time + delay < Time.time) {
            ThrowStone();
            time = Time.time;
            delay -= 0.01f;
            // vMax +=0.005f;
        }
    }
    void ThrowStone(){
        sonTinhAnimation.instance.throwStone();
        GameObject thisStone = Instantiate(stoneObject[UnityEngine.Random.Range(0, stoneObject.Length)]);
        thisStone.transform.position = hand.position;
        float v = RandomVelocity();
        vPre = v;
        thisStone.GetComponent<Rigidbody2D>().velocity = new Vector2(v,8f);
    }
    float RandomVelocity(){
        float v;
        if (UnityEngine.Random.Range(0,1f) < 0.6)
            v = UnityEngine.Random.Range(vMin + 1.5f, vMax - 3.5f);
        else v = UnityEngine.Random.Range(vMin, vMax);
        if (v >= vPre + 1.2 || v <= vPre - 1.2){
            return v;
        }
        else return RandomVelocity();
    }

    // int randomStone(){
    //     return (int) ;
    // }
}
