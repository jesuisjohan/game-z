using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointManager : MonoBehaviour
{
    public static pointManager instance;
    public TextMeshProUGUI pointText;
    int point;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        time = Time.time;
        pointText.text = point + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (time + 5 < Time.time){
            point += 10; 
            time = Time.time; 
            pointText.text = point + "";
        }
    }
    public void BonusPoint (int pnt){
        point += pnt; 
        pointText.text = point + "";
    }
}
