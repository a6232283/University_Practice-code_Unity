using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardController : MonoBehaviour
{
    public Camera firstPersonCamera;
    private Anchor anchor;
    private DetectedPlane detectedPlane;
    private float yOffset;
    private int score;
    public static int score1=0;

    void Start()
    {
        score1 = 0;
        //先將記分板隱藏 直到用戶點選一個平面
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    void Update()
    {
        //直到有平面被追蹤且有平面才開始更新frame
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        // If there is no plane, then return
        if (detectedPlane == null)
        {
            return;
        }

        //如果目前平面包含在其他平面，換成其他平面
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

        //讓記分板面對玩家
        transform.LookAt(firstPersonCamera.transform);

        // Move the position to stay consistent with the plane.
        //更新計分板跟Y軸的距離
        transform.position = new Vector3(transform.position.x,
                    detectedPlane.CenterPose.position.y + yOffset, transform.position.z);
    }

    //設置平面
    public void SetClickedPlane(DetectedPlane clickedPlane)
    {
        this.detectedPlane = clickedPlane;
        CreateAnchor();
    }

    //產生Anchor
    void CreateAnchor()
    {
        //在螢幕頂端找到一個點
        Vector2 pos = new Vector2(Screen.width * .5f, Screen.height * .90f);
        Ray ray = firstPersonCamera.ScreenPointToRay(pos);
        Vector3 anchorPosition = ray.GetPoint(5f);

        //在那個點生成anchor
        if (anchor != null)
        {
            Object.Destroy(anchor);
        }
        anchor = detectedPlane.CreateAnchor(
            new Pose(anchorPosition, Quaternion.identity));

        //將記分板跟anchor連接
        transform.position = anchorPosition;
        transform.SetParent(anchor.transform);

        //記錄跟平面的y距離
        yOffset = transform.position.y - detectedPlane.CenterPose.position.y;

        //開啟記分板
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    //設置分數
    public void SetScore(int score)
    {
        if (this.score != score)
        {
            GetComponentInChildren<TextMesh>().text = "Score: " + score;
            this.score = score;
        }
    }
}
