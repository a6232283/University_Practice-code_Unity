using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//自己打 
public class MosterHealth : MonoBehaviour
{
    public int startingHealth = 100;            // 敵人開始遊戲時的生命
    public int currentHealth;                   // 敵人當前的血量
    public int scoreValue = 1;                 // 敵人死亡時增加到玩家分數中的數量
    public GameObject moster;
    bool isDead;                                // 敵人是否死亡
    void Awake()
    {
        //anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // 如果敵人死了
        if (isDead)
        {
            return;
        }
            
        //玩家攻擊傷害減少怪物當前生命
         currentHealth -= amount;
       
        // 如果血量<=0
        if (currentHealth <= 0)
        {
            // 死亡
            Death();
            StartCoroutine(Main.Instance.Web.Game1("怪物被龍殺死了", SystemInfo.deviceModel));
        }
    }


    

    void Death()
    {
        // 敵人死亡
        isDead = true;
        //怪物消失
        moster.SetActive(false);
        //分數++
        Score.score += scoreValue;
        
    }

  
}
