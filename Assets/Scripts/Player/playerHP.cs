using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public static playerHP instance;
    public Animator animator;
    public Slider hpBar;
    int maxHP = 100;
    int curHP;
    // Start is called before the first frame update
    private void Awake() {
        
        // animator = gameObject.GetComponent<Animator>();
        if (!instance) instance = this;
        // animator = gameObject.GetComponent<Animator>();
        curHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = curHP;
    }
    
    public void Damage(int dmg){
        curHP -= dmg;
        hpBar.value = curHP;
        animator.SetFloat("AniPlayer",0.85f);
        if (curHP <= 0)
        {
            GameManager.instance.endGame = true;
            StartCoroutine(AniEnd());
        } 
    }
    IEnumerator AniEnd()
    {
        animator.SetFloat("AniPlayer",0.2f);
        yield return new WaitForSeconds(1f);
        GameManager.instance.GameOver();
    }

}
