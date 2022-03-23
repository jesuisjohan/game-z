using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-2.5)
        {
            gameObject.transform.Translate(Vector3.up*Time.deltaTime/20000000);
        }
    }
}
