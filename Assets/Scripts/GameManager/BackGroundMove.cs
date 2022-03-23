using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float couttimewin = 5;
    void Update()
    {
        if(transform.position.y > -37)gameObject.transform.Translate(Vector3.down*Time.deltaTime/2);
        else
        {
            if(couttimewin <=0)
            {
                GameManager.instance.WinGame();
            }
            couttimewin-= Time.deltaTime;
        }
    }
}
