using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//自己打
public class MosterController : MonoBehaviour
{
    Transform Player;              
    NavMeshAgent nav;


    
    PlayerHealth playerHealth;
    MosterHealth mosterHealth;

    void Awake()
    {
       
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = Player.GetComponent<PlayerHealth>();
        mosterHealth = GetComponent<MosterHealth>();

        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //怪物血量>0 或玩家血量>0
        if (mosterHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(Player.transform.position);//怪物追蹤
         }
         else
         {
             nav.enabled = false;
         }
 

    }
    
}
