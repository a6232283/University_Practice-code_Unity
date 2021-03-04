using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombConsumer : MonoBehaviour
{
    //檢測碰撞，如果是炸彈扣血，並且暫時關閉炸彈
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            collision.gameObject.SetActive(false);
            HealthController.health -= 1;
        }
    }
}
