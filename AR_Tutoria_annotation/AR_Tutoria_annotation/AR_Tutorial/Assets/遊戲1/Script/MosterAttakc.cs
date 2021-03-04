using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//自己打，除了:計時
public class MosterAttakc : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // 兩次攻擊之間的時間
    public int attackDamage = 10;               // 每次攻擊扣掉的生命值

    Animator anim;                              
    GameObject player;                          
    PlayerHealth playerHealth;                  
    MosterHealth mosterHealth;                   
    bool playerInRange;                         // 玩家是否在觸發對撞機內並且可以受到攻擊
    float timer;                                // 用於計數下一次攻擊的計時器
  

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        mosterHealth = GetComponent<MosterHealth>();
        anim = GetComponent<Animator>();
    }

    
    void OnTriggerEnter(Collider other)
     {
        // 如果進入的對撞機是玩家
        if (other.gameObject == player)
        {
            //玩家在範圍內
            playerInRange = true;
            anim.SetBool("PlayAttack", true);
        }
     }
    
   
    void Update()
    {
        
        timer += Time.deltaTime;

        // 如果計時器超過兩次攻擊之間的時間，則玩家處於範圍內，並且此敵人還活著
        if (timer >= timeBetweenAttacks && playerInRange && mosterHealth.currentHealth > 0)
        { 
             Attack();
        }

      
    }


    void Attack()
    {
       
        timer = 0f;

        //如果玩家失去血量
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        
        
    }
}
