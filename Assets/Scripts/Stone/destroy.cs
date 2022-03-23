using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "stone"){
            if (other.gameObject.GetComponent<stone>() != null)
                if (!other.gameObject.GetComponent<stone>().destroyed){
                    other.gameObject.GetComponent<stone>().stand = true;
                    other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - diveController.instance.speed);
                    other.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                    other.gameObject.GetComponent<stone>().destroyed = true;
                }
            else if (other.gameObject.GetComponent<ground>() != null) 
                if (!other.gameObject.GetComponent<ground>().destroyed){
                    other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - diveController.instance.speed);
                    other.gameObject.GetComponent<ground>().destroyed = true;
                }
            Destroy(other.gameObject,3f);
        }
    }
}
