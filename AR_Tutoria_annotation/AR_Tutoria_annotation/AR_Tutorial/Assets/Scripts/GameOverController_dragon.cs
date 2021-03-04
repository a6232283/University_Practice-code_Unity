using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController_dragon : MonoBehaviour
{
    public float restartDelay = 5f;

    public GameObject restart;//重新
    public GameObject homeScreen;//回主畫面
    public GameObject Stop;//遊戲暫停
    Animator anim;

    void Start()
    {
        //UI關閉
        restart.SetActive(false);
        homeScreen.SetActive(false);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (HealthController.health <= 0)
        {
            //UI開啟
            restart.SetActive(true);
            homeScreen.SetActive(true);

            // 呼叫動畫"GameOver"
            anim.SetTrigger("GameOver");


        }
    }

    //遊戲重新
    public void ButtonRestart()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    //回到主畫面
    public void ButtonHomeScreen()
    {
        SceneManager.LoadScene(0);
    }
    //遊戲暫停
    public void StopButton()
    {
        Time.timeScale = 0f;
        Stop.SetActive(true);
    }
    //遊戲繼續
    public void GameContinue()
    {
        Time.timeScale = 1f;
    }
}