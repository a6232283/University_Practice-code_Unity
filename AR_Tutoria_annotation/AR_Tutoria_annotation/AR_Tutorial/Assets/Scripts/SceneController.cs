using GoogleARCore;
using GoogleARCore.Examples.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public ScoreboardController scoreboard;
    public DragonController dragonController;
    void Start()
    {
        QuitOnConnectionErrors();
    }
    //
    //ARCore需要使用者給予足夠的資訊 才能在現實世界中開始追蹤使用者的移動
    //當ARCore開始追蹤，Frame就可以開始跟ARCore相互作用
    void Update()
    {
        //必須要有偵測到平面，才能更新
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        ProcessTouches();
        scoreboard.SetScore(ScoreboardController.score1);
    }

    //有錯誤就告知並離開
    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit(
                "Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit(
                "ARCore encountered a problem connecting. Please restart the app.", 5));
        }
    }

    //點擊開始遊戲
    void ProcessTouches()
    {
        //*****************************

        Touch touch;
        if (Input.touchCount != 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        //*****************************

        TrackableHit hit;
        //點在邊界 或 邊界多邊形
        TrackableHitFlags raycastFilter =
            TrackableHitFlags.PlaneWithinBounds |
            TrackableHitFlags.PlaneWithinPolygon;
        //設置平面
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            SetClickedPlane(hit.Trackable as DetectedPlane);
        }
    }

    void SetClickedPlane(DetectedPlane clickedPlane)
    {
        //設置記分板、噴火龍、水果和炸彈的平面
        scoreboard.SetClickedPlane(clickedPlane);
        dragonController.SetPlane(clickedPlane);
        GetComponent<FoodController>().SetClickedPlane(clickedPlane);
        GetComponent<BombController>().SetClickedPlane(clickedPlane);

    }
}
