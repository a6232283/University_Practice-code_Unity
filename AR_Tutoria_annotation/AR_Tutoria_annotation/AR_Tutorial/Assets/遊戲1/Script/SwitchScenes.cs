using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//全都自己打
public class SwitchScenes : MonoBehaviour
{
    public GameObject GameDescription1;
    public GameObject GameDescription2;
    public GameObject GameDescription3;

    //開始按鈕
    public void ButtonScene1()
    {      
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        StartCoroutine(Main.Instance.Web.Game1("玩家按下進入遊戲一", SystemInfo.deviceModel));

    }

    public void ButtonScene2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        StartCoroutine(Main.Instance.Web.Game1("玩家按下進入遊戲二", SystemInfo.deviceModel));
    }

    public void ButtonScene3()
    { 
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        StartCoroutine(Main.Instance.Web.Game1("玩家按下進入遊戲三", SystemInfo.deviceModel));
    }


    //說明
    public void Description1()
    {     
        GameDescription1.SetActive(true);
        StartCoroutine(Main.Instance.Web.Game1("玩家按下遊戲說明一", SystemInfo.deviceModel));
    }


    public void Description2()
    {   
        GameDescription2.SetActive(true);
        StartCoroutine(Main.Instance.Web.Game1("玩家按下遊戲說明二", SystemInfo.deviceModel));
    }

    public void Description3()
    {
        GameDescription3.SetActive(true);
        StartCoroutine(Main.Instance.Web.Game1("玩家按下遊戲說明三", SystemInfo.deviceModel));
    }

}
