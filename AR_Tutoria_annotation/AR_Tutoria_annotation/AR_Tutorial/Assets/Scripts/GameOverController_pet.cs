using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController_pet : MonoBehaviour
{

    public GameObject Stop;//遊戲暫停

    Animator anim;





    //遊戲重新
    public void ButtonRestart()
    {
        SceneManager.LoadScene(2);
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
