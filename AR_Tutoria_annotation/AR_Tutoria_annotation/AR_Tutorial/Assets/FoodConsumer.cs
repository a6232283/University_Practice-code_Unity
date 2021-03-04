using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodConsumer : MonoBehaviour
{
    //檢測碰撞，如果是水果加分，並且暫時關閉水果
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "food")
        {
            collision.gameObject.SetActive(false);
            ScoreboardController.score1 += 1;
        }
    }

}
