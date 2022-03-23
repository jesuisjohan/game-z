using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stoneprefab;
    public float timeDrop;
    private Vector2 pos;
    void Start()
    {
        timeDrop = 2;
    }

    // Update is called once per frame
    void Update()
    {

        if(timeDrop <= 0)
        {
            // pos = new Vector2(Random.Range(-5f,5f),8);
            // GameObject stone = Instantiate(stoneprefab,pos,Quaternion.identity);
            // // Destroy(stone,5f);
            // timeDrop = 1;
        }
        timeDrop -= Time.deltaTime;
    }
}
