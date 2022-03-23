using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHead : MonoBehaviour
{
    float timeStone;
    float timeDive;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "stone"){
            if (Time.time > timeStone + 1){
                playerHP.instance.Damage(5);
                timeStone = Time.time;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "water"){
            if (Time.time > timeDive + 0.1){
                playerHP.instance.Damage(1);
                timeDive = Time.time;
            }
        }
    }


}
