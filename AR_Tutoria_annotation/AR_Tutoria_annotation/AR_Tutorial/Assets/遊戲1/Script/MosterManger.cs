using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//自己打
public class MosterManger : MonoBehaviour
{
    public PlayerHealth playerHealth;            //放入玩家血量
    public GameObject Moster;                 //放入蜘蛛
    public float spawnTime = 3f;            // 每個生成之間的間隔時間
    public Transform[] spawnPoints;         // 該敵人生成點


    void Start()
    {
        // 在產生時間延遲後調用Spawn函數，然後在相同的時間後繼續調用
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        StartCoroutine(Main.Instance.Web.Game1("怪物生成", SystemInfo.deviceModel));

        // 如果玩家血量<=0
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // 找到一個生成點，零到一的隨機索引。
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // 在隨機選擇的生成點位置和旋轉位置創建敵方
        Instantiate(Moster, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
