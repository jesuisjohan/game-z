using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    public static EnemyManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.endGame)
        {
            GetComponent<Slime>().enabled = false;
        }
    }
}
