using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//自己打
public class GameOverManger : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    Animator anim;

    //UI
    public GameObject joystick;//搖桿
    public GameObject atk;//攻擊
    public GameObject restart;//重新
    public GameObject homeScreen;//回主畫面
    public GameObject Stop;//遊戲暫停
    public GameObject HightScore;

    void Start()
    {
        //UI關閉
        restart.SetActive(false);
        homeScreen.SetActive(false);
       // HightScore.SetActive(false);
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // 如果玩家血量<=0
        if (playerHealth.currentHealth <= 0)
        {
            //UI開啟
            restart.SetActive(true);
            homeScreen.SetActive(true);
            //HightScore.SetActive(true);

            // 呼叫動畫"GameOver"
            anim.SetTrigger("GameOver");

            //控制關閉
            joystick.SetActive(false);
            atk.SetActive(false);
        }
    }
    //遊戲重新
    public void ButtonRestart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        StartCoroutine(Main.Instance.Web.Game1("玩家按下重新開始", SystemInfo.deviceModel));
    }
    //回到主畫面
    public void ButtonHomeScreen()
    {
        SceneManager.LoadScene(0);
        StartCoroutine(Main.Instance.Web.Game1("玩家按下回主畫面", SystemInfo.deviceModel));
    }
    //遊戲暫停
    public void StopButton()
    {
        Time.timeScale = 0f;
        Stop.SetActive(true);
        StartCoroutine(Main.Instance.Web.Game1("玩家按下暫停", SystemInfo.deviceModel));
    }
    //遊戲繼續
    public void GameContinue()
    {
        Time.timeScale = 1f;
        StartCoroutine(Main.Instance.Web.Game1("玩家按下繼續遊戲", SystemInfo.deviceModel));
    }
}
