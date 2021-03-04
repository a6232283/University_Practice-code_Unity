using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private DetectedPlane detectedPlane;
    private GameObject bombInstance;
    private float bombTime;
    private readonly float bombPeriod = 15f;

    public GameObject[] bombModels;

    void Update()
    {
        //需有偵測到平面，才更新
        if (detectedPlane == null)
        {
            return;
        }

        if (detectedPlane.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        //如果目前平面包含在其他平面，換成其他平面
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }
        //生成炸彈
        if (bombInstance == null || bombInstance.activeSelf == false)
        {
            if (ScoreboardController.score1 >= 0)
            {
                GenerateBombInstance();
                return;

            }
            else if(ScoreboardController.score1 >= 30)
            {
                for(int i=0; i<2; i++)
                {
                    GenerateBombInstance();
                }
                return;
            }
            else if (ScoreboardController.score1 >= 60)
            {
                for (int i = 0; i < 3; i++)
                {
                    GenerateBombInstance();
                }
                return;
            }

            else if (ScoreboardController.score1>=100)
            {
                for (int i = 0; i < 4; i++)
                {
                    GenerateBombInstance();
                }
                return;
            }
            else if (ScoreboardController.score1 >= 150)
            {
                for (int i = 0; i < 5; i++)
                {
                    GenerateBombInstance();
                }
                return;
            }

        }
        //炸彈經過一段時間沒吃就會消失
        bombTime += Time.deltaTime;
        if (bombTime >= bombPeriod)
        {
            Object.Destroy(bombInstance);
            bombInstance = null;
        }

        
    }

    void GenerateBombInstance()
    {
        //隨機選一個炸彈
        GameObject bomb = bombModels[Random.Range(0, bombModels.Length)];

        //*******************************************************

        //在平面的頂點隨機選擇一個位置，然後在頂點跟平面的中心選一個點
        List<Vector3> points = new List<Vector3>();
        detectedPlane.GetBoundaryPolygon(points);
        Vector3 point = points[Random.Range(0, points.Count)];
        float distance = Random.Range(0.05f, 1f);
        Vector3 bombPosition = Vector3.Lerp(point, detectedPlane.CenterPose.position, distance);

        //*******************************************************

        //將炸彈移動到平面上
        bombPosition.y += .05f;

        //設置anchor
        Anchor anchor = detectedPlane.CreateAnchor(new Pose(bombPosition, Quaternion.identity));

        //實例化炸彈
        bombInstance = Instantiate(bomb, bombPosition, Quaternion.identity,
                 anchor.transform);

        //初始化炸彈
        bombInstance.tag = "bomb";

        bombInstance.transform.localScale = new Vector3(.025f, .025f, .035f);
        bombInstance.transform.SetParent(anchor.transform);
        bombTime = 0;
        bombInstance.AddComponent<FoodSpecialEffect>();

    }

    //設置平面
    public void SetClickedPlane(DetectedPlane clickedPlane)
    {
        detectedPlane = clickedPlane;
    }
}
