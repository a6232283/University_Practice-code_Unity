using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//自己打 
public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // 開始血量100%
    public int currentHealth;                                   // 玩家血量
    public Slider healthSlider;                                 // 玩家血條
    public Image damageImage;                                   
    public float flashSpeed = 5f;                               // 圖片退色速度
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // 圖像的顏色設置為閃爍


    PlayerController playerController;                            
    PlayerAttack playerAttack;                             
    bool isDead;                                                // 玩家是否死亡
    bool damaged;                                              //玩家是否受傷


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponentInChildren<PlayerAttack>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        //如果受傷
        if (damaged)
        {
            //UI閃爍
            damageImage.color = flashColour;
        }
        else
        {   
            //UI恢復原來
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    //傷害
    public void TakeDamage(int amount)
    {
        damaged = true;

        // 減少生命值
        currentHealth -= amount;

        // 當前血量==血條
        healthSlider.value = currentHealth;


        // 如果玩家失去了所有生命值，並且設置死亡標誌。.
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // 設置死亡標誌，以使該函數不再被調用
        isDead = true;

        // 關閉
        playerAttack.DisableEffects();

        playerController.enabled = false;
        playerAttack.enabled = false;
        StartCoroutine(Main.Instance.Web.Game1("玩家死亡", SystemInfo.deviceModel));
        
    }
}
